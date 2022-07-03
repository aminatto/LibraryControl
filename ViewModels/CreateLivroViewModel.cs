using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class CreateLivroViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Author { get; set; }
    }
}