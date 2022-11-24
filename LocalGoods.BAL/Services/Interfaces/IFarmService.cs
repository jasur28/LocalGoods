﻿using LocalGoods.DAL.Models;
using LocalGoods.BAL.DTOs;


namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IFarmService
    {
        Task<FarmDTO> Create(FarmDTO farm);
        Task<FarmDTO> Get(int id);
        Task<FarmDTO> Update(FarmDTO farm);
        Task<bool> Delete(int id);
        Task<List<FarmDTO>> GetAll();
    }
}
