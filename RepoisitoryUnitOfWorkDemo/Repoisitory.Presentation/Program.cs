using Repository.Domain.Models;
using Repository.Infrastucture;

namespace RepoisitoryUnitOfWorkDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestRepository();
        }

        private static void TestRepository()
        {
            var repository = new GenericRepository<Order>(new EFCoreDBContext());
            var order = repository.Get(1);
            var orderList = repository.GetAll();

            var newOrder = repository.Add(new Order { CustomerId = 1, CreateDate = DateTime.Now });
            newOrder.Description = "test update";
            repository.Update(newOrder);

            repository.Delete(newOrder);
        }
    }
}
