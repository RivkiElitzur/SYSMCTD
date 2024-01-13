using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SYSMCTD.Models
{
    public class Customers : EntityBase
    {
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
    }
}
