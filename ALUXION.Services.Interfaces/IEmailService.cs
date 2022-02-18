
namespace ALUXION.Services.Interfaces
{
    public interface IEmailService
    {
        Task ValidateUser(string token, string mailTo);
        Task ResetPassword(string token, string mailTo);
        Task ConfirmPurchase(string mailTo,int quantity,decimal price);
    }
}
