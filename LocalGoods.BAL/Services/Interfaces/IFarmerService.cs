using LocalGoods.BAL.DTOs.FarmerDTO;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IFarmerService
    {
        Task<CreateFarmerDTO> Create(CreateFarmerDTO farmer);
        Task<FarmerDTO> Get(int id);
        Task<FarmerDTO> Update(FarmerDTO farmer);
        Task<bool> Delete(int id);
        Task<List<FarmerDTO>> GetAll();

    }
}
