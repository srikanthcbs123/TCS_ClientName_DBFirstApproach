
using Microsoft.EntityFrameworkCore;
using TCS_ClientName_DBFirstApproach;
using TCS_ClientName_DBFirstApproach.DBConnect;

namespace TCS_ClineName_CodeFirstApproach.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly MidlandContext _midlandContext;
        public OrdersRepository(MidlandContext midlandContext)
        {
            _midlandContext = midlandContext;
        }
        public async Task<int> AddOrder(Order orderdetail)
        {
            await _midlandContext.Orders.AddAsync(orderdetail);//add the record by using addasync
            _midlandContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            Order rm = _midlandContext.Orders.SingleOrDefault(e => e.Orderid == orderid);
            if (rm != null)
            {//Here Remove() method is used for removing the data from database.

                _midlandContext.Orders.Remove(rm);
                _midlandContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<Order> GetOrderById(int orderid)
        {
            var rm = await _midlandContext.Orders.Where(e => e.Orderid == orderid).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<List<Order>> GetOrders()
        {
            var result = _midlandContext.Orders.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async  Task<bool> UpdateOrder(Order orderdetail)
        {
            _midlandContext.Update(orderdetail);
            await _midlandContext.SaveChangesAsync();
            return true;
        }
    }
}
