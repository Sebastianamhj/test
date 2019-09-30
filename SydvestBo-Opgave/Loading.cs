using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydvestBo_Opgave
{
    static class Loading
    {
        public static void loading()
        {
            string splash = @"
    /$$$$$ /$$        /$$$$$$ 
   |__  $$| $$       /$$__  $$
      | $$| $$      | $$  \__/
      | $$| $$      |  $$$$$$ 
 /$$  | $$| $$       \____  $$
| $$  | $$| $$       /$$  \ $$
|  $$$$$$/| $$$$$$$$|  $$$$$$/
 \______/ |________/ \______/ 
";
            int cursorX = 95 / 2;
            int cursorY = 25 / 2;
            int cursorXOffset = 0;
            int cursorYOffset = 0;
            int i = 0;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (char letter in splash)
            {
                Console.SetCursorPosition((cursorX + cursorXOffset) - 18, (cursorY + cursorYOffset) - 4);
                cursorXOffset++;
                Console.Write(letter);
                System.Threading.Thread.Sleep(1);
                if (i++ > 30)
                {
                    i = 0;
                    cursorXOffset = 0;
                    cursorYOffset++;

                }
            }
        }
    }
}
