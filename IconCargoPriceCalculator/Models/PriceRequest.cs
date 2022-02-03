using System.ComponentModel.DataAnnotations.Schema;

namespace IconCargoPriceCalculator.Models
{
    public class PriceRequest:Entity
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double CalculatedDimension { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CalculatedPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
