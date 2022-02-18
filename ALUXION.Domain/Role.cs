using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALUXION.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public RoleType RoleType { get; set; }

    }
}
