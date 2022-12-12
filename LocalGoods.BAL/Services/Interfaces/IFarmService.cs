using LocalGoods.BAL.DTOs;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IFarmService
    {
        Task<(FarmDTO,int)> Create(CreateFarmDTO farm,string name);
        Task<ViewFarmDTO?> Get(int id);
        Task<(FarmDTO,int)> Update(FarmDTO farm,string name);
        Task<int> Delete(int id);
        Task<List<ViewFarmDTO>> GetAll();
        Task<(List<ProductDTO>,int)> GetProducts(int id);
    }
}
