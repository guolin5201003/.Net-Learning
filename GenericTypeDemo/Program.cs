using System.ComponentModel.DataAnnotations;

namespace GenericTypeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NonGenericTest();

            //GenericTest();

            //DocumentManagerTest();

            //OtherTest();

            //var r = new Rectangle();
            //Display(r);

            //Convariant();

            //Nullable<int> x;           
            //x = 4;

            //int y;
            //y = (int)x;

            var accounts = new List<Account>
            {
                new Account { Name = "123456", Balance = 1000 },
                new Account { Name = "654321", Balance = 2000 },
            };

            var sum = Algorithm.Accumulate<Account>(accounts);
            var sum1 = Algorithm.Accumulate(accounts);//自动识别 <Account>

            var sum2 = Algorithm.AccumulateLambda<Account, decimal>(accounts, (item, total) => total = item.Balance + total);

            Console.ReadKey();
        }

        private static void Convariant()
        {
            IConvariant<Derived> convariant = new CovariantDemo();
            var demo = convariant.GetValue();

            IContravariant<Derived> contravariant = new ContravariantDemo();
            contravariant.SetValue(new Derived());

            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangles();
            IIndex<Shape> shapes = rectangles;// Covariant
            for (int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine(shapes[i].ToString());
            }

            IDisplay<Shape> display = new ShapeDisplay();
            IDisplay<Rectangle> displayRectangle = display;
            displayRectangle.Display(rectangles[0]);
        }

        //private static void Display(Shape shape)
        //{
        //    Console.WriteLine(shape.Name);
        //}

        private static void OtherTest()
        {
            StaticDemo<int>.x = 10;
            StaticDemo<string>.x = 20;
            Console.WriteLine(StaticDemo<int>.x);
            Console.WriteLine(StaticDemo<string>.x);
            Console.WriteLine(StaticDemo<long>.x);
        }

        private static void DocumentManagerTest()
        {
            DocumentManager<Document> manager = new DocumentManager<Document>();
            manager.AddDocument(new Document("doc1", "content1"));
            manager.AddDocument(new Document("doc2", "content2"));
            manager.AddDocument(new Document("doc3", "content3"));

            manager.DisplayAllDocuments();

            if (manager.IsDocumentAvailable)
            {
                Document d = manager.GetDocument();
                Console.WriteLine(d.Content);
            }
        }

        public static void GenericTest<T>(T item)
        {
            Console.WriteLine(item);
        }
        private static void GenericTest()
        {
            var list = new LinkedNodeList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            var list2 = new LinkedNodeList<string>();
            list2.AddLast("string1");
            list2.AddLast("string2");
            list2.AddLast("string3");

            foreach (string item in list2)
            {
                Console.WriteLine(item);
            }
        }

        private static void NonGenericTest()
        {
            var list = new LinkedNodeList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast("string");

            foreach (int item in list)//cast exception when enumerate string.
            {
                Console.WriteLine(item);
            }
        }
    }
}
