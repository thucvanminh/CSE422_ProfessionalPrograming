using System.ComponentModel.DataAnnotations;

namespace Lab2_VanMinhThuc.Models
{
    public class Category
    {

        [Key]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }

        public ICollection<Device> Device { get; set; }
    }
}
