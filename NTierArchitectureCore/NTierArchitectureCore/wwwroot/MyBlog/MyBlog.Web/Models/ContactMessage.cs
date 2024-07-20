using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.Models
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="İsim alanı doldurun.")]
        [StringLength(50, ErrorMessage ="İsim en fazla 32 karakter içermeli")]
        [MinLength(2, ErrorMessage = "İsim en az 2 karakter içermeli")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı doldurun.")]
        [StringLength(50, ErrorMessage = "Soyisim en fazla 32 karakter içermeli")]
        [MinLength(2, ErrorMessage = "Soyisim en az 2 karakter içermeli")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email alanı doldurun.")]
        [StringLength(100, ErrorMessage = "Email en fazla 100 karakter içermeli")]
        [MinLength(10, ErrorMessage = "Email en az 10 karakter içermeli")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon alanı doldurun.")]
        [StringLength(13, ErrorMessage = "Telefon en fazla 13 karakter içermeli")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Konu alanı doldurun.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Mesaj alanı doldurun.")]
        public string Description { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedDate { get; set; }



    }
}
