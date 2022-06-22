using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0405test
{
    class A
    {
        public int n;
        public A()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public B(int n)
        {
            this.n = n;
            Console.WriteLine("B");
        }
        public void X()
        {
            Console.WriteLine("n : "+n);
        }
    }
    class Program
    {
        static void Main(String[] args)
        {
            B b = new B(99);
            b.X();
        }
    }
   }

