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
        private static int n, m;
        private static void CreatePole()
        {
            ColorMess.Yellow("\n Введите колличество строк: ");
            n = Input.Check(1, 3000);
            ColorMess.Yellow("\n Введите колличество столбцов: ");
            m = Input.Check(1, 3000);
            Pole = new int[n, m];
            ColorMess.Yellow("\n Введите колличество проникших вирусов: ");
            int kol = Input.Check(1, 10);
            for (int i = 0; i < kol; i++)
            {
                Console.Clear();
                ColorMess.Yellow("\n Введите координату " + (i + 1) + " точки Х: ");
                int x = Input.Check(1, n);
                ColorMess.Yellow("\n Введите координату " + (i + 1) + " точки Y: ");
                int y = Input.Check(1, m);
                Pole[x - 1, y - 1] = 1;
            }
        }
        private static int Zarajenie()
        {
            int time = 0;
            bool ok;
            do
            {
                ok = true;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        if (Pole[i, j] != 1)
                            ok = false;
                    }
                if (ok) return time;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        if (Pole[i, j] == 1)
                        {
                            Pole[i, j] = 2;
                            if (i - 1 > -1)
                            {
                                if (Pole[i - 1, j] == 0)
                                    Pole[i - 1, j] = 2;
                            }
                            if (j - 1 > -1)
                            {
                                if (Pole[i, j - 1] == 0)
                                    Pole[i, j - 1] = 2;
                            }
                            if (i + 1 < n)
                            {
                                if (Pole[i + 1, j] == 0)
                                    Pole[i + 1, j] = 2;
                            }
                            if (j + 1 < m)
                            {
                                if (Pole[i, j + 1] == 0)
                                    Pole[i, j + 1] = 2;
                            }
                        }
                    }
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        if (Pole[i, j] == 2)
                            Pole[i, j] = 1;
                time++;
            } while (!ok);
            return -1;
        }
        static void Main()
        {
            CreatePole();
            Console.Clear();
            ColorMess.Cyan("\n Поле заразится через " + Zarajenie() + " секунд");
            Message.GoToBack();
        }
    }
}