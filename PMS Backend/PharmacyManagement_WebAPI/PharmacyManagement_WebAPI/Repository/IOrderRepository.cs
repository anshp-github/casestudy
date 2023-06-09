﻿using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<int> AddOrder(Order order);
        Task<List<Order>> GetOrdersReport(DateTime From, DateTime To);

        Task UpdateOrder(int id, Order order);
        Task<List<Order>> GetOrdersConfirmation();
    }
}
