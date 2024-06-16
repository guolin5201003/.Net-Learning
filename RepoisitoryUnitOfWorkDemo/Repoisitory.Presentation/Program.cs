using Repository.Application;
using Repository.Domain.Models;
using Repository.Infrastucture;

namespace RepoisitoryUnitOfWorkDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestRepository();

            //TestUnitOfWork();

            var dbContext = new EFCoreDBContext();
            var unitOfWork = new UnitOfWork(dbContext);
            var OrderSvc = new OrderService(unitOfWork);

            var customer = new GenericRepository<Customer>(dbContext).Get(4);
            var products = new List<Product>();
            var productRepo = new GenericRepository<Product>(dbContext);
            products.Add(productRepo.Get(1));
            products.Add(productRepo.Get(2));
            products.Add(productRepo.Get(3));

            OrderSvc.AddOrderWithOrderItems(customer, products);
            
        }

        private static void TestUnitOfWork()
        {
            var unitOfWork = new UnitOfWork(new EFCoreDBContext());
            var orderItems = unitOfWork.OrderItemRepo.GetAll();

            var newOrderItem = new OrderItem
            {
                CreateDate = DateTime.Now,
                OrderId = 1,
                ProductId = 1,
            };
            unitOfWork.OrderItemRepo.Add(newOrderItem);
            unitOfWork.Save();

            newOrderItem.OrderId = 2;
            unitOfWork.Save();

            unitOfWork.OrderItemRepo.Delete(newOrderItem);
            unitOfWork.Save();
        }

        private static void TestRepository()
        {
            var repository = new GenericRepository<Order>(new EFCoreDBContext());
            var order = repository.Get(1);
            var orderList = repository.GetAll();

            var newOrder = repository.AddToDB(new Order { CustomerId = 1, CreateDate = DateTime.Now });
            newOrder.Description = "test update";
            repository.Update(newOrder);

            repository.Delete(newOrder);
        }
    }
}
