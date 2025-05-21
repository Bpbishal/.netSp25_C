using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        public int? Qty { get; set; } // Nullable<int>
        public double Price { get; set; }
        [ForeignKey("Cate")]
        public int CatId { get; set; }

        public virtual Category Cate { get; set; }



    }
}
