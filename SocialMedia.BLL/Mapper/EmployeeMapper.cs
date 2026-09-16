using AutoMapper;
using SocialMedia.BLL.ModelVM.EmployeeVM;
using SocialMedia.DAL.Entities;

namespace SocialMedia.BLL.Mapper
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<CreateEmployeeVM, Employee>()
                .ForMember(dest => dest.ImagePath, opt => opt.Ignore()).ReverseMap();
        }
    }
}