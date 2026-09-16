using SocialMedia.BLL.Helper;
using SocialMedia.BLL.ModelVM.EmployeeVM;
using SocialMedia.BLL.Services.Abstraction;
using SocialMedia.DAL.Entities;
using SocialMedia.DAL.Repository.Abstraction;

namespace SocialMedia.BLL.Services.Implementation
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo Repo;

        public EmployeeServices(IEmployeeRepo repo)
        {
            Repo = repo;
        }

        public List<GetAllEmployeeVM> GetAll()
        {
            return Repo.GetAll()
                .Select(entity => new GetAllEmployeeVM
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Age = entity.Age,
                    ImagePath = entity.ImagePath
                }).ToList();
        }

        public EditEmployeeVM? GetForEdit(int id)
        {
            var entity = Repo.GetById(id);
            if (entity == null)
            {
                return null;
            }

            return new EditEmployeeVM
            {
                Id = entity.Id,
                Name = entity.Name,
                Age = entity.Age
            };
        }

        public bool Create(CreateEmployeeVM vm)
        {
            string? imagePath = null;
            if (vm.Image != null)
            {
                imagePath = Upload.UploadFile("Files", vm.Image);
            }

            var entity = new Employee
            {
                Name = vm.Name,
                Age = vm.Age,
                ImagePath = imagePath
            };

            Repo.Add(entity);
            Repo.SaveChanges();
            return true;
        }

        public bool Edit(EditEmployeeVM vm)
        {
            var entity = Repo.GetById(vm.Id);
            if (entity == null)
            {
                return false;
            }

            entity.Name = vm.Name;
            entity.Age = vm.Age;

            Repo.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = Repo.GetById(id);
            if (entity == null)
            {
                return false;
            }

            Repo.Delete(entity);
            Repo.SaveChanges();
            return true;
        }
    }
}