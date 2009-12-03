using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ClrExtensions;
//using 

namespace Scratch_CSharp
{
    class Program
    {
         static void Main(string[] args)
        {
            var theLock = new  ReaderWriterLockSlim();
            IDisposable obj = null;

            using (theLock.ReadSection())
            {
                //code
            }
            

            try
            {
                obj = new Resource();
                //code
            }
            finally
            {
                if (obj != null) obj.Dispose();
            }

            using (obj = new Resource())
            {
                //code
            }



            try
            {
                theLock.EnterReadLock();
                //code
            }
            finally
            {
                theLock.ExitReadLock();
            }

            lock (theLock)
            {
                //code
            }
        }
    }
}
