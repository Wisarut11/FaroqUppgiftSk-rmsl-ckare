using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UppgiftSkärmsläckare
{
    class Program
    {
        //Funktion ThreadScreen
        public static void ThreadScreen()
        {
            //Console.WriteLine("Hej");

            for (;;)
            {
                var rndNum = GetRandomNumber();
                WriteAt(rndNum[0], rndNum[1], "#");
                Thread.Sleep(1000);
            }
        }

        public static void WriteAt(int left, int top, string s)
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            //Console.CursorVisible = false;
            Console.SetCursorPosition(left, top);

            GetRandomColor();
            Console.Write(s);
            Console.ResetColor();

            Console.SetCursorPosition(currentLeft, currentTop);
            //Console.CursorVisible = true;
        }

        public static void GetRandomColor()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            var colorLength = colors.Length;
            Random rnd = new Random();
            int colorNum = rnd.Next(colorLength);

            Console.ForegroundColor = colors[colorNum];
        }
        public static int[] GetRandomNumber()
        {
            Random rnd = new Random();
            var width = Console.WindowWidth;
            var height = Console.WindowHeight;
            int numLeft = rnd.Next(width);
            int numTop = rnd.Next(2, height);
            int[] array = new int[2];

            array[0] = numLeft;
            array[1] = numTop;

            return array;
        }

        static void Main(string[] args)
        {
            Thread screen = new Thread(ThreadScreen);
            screen.Name = "Screen";
            screen.Start();

            //Väntar tills screen är klar
            screen.Join();
            //Console.ReadLine();    Stängs inte ner när är öppen


            Console.WriteLine("Press 'N + enter' to stop");
            for (;;)
            {
                var input = Console.ReadLine();
                if (input == "N")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
