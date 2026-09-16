using SocialMedia.BLL.ModelVM.EmployeeVM;

namespace SocialMedia.BLL.Services.Abstraction
{
    public interface IEmployeeServices
    {
        List<GetAllEmployeeVM> GetAll();
        EditEmployeeVM? GetForEdit(int id);
        bool Create(CreateEmployeeVM vm);
        bool Edit(EditEmployeeVM vm);
        bool Delete(int id);
    }
}
