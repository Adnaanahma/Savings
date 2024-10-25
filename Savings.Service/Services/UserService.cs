using Arch.EntityFrameworkCore.UnitOfWork;
using Savings.Model.Entity;
using Savings.Model.ViewModel;
using Savings.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Savings.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        

     
        /// <summary>
        /// "Signup User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public async Task<BaseResponse> SignUpUser(SignUpModel model)
        {
            var profile = _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.EmailAddress == model.EmailAddress, null, null, false);
            // check if user exist
            if (profile == null)
            {
                var newProfile = new User
                {
                    Id = Guid.NewGuid(),
                    EmailAddress = model.EmailAddress,
                    Password = model.Password,
                    AccountType = model.AccountType,
                    CreatedDate = DateTime.Now,


                };
                _unitOfWork.GetRepository<User>().Insert(newProfile);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse { Message = "User Created Successfully", Status = true };
            
            }
            else return new BaseResponse { Message ="User Already Exist", Status = false };

        }
        /// <summary>
        /// "Update User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateUser(UpdateUserViewModel model)
        {
            var user =  _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.EmailAddress == model.EmailAddress,null,null,false);
            if (user != null)
            {
                var newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    Region = model.Region,
                    Country = model.Country,
                    
                };
                _unitOfWork.GetRepository<User>().Insert(newUser);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse { Message = "User Updated Successfully", Status = true };
            }

            else return null;
        }
        /// <summary>
        /// "Profile Edit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> ProfileEdit(ProfileEditViewModel model)
        {
            var profile = _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.Id == x.Id, null, null, false);
            if (profile != null)
            {
                var newProfile = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    Region = model.Region,
                    Country = model.Country,
                    UpdatedDate = DateTime.Now,
                };
                _unitOfWork.GetRepository<User>().Insert(newProfile);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Message = "User Updated Successfully", Status = true };
            }

            else return new BaseResponse { Message = "User Does Not Exist", Status = false };

        }

        /// <summary>
        /// "Get User"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> GetById(Guid id)
        {
            var profile = _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
            if (profile != null)
            {
                _unitOfWork.GetRepository<User>().Find(profile);
                await _unitOfWork.SaveChangesAsync();
            }
            return new BaseResponse { Message ="User Does Not Exist", Status = false };
        } 

       
        /// <summary>
        /// "Deactivate User"
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeactivateUser(Guid Id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.Id == Id,null,null,false);
            if (user != null)
            {
                user.IsActive = false;
                await _unitOfWork.SaveChangesAsync();
                return user.IsActive;
            }
          
            throw new Exception("User Not Found");

        }

        
        /// <summary>
        /// "Activate User"
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ActivateUser(Guid Id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.Id == Id, null, null, false);
            if (user != null)
            {
                user.IsActive = true;
                await _unitOfWork.SaveChangesAsync();
                return user.IsActive;
            }
         
            throw new Exception("User Not Found");

        }

        /// <summary>
        /// "Delete User"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteUser(Guid id)
        {
            var user = _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
            if (user != null)
            {
                _unitOfWork.GetRepository<User>().Delete(user);
                await _unitOfWork.SaveChangesAsync();
            }
            return new BaseResponse { Message = "User Does Not Exist", Status = false };
        }




    }
}
