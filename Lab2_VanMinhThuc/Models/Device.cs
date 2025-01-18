using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab2_VanMinhThuc.Models
{
    public class Device
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Đảm bảo Device_Code tự động tăng

        public int  Device_Code { get; set; }
        public string Device_Name { get; set; }
        public int  Category_ID { get; set; }
        public string Status { get; set; }

        public DateTime ? Date_Of_Entry { get; set; }

        public Category Category { get; set; }  // Navigation property
       


    }
}
