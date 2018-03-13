using System;

namespace AbstractClass_Interface
{
	// Interfaces
	interface ITestInterface1 {
		//int a; -> data fields can't be decalred here.
		void Add(int a, int b);
	}
	interface ITestInterface2 : ITestInterface1 {
		void Sub(int a, int b);
	}
	interface ITestInterface3 {
		void Add(int a, int b);
		void Mul(int a, int b);
		void Div(int a, int b);
	}

	// Implemantation class
	class ImplementationClass : ITestInterface2, ITestInterface3
	{
		public void Add(int a, int b)
		{
			Console.WriteLine("Addition is :: " + (a + b));
		}

		void ITestInterface1.Add(int a, int b)
		{
			Console.WriteLine("From ITestInterface1.Add() :: " + (a + b));
		}

		void ITestInterface3.Add(int a, int b)
		{
			Console.WriteLine("From ITestInterface3.Add() :: " + (a + b));
		}

		public void Div(int a, int b)
		{
			Console.WriteLine("Division is :: " + (a / b));
		}

		public void Mul(int a, int b)
		{
			Console.WriteLine("Multiplication is :: " + (a * b));
		}

		public void Sub(int a, int b)
		{
			Console.WriteLine("Subtraction is :: " + (a - b));
		}
	}


	abstract class Figure {
		public double Width, Height, Radius;
		public const float PI = 3.14F;
		public abstract double GetArea();
	}

	class Rectangle : Figure {
		public Rectangle(double Width, double Height) {
			this.Width = Width;
			this.Height = Height;
		}
		public override double GetArea()
		{
			return Width * Height;

		}
	}

	class Circle : Figure {
		public Circle(double Radius) {
			this.Radius = Radius;
		}
		public override double GetArea()
		{
			return PI * Radius * Radius;
		}
	}

	class Cone : Figure {
		public Cone(double Radius, double Height) {
			this.Radius = Radius;
			this.Height = Height;
		}
		public override double GetArea()
		{
			return PI * Radius * (Radius + Math.Sqrt(Height * Height + Radius * Radius));
		}
	}
	class Triangle : Figure {
		public Triangle(double Width, double Height) {
			this.Width = Width;
			this.Height = Height;
		}
		public override double GetArea()
		{
			return (0.5) * Width * Height;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			ImplementationClass implementationClass = new ImplementationClass();
			implementationClass.Add(20,40);
			implementationClass.Sub(60, 40);
			implementationClass.Mul(80, 50);
			implementationClass.Div(100, 3);

			ITestInterface1 iReference1 = implementationClass;
			iReference1.Add(22, 66);

			ITestInterface3 iReference3 = new ImplementationClass();
			iReference3.Add(88, 88);

			Rectangle rectangle = new Rectangle(22.33, 12.22);
			Circle circle = new Circle(12.33);
			Cone cone = new Cone(33.2, 44.3);
			Triangle triangle = new Triangle(66.2, 12.3);

			Console.WriteLine("The area of Rectangle is :: {0}", rectangle.GetArea());
			Console.WriteLine("The area of Circle is    :: {0}", circle.GetArea());
			Console.WriteLine("The area of Cone is      :: {0}", cone.GetArea());
			Console.WriteLine("The area of Triangle is  :: {0}", triangle.GetArea());

			Console.Read();
		}
	}
}
