using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class Customer
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    [MaxLength(20)]
    [MinLength(3)]
    public string FirstName { get; set; } = "";
    [MaxLength(20)]
    [MinLength(3)]
    public string LastName { get; set; } = "";
    [EmailAddress]
    public string Email { get; set; } = "";
    public string? Phone { get; set; }
    public ICollection<CustomerAddress> Addresses { get; set; } = new HashSet<CustomerAddress>();
}
