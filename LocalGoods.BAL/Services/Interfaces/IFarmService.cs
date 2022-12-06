using LocalGoods.BAL.DTOs;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IFarmService
    {
        Task<(FarmDTO,int)> Create(FarmDTO farm);
        Task<FarmDTO?> Get(int id);
        Task<(FarmDTO,int)> Update(FarmDTO farm);
        Task<int> Delete(int id);
        Task<List<FarmDTO>> GetAll();
        Task<(List<ProductDTO>,int)> GetProducts(int id);
    }
}
