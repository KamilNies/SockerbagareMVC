using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sockerbagare2.Models
{
    public class RecievedOrder
    {
        [Key]
        public int Id { get; set; }
        public int ProviderId { get; set; }
        [Required]
        public int IngredientId { get; set; }
        [Required]
        public string BatchNumber { get; set; }
        [Required]
        public DateTime ManufacturingDate { get; set; }
        [Required]
        public string RecievingDate { get; set; }
        [Required]
        public DateTime BestBeforeDate { get; set; }
        [Required]
        public string DeliveryNumber { get; set; }
        [Required]
        public double QuantityKg { get; set; }
        [MaxLength(200)]
        public string Comments { get; set; }

        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }

    }
}
