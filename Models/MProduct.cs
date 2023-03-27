using System.ComponentModel.DataAnnotations;

namespace MyStore_MAUI.Models
{
    public class MProduct
    {
        [Key]
        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = "";
        public string CodeProduct { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Description { get; set; } = "";
        public int Quantity { get; set; }
        public float P_Unitary { get; set; }
        public float P_Total { get; set; }
        public string Image_Product { get; set; } = "";
        public string RefImagen { get; set; } = "";
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<MCart> Cart { get; set; } = new List<MCart>();
    }
}
