using System.ComponentModel.DataAnnotations;

namespace MyStore_MAUI.Models
{
    public class MCodeApp
    {
        [Key]
        public int IdCode { get; set; }
        public string CodeAdmin { get; set; } = "";
    }
}
