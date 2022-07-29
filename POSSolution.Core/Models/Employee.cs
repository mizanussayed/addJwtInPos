using POSSolution.Core.Common.Models;
using POSSolution.Core.Enum;

namespace POSSolution.Core.Models;

public class Employee : Identity
{
    public Designation Designation { get; set; }
    public string profilePicture { get; set; }
}
