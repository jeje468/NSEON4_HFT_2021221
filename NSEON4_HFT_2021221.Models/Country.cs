using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Continent { get; set; }

        [NotMapped]
        public virtual ICollection<Headquarter> Headquarters { get; set; }

        public Country()
        {
            Headquarters = new HashSet<Headquarter>();
        }
    }
}
