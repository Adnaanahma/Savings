using Arch.EntityFrameworkCore.UnitOfWork;
using Savings.Model.Entity;
using Savings.Model.ViewModel;
using Savings.Service.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
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
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Now,


                };
                _unitOfWork.GetRepository<User>().Insert(newProfile);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse { Message = "User Created Successfully", Status = true };
            
            }
            else return new BaseResponse { Message ="User Already Exist", Status = false };

        }
        /// <summary>
        /// "Hashing password"
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public (string Hash, string Salt) HashPassword(string password)
        {
            // Generate a random salt
            var saltBytes = new byte[16];
            using (var rng = new RSACryptoServiceProvider())
            {
                rng.GetType();
            }
            var salt = Convert.ToBase64String(saltBytes);

            // Combine password and salt
            var saltedPassword = password + salt;

            // Hash the combined password and salt
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                var hash = Convert.ToBase64String(bytes);
                return (Hash: hash, Salt: salt);
            }
        }
        /// <summary>
        /// "Verify password"
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string salt, string hash)
        {
            var saltedPassword = password + salt;
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                var newHash = Convert.ToBase64String(bytes);
                return newHash == hash;
            }
        }

        /// <summary>
        /// "Update User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateUser(UpdateUserViewModel model)
        {
            var user =  await _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.EmailAddress == model.EmailAddress,null,null,false);
            if (user != null)
            {
                var newUser = new User
                {
                    FirstName = String.IsNullOrEmpty(model.FirstName) ? user.FirstName : model.FirstName,
                    LastName = String.IsNullOrEmpty(model.LastName) ? user.LastName : model.LastName,
                    Address = String.IsNullOrEmpty(model.Address) ? user.Address : model.Address,
                   
                    
                };
                _unitOfWork.GetRepository<User>().Insert(newUser);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse { Message = "User Updated Successfully", Status = true };
            }

            else return new BaseResponse { Message = "User Does Not Exist ", Status = false };
        }
       
        /// <summary>
        /// "Update PhoneNumber"
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdatePhoneNumber(string PhoneNumber)
        {
            var user = await _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(x => x.PhoneNumber == PhoneNumber, null, null, false);
            if (user != null)
            {
                var newUser = new User
                {
                    PhoneNumber = String.IsNullOrEmpty(PhoneNumber) ? user.PhoneNumber : PhoneNumber,
                };

                _unitOfWork.GetRepository<User>().Insert(newUser);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse { Message = "PhoneNumber Updated Successfully", Status = true };
            }
            return null;

        }


        /// <summary>
        /// "Get By Id"
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





    }
}
