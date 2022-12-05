using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.DTOs.UserDTO;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserDTO> Create(CreateUserDTO farmer);
        Task<UserDTO> Get(int id);
        Task<UserDTO> Update(UserDTO farmer);
        Task<bool> Delete(UserDTO farmer);
        Task<List<UserDTO>> GetAll();
        Task<List<FarmDTO>> GetFarms(int id);

    }
}
