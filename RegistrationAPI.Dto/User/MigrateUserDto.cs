using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationAPI.Dto.User;

public class MigrateUserDto
{
    public int Id { get; set; }
    public string LegacySystemId { get; set; } = null!;
}