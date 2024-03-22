using StudentRegisteration.Models;
using System.Text.Json.Serialization;

namespace StudentRegisteration.ViewModels
{
    public class DetailsViewModel
    {
        [JsonIgnore]
        public StudentDetails StudentDetails { get; set; }
        public List<Registeration> Registerations { get; set; }
        public User User { get; set; }
    }
}
