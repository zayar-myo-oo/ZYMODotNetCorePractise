
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYMODotNetCorePractise.Models
{
    [Table("Tbl_User")]
    public class BlogDataUser
    {
        [Key]
        public int User_id { get; set; }
        public string User_name { get; set; }
        public int User_age { get; set; }
        public string User_nrc { get; set; }
        public string User_address { get; set; }
        public int Mobile_no { get; set; }
    }
}
