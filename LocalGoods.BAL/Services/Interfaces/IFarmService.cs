using LocalGoods.DAL.Models;


namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IFarmService
    {
        Task<Farm> AddFarm(Farm farm);
        Task<Farm> GetFarm(Farm farm);
        Task<Farm> UpdateFarm(Farm farm);
        Task<Farm> DeleteFarm(Farm farm);
    }
}
