using System;

namespace Test
{
    class PassingRefByRef
    {
        static void Change(ref int[] pArray)
        {
            // Both of the following changes will affect the original variables:
            pArray[0] = 888;
            pArray = new int[5] { -3, -1, -2, -3, -4 };
            Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }

        static void Main()
        {
            int[] arr = { 1, 4, 5 };
            Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr[0]);

            Change(ref arr);
            Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr[0]);
            Console.ReadKey();
        }
    }
    /* Output:
        Inside Main, before calling the method, the first element is: 1
        Inside the method, the first element is: -3
        Inside Main, after calling the method, the first element is: -3
    */
}