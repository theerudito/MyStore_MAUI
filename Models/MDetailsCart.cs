using System.ComponentModel.DataAnnotations;

namespace MyStore_MAUI.Models
{
    public class MDetailsCart
    {
        [Key]
        public int IdDetailCart { get; set; }
        public int IdCart { get; set; }
        public string Date_Now { get; set; } = "";
        public string Hour_Now { get; set; } = "";
        public float Subtotal { get; set; }
        public float Subtotal12 { get; set; }
        public float SubTotal0 { get; set; }
        public float IvaTotal { get; set; }
        public float Total { get; set; }
        public MCart Cart { get; set; } = new MCart();
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
