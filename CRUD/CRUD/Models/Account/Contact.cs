using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Account
{
    public class Contact
    {
        [Key]public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
