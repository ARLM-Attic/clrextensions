using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClrExtensions;

namespace CSharpScratch
{
	class Program
	{
		static EventHandler<EventArgs> Boom;


		static void commit() { }
		static void report_that_b_failed() { }
		static void report_that_a_failed() { }

		static void Main(string[] args)
		{
			var d = new Dictionary<int, int, Action>();
			d.Add(1, 1, Commit);
			d.Add(1, 0, report_that_b_failed);
			d.Add(0, 0, report_that_a_failed);

			var a = 1, b = 0;
			d[a, b].Invoke();



			X.Add(5, true, () => "Boom!");
			X.Add(5, false, () => "Splat!");
			X.Add(15, true, () => "Ka-Pow");

			Console.WriteLine(X[5, true].Invoke());
			Console.WriteLine(X[5, false].Invoke());
			Console.WriteLine(X[15, false].Invoke());


			//Boom.RaiseEvent(null, EventArgs.Empty);
			//Boom += CatchBoom;
			//Boom.RaiseEvent(null, EventArgs.Empty);
		}

		static void CatchBoom(object sender, EventArgs e)
		{
			Console.WriteLine("Yea!");
		}

	}
}
