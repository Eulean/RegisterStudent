using StudentRegisteration.Data;
using StudentRegisteration.Interfaces;
using StudentRegisteration.Models;

namespace StudentRegisteration.Services;


public class AddressServices : IAddressService
{
    private readonly ApplicationDbContext _context;

    public AddressServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Address> GetAllAddresses()
    {
        return _context.addresses.ToList();
    }

    public IEnumerable<Address> SearchAddresses(string searchString)
    {
        if(string.IsNullOrEmpty(searchString))
        {
            return GetAllAddresses();
        }

        return _context.addresses.Where( a => 
            a.City.ToLower().Contains(searchString.ToLower()) ||
            a.State.ToLower().Contains(searchString.ToLower()) ||
            a.Town.ToLower().Contains(searchString.ToLower()) ||
            a.Id.ToString().Contains(searchString)
        );
    }

    public async Task<Address> GetAddressById(int id)
    {
        return await _context.addresses.FindAsync(id);
    }

    public void CreateAddress(Address address)
    {
        _context.addresses.Add(address);
        _context.SaveChanges();
    }

    public async Task UpdateAddress(Address address)
    {
        _context.addresses.Update(address);
        _context.SaveChanges();
    }

    public async Task DeleteAddress(int id)
    {
        var address = _context.addresses.Find(id);
        if(address != null)
        {
            _context.addresses.Remove(address);
            _context.SaveChanges();
        }
    }
}
