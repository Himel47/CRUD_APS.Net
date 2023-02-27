using System.ComponentModel.DataAnnotations;

namespace ToDoNoteAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [Required]
        public string noteDescrition { get; set; }
        public bool isActive { get; set; }
        
        [Display(Name = "Attachment")]
        public string attachedPhoto { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatesDate { get; set; }

    }
}
