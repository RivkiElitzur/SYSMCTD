using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SYSMCTD.Models
{
    public class Contacts : EntityBase
    {
        public string FullName { get; set; }
        public string? OfficeNumber { get; set; }
        public string? Emai { get; set; }

        public int CustomerId { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
