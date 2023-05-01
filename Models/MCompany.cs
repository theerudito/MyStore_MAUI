using System.ComponentModel.DataAnnotations;

namespace MyStore_MAUI.Models
{
    public class MCompany
    {
        [Key]
        public int IdCompany { get; set; }

        public string NameCompany { get; set; } = "";
        public string NameOwner { get; set; } = "";
        public string Direction { get; set; } = "";
        public string Email { get; set; } = "";
        public string RUC { get; set; } = "";
        public string Phone { get; set; } = "";
        public int NumDocument { get; set; }
        public string Serie1 { get; set; } = "";
        public string Serie2 { get; set; } = "";
        public string Document { get; set; } = "";
        public string DB { get; set; } = "";
        public string Iva { get; set; }
        public string Coin { get; set; } = "";
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}