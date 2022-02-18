using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Net.Http;
using ALUXION.Services.Interfaces;
using ALUXION.Domain;
using ALUXION.Repositories.Interfaces;
using ALUXION.DTOs;

namespace ALUXION.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;

        public AuthController(IUserRepository userRepository, IRoleRepository roleRepository,
            IJwtService jwtService, IMapper mapper,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _jwtService = jwtService;
            _mapper = mapper;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                User user = await _userRepository.GetByEmail(dto.Email, false);
                if (user == null)
                {
                    Role role = await _roleRepository.GetByRole(RoleType.User);
                    user = _mapper.Map<User>(dto);
                    user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                    user.Provider = ProviderType.Local;
                    user.Token = Guid.NewGuid().ToString();
                    user.RoleId = role.Id;
                    _emailService.ValidateUser(user.Token, user.Email);
                    user = await _userRepository.CreateAsync(user);
                    return Created("Success", user);
                }
                else if (!user.IsActive)
                {
                    _emailService.ValidateUser(user.Token, user.Email);
                    return BadRequest(new { message = "User already exists, check your email to validate your user" });
                }

                return BadRequest(new { message = "User already exists" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("validateUser")]
        public async Task<IActionResult> Validate(ValidUserDto dto)
        {
            try
            {
                string message = "Invalid User";
                User user = await _userRepository.GetByEmailAndToken(dto.Email, dto.Token);
                if (user == null) return BadRequest(new { message = message });

                await _userRepository.ActiveUser(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                string message = "Invalid Credentials";
                User user = await _userRepository.GetByEmail(dto.Email);
                if (user == null) return BadRequest(new { message = message });

                if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password)) return BadRequest(new { message = message });

                string jwt = _jwtService.Generate(user);

                return Ok(new { token = jwt });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       

        [HttpPost("login/sso")]
        public async Task<IActionResult> LoginSSOAsync(LoginSsoDto dto)
        {
            try
            {
                if (dto.Provider == ProviderTypeDto.Google)
                {
                    var payload = await _jwtService.VerifyGoogleToken(dto.IdToken);
                    if (payload == null) return BadRequest(new { message = "Token Id not valid." });
                    var user = await _userRepository.GetByEmail(payload.Email, false);
                    if (user == null)
                    {
                        user = new User
                        {
                            FirstName = dto.Name,
                            LastName = dto.LastName,
                            Email = payload.Email,
                            PhoneNumber = "",
                            Password = BCrypt.Net.BCrypt.HashPassword(payload.Email + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()),
                            Provider = ProviderType.Google,
                        };
                        var role = await _roleRepository.GetByRole(RoleType.User);
                        user.RoleId = role.Id;
                        user.IsActive = true;
                        user = await _userRepository.CreateAsync(user);
                    }
                    if (user.Provider != ProviderType.Google) {
                        new Exception("Not valid account");
                    }
                    var jwt = _jwtService.Generate(user);

                    return Ok(new { token = jwt });
                }
                return BadRequest(new { message = "Token Id not valid." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            try
            {
                string message = "Invalid Email";
                User user = await _userRepository.GetByEmail(dto.Email);
                if (user == null || user.Provider!= ProviderType.Local) return BadRequest(new { message = message });

                string userToken = await _userRepository.GenerateToken(user);

                _emailService.ResetPassword(user.Token, user.Email);

                return Ok(new { message = "Success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPut("reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            try
            {
                string message = "Invalid User";
                User user = await _userRepository.GetByEmailAndToken(dto.Email, dto.Token);
                if (user == null) return BadRequest(new { message = message });

                await _userRepository.ResetPassword(user, BCrypt.Net.BCrypt.HashPassword(dto.Password));

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}