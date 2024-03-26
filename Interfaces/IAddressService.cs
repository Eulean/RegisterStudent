using StudentRegisteration.Models;

namespace StudentRegisteration.Interfaces;

public interface IAddressService
{
    IEnumerable<Address> GetAllAddresses();
    IEnumerable<Address> SearchAddresses(string searchString);
    Task<Address> GetAddressById(int id);
    void CreateAddress(Address address);
    Task UpdateAddress(Address address);
    Task DeleteAddress(int id);
}