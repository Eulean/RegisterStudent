namespace StudentRegisteration.Models;


public class Address
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Town { get; set; }
    public string State { get; set; }

    public List<User> Users { get; set; }
}