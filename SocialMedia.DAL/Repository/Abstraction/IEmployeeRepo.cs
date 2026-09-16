using SocialMedia.DAL.Entities;

namespace SocialMedia.DAL.Repository.Abstraction
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        void SaveChanges();
    }
}
