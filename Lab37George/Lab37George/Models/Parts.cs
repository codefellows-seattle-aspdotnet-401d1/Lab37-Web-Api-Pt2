using System.ComponentModel.DataAnnotations;

namespace Lab37George.Models
{
    public class Parts
    {
        // I set the key here preparing for more tables
        [Key]
        public int PartID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Quantity { get; set; }
    }
}
