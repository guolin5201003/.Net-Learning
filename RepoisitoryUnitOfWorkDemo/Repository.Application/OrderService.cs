using Repository.Domain.Models;
using Repository.Infrastucture;

namespace Repository.Application
{
    public class OrderService
    {
        private readonly UnitOfWork unitOfWork;

        public OrderService(UnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddOrderWithOrderItems(Customer customer,List<Product> products)
        {
            if (products == null || customer == null)
            {
                return;
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
                    CustomerId = customer.Id,
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

    }
}
