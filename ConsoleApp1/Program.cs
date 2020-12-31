using System;
using System.Runtime.InteropServices;
using WrapperDotnet;

namespace ConsoleApp1
{
    public class Program
    {
        //[DllImport("Add.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int add(int a, int b);
        public static  void  Main()
        {
            var wrapper = new Wrapper();
            wrapper.CallAdd();
            //var res = add(3, 5);
            Console.WriteLine("res"); ;
        }
    }
}
