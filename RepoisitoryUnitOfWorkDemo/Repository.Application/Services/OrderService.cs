using AutoMapper;
using Repository.Domain.Models;
using Repository.Infrastucture;
using System.Reflection.Emit;

namespace Repository.Application
{
    public class OrderService
    {
        private readonly UnitOfWork unitOfWork;
        private IRepository<Customer> customerRepo;
        private readonly IRepository<Order> orderRepo;
        private IMapper mapper;

        public OrderService(UnitOfWork unitOfWork, IRepository<Customer> customerRepo, IRepository<Order> orderRepo) 
        {
            this.unitOfWork = unitOfWork;
            this.customerRepo = customerRepo;
            this.orderRepo = orderRepo;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>(); // 添加你的 Profile 类  
            });

            mapper = config.CreateMapper(); // 创建 IMapper 实例  
        }

        public CustomerDTO GetCustomerById(long customerId)
        {
            var customer = customerRepo.Get(customerId, "Orders");//TODO: HardCode here.
            return mapper.Map<CustomerDTO>(customer);

        }

        public OrderDTO AddOrder(OrderDTO orderDTO)
        {
            var order = mapper.Map<Order>(orderDTO);
            var orderInDB = orderRepo.AddToDB(order);
            return mapper.Map<OrderDTO>(orderInDB);
        }

        public int DeleteOrder(OrderDTO orderDTO)
        {
            var order = mapper.Map<Order>(orderDTO);
            return orderRepo.DeleteToDB(order);
        }

        public int UpdateOrder(OrderDTO orderDTO)
        {
            var order = mapper.Map<Order>(orderDTO);
            return orderRepo.UpdateToDB(order);
        }


        public OrderDTO GetOrderWithItems(long id)
        {
            var order = orderRepo.Get(id, "OrderItems");//TODO: HardCode here.
            return mapper.Map<OrderDTO>(order);
        }


        //public void AddOrderWithOrderItems(Customer customer,List<Product> products)
        //{
        //    if (products == null || customer == null)
        //    {
        //        return;
        //    }

        //    var createDate = DateTime.Now;
        //    var orderItems = new List<OrderItem>();
        //    foreach (var product in products)
        //    {
        //        var orderItem = new OrderItem()
        //        {
        //            CreateDate = createDate,
        //            ProductId = product.Id,
        //            Price = product.Price,
        //        };
        //        orderItems.Add(orderItem);
        //    }

        //    try
        //    {
        //        unitOfWork.BeginTransaction();
        //        var order = new Order
        //        {
        //            CreateDate = DateTime.Now,
        //            CustomerId = customer.Id,
        //            TotalPrice = orderItems.Sum(o => o.Price),
        //        };

        //        unitOfWork.OrderRepo.Add(order);
        //        unitOfWork.Save();

        //        foreach (var item in orderItems)
        //        {
        //            item.OrderId = order.Id;
        //            unitOfWork.OrderItemRepo.Add(item);
        //        }
        //        unitOfWork.Save();
        //        unitOfWork.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        unitOfWork.Rollback();
        //    }

        //}

        public void AddOrderWithOrderItems(long customerId, List<ProductDTO> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException();
            }

            if (customerRepo.Get(customerId) == null)
            {
                throw new Exception("Cannot find Customer!");
            }

            var createDate = DateTime.Now;
            var orderItems = new List<OrderItem>();
            foreach (var product in products)
            {
                var orderItem = new OrderItem()
                {
                    CreateDate = createDate,
                    ProductId = product.Id,
                    Price = product.Price,
                };
                orderItems.Add(orderItem);
            }

            try
            {

                unitOfWork.BeginTransaction();
                var order = new Order
                {
                    CreateDate = DateTime.Now,
                    CustomerId = customerId,
                    TotalPrice = orderItems.Sum(o => o.Price),
                };

                unitOfWork.OrderRepo.Add(order);
                unitOfWork.Save();

                foreach (var item in orderItems)
                {
                    item.OrderId = order.Id;
                    unitOfWork.OrderItemRepo.Add(item);
                }
                unitOfWork.Save();
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
            }

        }

        public OrderDTO GetOrder(long orderId)
        {
            var order = unitOfWork.OrderRepo.Get(orderId);
            var orderDTO = mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

    }
}
