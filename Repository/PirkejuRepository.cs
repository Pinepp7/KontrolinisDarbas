using KontrolinisDarbas.Contract;
using KontrolinisDarbas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Repository
{
    public class PirkejuRepository : IPirkejuDbRepository
    {
        private readonly AppDbContext _Context;
        public PirkejuRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task AtnaujantiPirkeja(Pirkejas pirkejas)
        {
            _Context.Pirkejas.Update(pirkejas);
            await _Context.SaveChangesAsync();
        }

        public async Task<Pirkejas> GautiPirkejaPagalId(int pirkejoId)
        {
            return await _Context.Pirkejas.FindAsync(pirkejoId);
        }

        public async Task<IEnumerable<Pirkejas>> GautiVisusPirkejus()
        {
            return await _Context.Pirkejas.ToListAsync();
        }

        public async Task IstrintiPirkeja(int pirkejoId)
        {
            var user = await _Context.Pirkejas.FindAsync(pirkejoId);
            if (user != null)
            {
                _Context.Pirkejas.Remove(user);
                await _Context.SaveChangesAsync();
            }
        }

        public async Task PridetiPirkeja(Pirkejas pirkejas)
        {
            _Context.Pirkejas.Add(pirkejas);
            await _Context.SaveChangesAsync();
        }
    }
}


//public async Task<int> AddCustomer(Customer customer)
//{
//    using (var context = new DBContext())
//    {
//        // Checking if customer with this first name and last name exists
//        bool customerExists = await context.Customers.AnyAsync(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName);

//        if (customerExists)
//        {
//            Console.WriteLine("Customer with this first name and last name already exists.");
//            return -1;
//        }

//        await context.Customers.AddAsync(customer);
//        await context.SaveChangesAsync();
//        Console.WriteLine("Customer added successfully.");
//        return customer.Id;
//    }
//}
