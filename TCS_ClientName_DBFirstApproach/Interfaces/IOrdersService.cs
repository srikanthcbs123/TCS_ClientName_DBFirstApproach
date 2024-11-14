﻿using TCS_ClientName_DBFirstApproach;


namespace TCS_ClientName_DBFirstApproach
{
    public interface IOrdersService
    {
        Task<List<OrdersDto>> GetOrders();
        Task<OrdersDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrdersDto orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(OrdersDto orderdetail);
    }
}
