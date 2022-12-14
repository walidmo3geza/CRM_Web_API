using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class CustomerReadDTO
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string? Phone { get; set; }
    public ICollection<CustomerAddressChildReadDTO> Addresses { get; set; } = new HashSet<CustomerAddressChildReadDTO>();
}
