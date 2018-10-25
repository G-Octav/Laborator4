using System.Collections.Generic;
using System.Linq;

namespace LaboratorNET2.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ApplicationContext _applicationContext;

        public EmployeeRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Create(Employee creationModel)
        {
            _applicationContext.Employees.Add(creationModel);
            _applicationContext.SaveChanges();
        }

        public void Update(int id, Employee updateModel)
        {
            _applicationContext.Entry(updateModel).State = System.Data.Entity.EntityState.Modified;
            _applicationContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeToDelete = _applicationContext.Employees.FirstOrDefault(c => c.Id == id);

            if (employeeToDelete != null)
            {
                _applicationContext.Employees.Remove(employeeToDelete);
                _applicationContext.SaveChanges();
            }
        }

        public Employee GetById(int id)
        {
            var employee = _applicationContext.Employees.FirstOrDefault(c => c.Id == id);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _applicationContext.Employees.AsEnumerable();
        }
    }
}