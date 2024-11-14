
using TCS_ClientName_DBFirstApproach.DBConnect;


namespace TCS_ClientName_DBFirstApproach
{
    public class OrdersService:IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<int> AddOrder(OrdersDto orderdetail)
        {
            Order order = new Order();
            order.Orderid = orderdetail.orderid;
            order.Ordername = orderdetail.ordername;
            order.Orderlocation = orderdetail.orderlocation;

            var res = await _ordersRepository.AddOrder(order);
            return res;

        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            await _ordersRepository.DeleteOrderById(orderid);
            return true;
        }

        public async Task<OrdersDto> GetOrderById(int orderid)
        {
            var res = await _ordersRepository.GetOrderById(orderid);
            OrdersDto orderdto = new OrdersDto();
            orderdto.orderid = res.Orderid;
            orderdto.ordername = res.Ordername;
            orderdto.orderlocation = res.Orderlocation;
            return orderdto;
        }

        public async Task<List<OrdersDto>> GetOrders()
        {
            List<OrdersDto> lstorderdto = new List<OrdersDto>();
            var res = await _ordersRepository.GetOrders();
            foreach (Order order in res)
            {
                OrdersDto ordersDto = new OrdersDto();
                ordersDto.orderid = order.Orderid;
                ordersDto.ordername = order.Ordername;
                ordersDto.orderlocation = order.Orderlocation;
                lstorderdto.Add(ordersDto);//Add the orders to list here

            }
            return lstorderdto;
        }

        public async Task<bool> UpdateOrder(OrdersDto orderdetail)
        {
            Order obj = new Order();
            obj.Orderid = orderdetail.orderid;
            obj.Ordername = orderdetail.ordername;
            obj.Orderlocation = orderdetail.orderlocation;
            await _ordersRepository.UpdateOrder(obj);
            return true;
        }
    }
}

