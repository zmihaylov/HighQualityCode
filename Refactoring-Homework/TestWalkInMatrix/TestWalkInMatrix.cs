namespace Task3
{
    using System;
    using WalkInMatrix;


    public class TestWalkInMatrica
    {
        static void Main()
        {
            Matrix matrix = new Matrix(6);
            matrix.Walk();
            Console.WriteLine(matrix);
        }
    }
}
