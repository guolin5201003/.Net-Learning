using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Repository.Application;
using Repository.Domain.Models;
using Repository.Infrastucture;
using Microsoft.Extensions.Configuration.Json;
using Repository.IoC;

namespace RepoisitoryUnitOfWorkDemo
{
    internal class Program
    {
        public static string ConnectionString { get; set; }
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ConnectionString = configuration.GetConnectionString("MyConnectionString2");

            //TestRepository();
            //TestUnitOfWork();
            //TestService();
            //TestServiceUseDTO();

            TestDepandencyInjection();

        }

        private static void TestDepandencyInjection()
        {
            GetCustomerById();

            //var order = AddOrder();

            //DeleteOrder(order);

            UpdateOrder();
        }

        private static void UpdateOrder()
        {
            var OrderSvc = DependancyInjection.Resolve<OrderService>();

            var order1 = OrderSvc.GetOrderWithItems(30002);
            order1.Description = $"Updated description {DateTime.Now}";
            order1.OrderItems.ForEach(o => o.Description = $"Updated description {DateTime.Now}");
            OrderSvc.UpdateOrder(order1);
        }

        private static int DeleteOrder(OrderDTO order)
        {
            var OrderSvc = DependancyInjection.Resolve<OrderService>();
            return OrderSvc.DeleteOrder(order);
        }

        private static OrderDTO AddOrder()
        {
            var OrderdSvc = DependancyInjection.Resolve<OrderService>();
            var createDate = DateTime.Now;
            var order = new OrderDTO
            {
                CustomerId = 1,
                CreateDate = createDate,
            };
            //TODO: should add ProductSvc to get the products info.
            var orderItems = new List<OrderItemDTO>
            {
                new OrderItemDTO
                {
                    ProductId = 10,
                    Price = 29.99m,
                    CreateDate = createDate
                },
                new OrderItemDTO
                {
                    ProductId = 9,
                    Price = 79.99m,
                    CreateDate = createDate
                }
            };

            order.OrderItems.AddRange(orderItems);
            return OrderdSvc.AddOrder(order);
        }

        private static void GetCustomerById()
        {
            var OrderSvc = DependancyInjection.Resolve<OrderService>();
            var customer = OrderSvc.GetCustomerById(1);
        }

        private static void TestServiceUseDTO()
        {
            //var dbContext = new EFCoreDBContext(ConnectionString);

            //var unitOfWork = new UnitOfWork(dbContext);
            //var OrderSvc = new OrderService(unitOfWork, new GenericRepository<Customer>(dbContext));

            var OrderSvc = DependancyInjection.Resolve<OrderService>();
            

            var order = OrderSvc.GetOrder(1);

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
        }

        //private static void TestService()
        //{
        //    var dbContext = new EFCoreDBContext();
        //    var unitOfWork = new UnitOfWork(dbContext);
        //    var OrderSvc = new OrderService(unitOfWork, new GenericRepository<Customer>(dbContext));

        //    var customer = new GenericRepository<Customer>(dbContext).Get(4);
        //    var products = new List<Product>();
        //    var productRepo = new GenericRepository<Product>(dbContext);
        //    products.Add(productRepo.Get(1));
        //    products.Add(productRepo.Get(2));
        //    products.Add(productRepo.Get(3));

        //    //OrderSvc.AddOrderWithOrderItems(customer, products);
        //}

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
