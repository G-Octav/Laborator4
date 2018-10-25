using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LaboratorNET2.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ApplicationContext _applicationContext;

        public CustomerRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Create(Customer creationModel)
        {
            _applicationContext.Customers.Add(creationModel);
            _applicationContext.SaveChanges();
        }

        public void Update(int id, Customer updateModel)
        {
            _applicationContext.Entry(updateModel).State = System.Data.Entity.EntityState.Modified;
            _applicationContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customerToDelete = _applicationContext.Customers.FirstOrDefault(c => c.Id == id);

            if (customerToDelete != null)
            {
                _applicationContext.Customers.Remove(customerToDelete);
                _applicationContext.SaveChanges();
            }
        }

        public Customer GetById(int id)
        {
            var customer = _applicationContext.Customers.FirstOrDefault(c => c.Id == id);

            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _applicationContext.Customers.AsEnumerable();
        }
    }
}
