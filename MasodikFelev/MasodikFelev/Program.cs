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
        //static bool moved = false;
        static void Main(string[] args)
        {
            init();
            do
            {
                for (int i = 0; i < szelXmag; i++)
                {
                    if(r.Next(101) < 10)
                    {
                        map[0, i] = '❄';
                    }
                }
                /*while (!moved)
                {
                    int x = r.Next(szelXmag);
                    int y = r.Next(szelXmag);
                    if (map[y, x] == '*' && y != 28)
                    {
                        int rx = r.Next(-1, 2);
                        if(rx+x < 1 && rx+x > 28 && x > 28) { continue; }
                        if(x == 0 && y == 0) { continue; }
                        if (x<29 && x > 0 && map[y + 1, x + rx] != '*')
                        {
                            map[y, x] = ' ';
                            map[y + 1, x + rx] = '*';
                            moved = true;
                        }
                    }
                }*/
                for (int i = szelXmag-2; i >= 0; i--)
                {
                    for (int j = szelXmag-1; j >= 0; j--)
                    {
                        if (map[i, j] == '❄' && i != 28)
                        {
                            int rx = r.Next(-1, 2);
                            if (rx + j < 1 && j <= 0) { rx = r.Next(0, 2); }
                            if (j + rx > 29 || j >= 29) { rx = r.Next(-1, 1); }
                            if (i == 0 && j == 0) { rx = r.Next(0,2); }
                            if (map[i + 1, j + rx] != '❄')
                            {
                                map[i, j] = ' ';
                                map[i + 1, j + rx] = '❄';
                            }
                        }
                    }
                }
                draw();
                Thread.Sleep(50);
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
                map[28, i] = '❄';
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