using System.ComponentModel.DataAnnotations;

namespace MyStore_MAUI.Models
{
    public class Naruto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;
        public string Clan { get; set; } = String.Empty;
        public int Age { get; set; }
    }
}