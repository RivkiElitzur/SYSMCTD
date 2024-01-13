using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SYSMCTD.Models
{
    public class Addresses : EntityBase
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int CustomerId { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
