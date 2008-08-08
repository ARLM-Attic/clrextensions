using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClrExtensions;
using ClrExtensions.Win32.Http;
using ClrExtensions.System.Collections;

namespace CSharpScratch
{
	class Program
	{
		static void Main(string[] args)
		{

			//var result = new List<object[]> { { "foo", 1 }, { "bar", 2 }, { "baz", 3 } };
			var x = new object[,] { { "foo", 1 }, { "bar", 2 }, { "baz", 3 } };

			var y = new Dictionary<string, int>() { { "foo", 1 }, { "bar", 2 }, { "baz", 3 } };
			var z = new Dictionary<string, int, bool>() { { "foo", 1, true }, { "bar", 2, false }, { "baz", 3, true } };
			//var result = new CustomerList() { { "Tom", "Jones", 19}, { "Mary", "More", 36}, { "Frank", "Brown", 37} };

			//System.Data.DataTable x;
		

			//var arr = new String[3, 3];


			//arr[0, 0] = "Carl";
			//arr[1, 0] = "Adam";
			//arr[2, 0] = "Scott";
			//arr[0, 1] = "Fred";
			//arr[1, 1] = "Louis";
			//arr[2, 1] = "Bob";
			//arr[0, 2] = "Simon";
			//arr[1, 2] = "Joe";
			//arr[2, 2] = "Bill";

			////var sorted = arr.SortByColumn(0);

			//for (var i = 0; i < 3; i++)
			//{
			//    for (var j = 0; j < 3; j++)
			//    {
			//        Console.Write(sorted[i, j] + ' ');
			//    } Console.WriteLine();
			//}
			//Console.ReadLine();
		}
	}


	class MyCollection : ICollection<String>
	{
		private readonly List<String> m_BaseList;

		MyCollection(int capacity)
		{
			m_BaseList = new List<string>(capacity);
		}

		#region ICollection<string> Members

		public void Add(string item)
		{
			m_BaseList.Add(item);
		}

		public void Clear()
		{
			m_BaseList.Clear();
		}

		public bool Contains(string item)
		{
			return m_BaseList.Contains(item);
		}

		public void CopyTo(string[] array, int arrayIndex)
		{
			m_BaseList.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return m_BaseList.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(string item)
		{
			return m_BaseList.Remove(item);
		}

		#endregion

		#region IEnumerable<string> Members

		public IEnumerator<string> GetEnumerator()
		{
			return m_BaseList.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return m_BaseList.GetEnumerator();
		}

		#endregion
	}
}
