using Savings.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Savings.Service.Interfaces
{
    public  interface IUserService
    {

        Task<BaseResponse> SignUpUser(SignUpModel model);
        Task<BaseResponse> UpdateUser(UpdateUserViewModel model);
        Task<BaseResponse> ProfileEdit(ProfileEditViewModel model);
        Task<BaseResponse> GetById(Guid id);
        Task<bool> DeactivateUser(Guid Id);
        Task<bool> ActivateUser(Guid Id);
        Task<BaseResponse> DeleteUser(Guid id);
    }
}
