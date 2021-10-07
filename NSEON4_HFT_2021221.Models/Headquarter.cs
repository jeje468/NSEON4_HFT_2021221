using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Models
{
    public class Headquarter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string City { get; set; }

        [NotMapped]
        public virtual Brand Brand { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
    }
}
