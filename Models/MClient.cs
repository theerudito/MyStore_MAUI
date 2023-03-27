using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore_MAUI.Models
{

    public class MClient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdClient { get; set; }
        public string DNI { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Direction { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string City { get; set; } = "";
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<MCart> Cart { get; set; } = new List<MCart>();
    }
}
