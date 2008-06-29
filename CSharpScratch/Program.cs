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

		static void Main(string[] args)
		{
			Boom.RaiseEvent(null, EventArgs.Empty);
			Boom += CatchBoom;
			Boom.RaiseEvent(null, EventArgs.Empty);
		}

		static void CatchBoom(object sender, EventArgs e)
		{
			Console.WriteLine("Yea!");
		}

	}
}
