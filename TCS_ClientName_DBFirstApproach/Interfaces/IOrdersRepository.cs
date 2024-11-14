

using TCS_ClientName_DBFirstApproach.DBConnect;


namespace TCS_ClientName_DBFirstApproach
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int orderid);
        Task<int> AddOrder(Order orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(Order orderdetail);
    }
}
