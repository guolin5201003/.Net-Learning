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

            //stService();

            var dbContext = new EFCoreDBContext();
            var unitOfWork = new UnitOfWork(dbContext);
            var OrderSvc = new OrderService(unitOfWork, new GenericRepository<Customer>(dbContext));

            var products = new List<ProductDTO>();

            var product1 = new ProductDTO
            {
                Id = 1,
                Price = 999.9900m
            };
            var product2 = new ProductDTO
            {
                Id = 2,
                Price = 1499.9900m
            };
            products.Add(product1);
            products.Add(product2);

            OrderSvc.AddOrderWithOrderItems(1, products);

            get方法 要用DTO
        }

        private static void TestService()
        {
            var dbContext = new EFCoreDBContext();
            var unitOfWork = new UnitOfWork(dbContext);
            var OrderSvc = new OrderService(unitOfWork, new GenericRepository<Customer>(dbContext));

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
