namespace GenericTypeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NonGenericTest();

            GenericTest();

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
