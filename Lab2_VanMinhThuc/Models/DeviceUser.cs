using System.ComponentModel.DataAnnotations;

namespace Lab2_VanMinhThuc.Models
{
    public class DeviceUser
    {
        [Key]
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public int User_Phone { get; set; }
    }
}
