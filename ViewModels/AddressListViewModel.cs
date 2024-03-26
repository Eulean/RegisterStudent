using StudentRegisteration.Models;

namespace StudentRegisteration.ViewModels;

public class AddressListViewModel
{
    public IEnumerable<Address> Addresses { get; set; }
    public bool ShowFullList { get; set; }
}