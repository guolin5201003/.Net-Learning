using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeDemo
{
    public class Base { }
    public class Derived : Base { }

    public interface IConvariant<out T>
    {
        T GetValue();
    }

    public class CovariantDemo : IConvariant<Derived>
    {
        public Derived GetValue()
        {
            return new Derived();
        }

    }

    public interface IContravariant<in T>
    {
        public void SetValue(T value);
    }

    public class ContravariantDemo : IContravariant<Base>
    {
        public void SetValue(Base value)
        {
            
        }
    }

    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString()
        {
            return $"Width: {Width}, Height: {Height}";
        }
    }
    public class Rectangle : Shape
    { }
    public interface IIndex<out T>//协变
    {
        T this[int index] { get; }
        int Count { get; }
    }

    public class RectangleCollection : IIndex<Rectangle>
    {
        private Rectangle[] rectangles = new Rectangle[3]
        {
            new Rectangle {Width=1,Height=2},
            new Rectangle {Width=2,Height=3},
            new Rectangle {Width=3,Height=4}
        };

        private static RectangleCollection coll;
        public static RectangleCollection GetRectangles()
        {
            return coll ?? (coll = new RectangleCollection());
        }

        public Rectangle this[int index]
        {
            get { 
                if (index >= 0 && index < rectangles.Length)
                return rectangles[index];

                throw new ArgumentOutOfRangeException("index");
            }
        }

        public int Count
        {
            get { return rectangles.Length; }
        }
    }

    public interface IDisplay<in T>
    {
        void Display(T value);
    }

    public class ShapeDisplay : IDisplay<Shape>
    {
        public void Display(Shape value)
        {
            Console.WriteLine(value.ToString());
        }

    }

}
