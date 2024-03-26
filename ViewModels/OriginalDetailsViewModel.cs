using StudentRegisteration.Models;

namespace StudentRegisteration.ViewModels
{
    public class OriginalDetailsViewModel
    {
        public User User { get; set; }
        public StudentDetails StudentDetails { get; set; }
        public List<Registeration> Registerations { get; set; }
    }
}
