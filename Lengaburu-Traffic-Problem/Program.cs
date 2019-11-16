using System;

namespace Lengaburu_Traffic_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			var integerationTest = new IntegerationTest.IntegerationTest();
			integerationTest.MethodOne();
			integerationTest.MethodTwo();
			Console.Write("Press any key to exit");
			Console.ReadKey();
		}
	}
}
