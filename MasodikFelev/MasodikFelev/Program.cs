using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasodikFelev
{
    internal class Program
    {
        const int szelXmag = 30;
        static char[,] map = new char[szelXmag, szelXmag];
        static Random r = new Random();
        static bool moved = false;
        static void Main(string[] args)
        {
            init();
            do
            {
                for (int i = 0; i < szelXmag; i++)
                {
                    if(r.Next(100) < 10)
                    {
                        map[0, i] = '*';
                    }
                }
                while (!moved)
                {
                    int x = r.Next(szelXmag);
                    int y = r.Next(szelXmag);
                    if (map[x, y] == '*')
                    {
                        int rx = r.Next(-1, 2);
                        if(rx+x < 1 || rx+x > 28) { continue; }
                        if (map[x+rx, y] != '*')
                        {
                            map[x, y] = ' ';
                            map[x + rx, y] = '*';
                            moved = true;
                        }
                    }
                }
                draw();
                moved = false;
                Thread.Sleep(1000);
            } while (true);
        }
        static void init()
        {
            for (int i = 0; i < szelXmag; i++)
            {
                for (int j = 0; j < szelXmag; j++)
                {
                    map[i, j] = ' ';
                }
            }
            for (int i = 0; i < szelXmag; i++)
            {
                map[28, i] = '*';
            }
        }
        static void draw()
        {
            Console.Clear();
            for (int i = 0; i < szelXmag-1; i++)
            {
                for (int j = 0; j < szelXmag; j++)
                {
                    /*if (map[i,j] == '*' && i < 25 && j < 28 && i > 2 && j < 2)
                    {
                        map[i, j] = ' ';
                        int nextx = r.Next(-1, 2);
                        if (i+1 < szelXmag && nextx < szelXmag) { map[i + 1, j + nextx] = '*'; }
                    }*/
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}