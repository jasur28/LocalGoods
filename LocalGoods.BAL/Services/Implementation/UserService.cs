using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.DTOs.UserDTO;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Operations;
using System.Reflection.Metadata.Ecma335;

namespace LocalGoods.BAL.Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<CreateUserDTO> Create(CreateUserDTO UserDTO)
        {
            var User = new User()
            {
                FirstName = UserDTO.FirstName,
                LastName = UserDTO.LastName,
                Email = UserDTO.Email,
                TelePhone = UserDTO.TelePhone,
                RoleId=UserDTO.RoleId
            };
            await userRepository.Create(User);
            return UserDTO;

        }

        public async Task<bool> Delete(UserDTO UserDTO)
        {
            var User = await userRepository.GetById(UserDTO.Id);
            return await userRepository.Delete(User);

        }

        public async Task<UserDTO> Get(int id)
        {
            var User = await userRepository.GetById(id);

            if (User.Id != null)
            {
                UserDTO UserDTO = new()
                {
                    Id = User.Id,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Email = User.Email,
                    TelePhone = User.TelePhone,
                    RoleId=User.RoleId
                };
                return UserDTO;
            }

            return null;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            //List<UserDTO> UserDTOs = new List<UserDTO>();
            IEnumerable<User> Users = await userRepository.GetAll();
            var UsersList = Users.Select(f => new UserDTO
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
                Email = f.Email,
                TelePhone = f.TelePhone,
                RoleId = f.RoleId
            }).ToList();
            return UsersList;
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = await userRepository.GetById(userDTO.Id);
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.TelePhone = userDTO.TelePhone;
            user.RoleId = userDTO.RoleId;
            
            await userRepository.Update(user);

            return userDTO;

        }
        public async Task<(List<FarmDTO>,int)> GetFarms(int id)
        {
            List<FarmDTO> farmdtos = new();
            User? user = await userRepository.GetById(id);
            if (user == null)
            {
                return (farmdtos,0);
            }
            List<Farm> farms1 = await userRepository.GetFarms(id);
            foreach (Farm farm in farms1)
            {
                farmdtos.Add(new FarmDTO()
                {
                   Id=farm.Id,
                   Name=farm.Name,
                   Address=farm.Address,
                   Country=farm.Country,
                   City=farm.City,
                   Rating=farm.Rating,
                   Latitude=farm.Latitude,
                   Longitude=farm.Longitude,
                   Email=farm.Email,
                   FaceBook=farm.FaceBook,
                   Instagram=farm.Instagram,
                   Telephone=farm.Telephone,
                   UserId=farm.UserId
                });
            }
            return (farmdtos, 1);
        }
    }
}
