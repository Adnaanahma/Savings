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
        (string Hash, string Salt) HashPassword(string password);
        bool VerifyPassword(string password, string salt, string hash);
        Task<BaseResponse> UpdateUser(UpdateUserViewModel model);
        Task<BaseResponse> UpdatePhoneNumber(string PhoneNumber);
        Task<BaseResponse> GetById(Guid id);
        Task<bool> DeactivateUser(Guid Id);
        Task<bool> ActivateUser(Guid Id);
     
    }
}
