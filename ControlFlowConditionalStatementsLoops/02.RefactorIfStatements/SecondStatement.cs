using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactorIfStatements
{
    public class SecondStatement
    {
        public const int MinX = 100;
        public const int MaxX = 1000;
        public const int MinY = 200;
        public const int MaxY = 1000;

        public static void MoveCell(int x, int y, bool shouldVisitCell)
        {
            if (CheckCellValidity(x,y) && shouldVisitCell)
            {
                VisitCell(x, y);
            }
        }

        private static bool CheckCellValidity(int x, int y)
        {
            bool validX = SecondStatement.MinX <= x && x <= SecondStatement.MaxX;
            bool validY = SecondStatement.MinY <= y && y <= SecondStatement.MaxY;
            bool isValidCell = validX && validY;
            return isValidCell;
        }

        private static void VisitCell(int x, int y)
        {
            // ...
        }
    }
}
