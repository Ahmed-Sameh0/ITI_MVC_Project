using SocialMedia.DAL.DataBase;
using SocialMedia.DAL.Entities;
using SocialMedia.DAL.Repository.Abstraction;

namespace SocialMedia.DAL.Repository.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            return db.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            db.Employees.Update(employee);
        }

        public void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
