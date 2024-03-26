using StudentRegisteration.Models;
using System.Text.Json.Serialization;

namespace StudentRegisteration.ViewModels
{
    public class DetailsViewModel
    {
       
        public StudentDetails StudentDetails { get; set; }
        public List<Registeration> Registerations { get; set; }
        // public User User { get; set; }

        public Address Address { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public DetailsViewModel()
        {
            
        }

        public DetailsViewModel(StudentDetails studentDetails, string userName = null, string userEmail = null)
        {
            StudentDetails = studentDetails;
            UserName = userName;
            UserEmail = userEmail;
        }
    }
}
