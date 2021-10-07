using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Phone> Phones { get; set; }

        [NotMapped]
        public virtual ICollection<Headquarter> Headquarters { get; set; }

        public Brand()
        {
            Phones = new HashSet<Phone>();
        }
    }
}
