using System;
using System.Runtime.InteropServices;

namespace WrapperDotnet
{
    public class Wrapper
    {
        [DllImport("Add.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int add(int a, int b);
        public int CallAdd()
        {
            var res = add(3, 5);
            Console.WriteLine("res");
            return res;
        }
    }
}
