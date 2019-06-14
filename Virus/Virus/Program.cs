using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemanT_Library;

namespace Virus
{
    class Program
    {
        private static int[,] Pole;
        private static void CreatePole()
        {
            ColorMess.Yellow("\n Введите колличество строк в поле: ");
            int n = Input.Check(1, 3000);
            ColorMess.Yellow("\n Введите колличество столбцов в поле: ");
            int m = Input.Check(1, 3000);
            Pole = new int[n, m];
            Console.Clear();
            ColorMess.Yellow("\n Введите количество зараженных клеток: ");
            int kol = Input.Check(1, 10);
            for(int i = 0; i<kol; i++)
            {
                Console.Clear();
                ColorMess.Yellow("\n Введите координату Х у " + (i + 1) + " точки: ");
                int x = Input.Check(1, n);
                ColorMess.Yellow("\n Введите координату Y у " + (i + 1) + " точки: ");
                int y = Input.Check(1, m);
                Pole[x,y] = 1;
            }
        }
        static void Main()
        {
            CreatePole();
            Message.GoToBack();
        }
    }
}
