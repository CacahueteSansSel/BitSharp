using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*  This program is made by Cacahuète Sans Sel
    BitSharp is a interpreter that can run code
    with images by interpreting pixel color
    Exemple : Red = Print String
    Arguments are in Y axis and instructions in X axis
*/
namespace BitSharp
{
    public class Program
    {
        public static void PrintLine(string value, ConsoleColor color)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = old;
        }

        public static List<Color> GetArguments(int x, Bitmap b)
        {
            List<Color> args = new List<Color>();
            for (int i = 1; i < b.Height; i++)
            {
                args.Add(b.GetPixel(x, i));
            }
            return args;
        }
        public static string GetString(List<Color> values)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Color pixel in values)
            {
                if (pixel == Color.FromArgb(255,0,0))
                {
                    builder.Append('A');
                }
                else if (pixel == Color.FromArgb(255, 255, 0))
                {
                    builder.Append('B');
                }
                else if (pixel == Color.FromArgb(0, 255, 0))
                {
                    builder.Append('C');
                }
                else if (pixel == Color.FromArgb(0, 255, 255))
                {
                    builder.Append('D');
                }
                else if (pixel == Color.FromArgb(255, 0, 255))
                {
                    builder.Append('E');
                }
                else if (pixel == Color.FromArgb(128, 255, 0))
                {
                    builder.Append('F');
                }
                else if (pixel == Color.FromArgb(0, 255, 128))
                {
                    builder.Append('G');
                }
                else if (pixel == Color.FromArgb(0, 128, 0))
                {
                    builder.Append('H');
                }
                else if (pixel == Color.FromArgb(0, 0, 128))
                {
                    builder.Append('I');
                }
                else if (pixel == Color.FromArgb(128, 255, 128))
                {
                    builder.Append('J');
                }
                else if (pixel == Color.FromArgb(0, 128, 128))
                {
                    builder.Append('K');
                }
                else if (pixel == Color.FromArgb(128, 128, 255))
                {
                    builder.Append('L');
                }
                else if (pixel == Color.FromArgb(150, 0, 0))
                {
                    builder.Append('M');
                }
                else if (pixel == Color.FromArgb(0, 150, 0))
                {
                    builder.Append('O');
                }
                else if (pixel == Color.FromArgb(0, 0, 150))
                {
                    builder.Append('P');
                }
                else if (pixel == Color.FromArgb(255, 150, 0))
                {
                    builder.Append('Q');
                }
                else if (pixel == Color.FromArgb(150, 150, 0))
                {
                    builder.Append('R');
                }
                else if (pixel == Color.FromArgb(0, 150, 255))
                {
                    builder.Append('S');
                }
                else if (pixel == Color.FromArgb(150, 150, 150))
                {
                    builder.Append('T');
                }
                else if (pixel == Color.FromArgb(255, 150, 255))
                {
                    builder.Append('U');
                }
                else if (pixel == Color.FromArgb(180, 0, 0))
                {
                    builder.Append('V');
                }
                else if (pixel == Color.FromArgb(180, 180, 0))
                {
                    builder.Append('W');
                }
                else if (pixel == Color.FromArgb(0, 180, 0))
                {
                    builder.Append('X');
                }
                else if (pixel == Color.FromArgb(0, 0, 180))
                {
                    builder.Append('Y');
                }
                else if (pixel == Color.FromArgb(180, 180, 180))
                {
                    builder.Append('Z');
                }
                else if (pixel == Color.FromArgb(0, 0, 0))
                {
                    builder.Append(' ');
                }
                else if (pixel == Color.FromArgb(50, 0, 0))
                {
                    builder.Append('0');
                }
                else if (pixel == Color.FromArgb(50, 1, 0))
                {
                    builder.Append('1');
                }
                else if (pixel == Color.FromArgb(50, 2, 0))
                {
                    builder.Append('2');
                }
                else if (pixel == Color.FromArgb(50, 3, 0))
                {
                    builder.Append('3');
                }
                else if (pixel == Color.FromArgb(50, 4, 0))
                {
                    builder.Append('4');
                }
                else if (pixel == Color.FromArgb(50, 5, 0))
                {
                    builder.Append('5');
                }
                else if (pixel == Color.FromArgb(50, 6, 0))
                {
                    builder.Append('6');
                }
                else if (pixel == Color.FromArgb(50, 7, 0))
                {
                    builder.Append('7');
                }
                else if (pixel == Color.FromArgb(50, 8, 0))
                {
                    builder.Append('8');
                }
                else if (pixel == Color.FromArgb(50, 9, 0))
                {
                    builder.Append('9');
                }
            }
            return builder.ToString();
        }

        public static void Exception(string text, Point coords, Color instruction)
        {
            PrintLine("BitSharp Execution Exception\n" + text + " \"" + instruction.ToString() + "\"\nCoordinates : X:" + coords.X + ", Y:" + coords.Y, ConsoleColor.Red);
            PrintLine("Press a key to close...", ConsoleColor.Gray);
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static string GetInstruction(Color c)
        {
            if (c == Color.FromArgb(255, 0, 0)) //Red : Print Instruction
            {
                return "PRINT";
            }
            else if (c == Color.FromArgb(255, 255, 0)) //Yellow : Waiting user for pressing a key and close
            {
                return "WAITANDCLOSE";
            }
            else if (c == Color.FromArgb(0, 255, 255)) //Cyan : Set the title of the Console Window
            {
                return "TITLE";
            }
            else if (c == Color.FromArgb(0, 255, 0)) //Green : Imediately terminate execution
            {
                return "END";
            }
            else if (c == Color.FromArgb(255, 0, 255)) //Magenta : Wait for specified amount of time (in seconds)
            {
                return "WAIT";
            }
            else if (c == Color.FromArgb(0, 0, 255)) //Blue : Show a MessageBox with specified text
            {
                return "MSGBOX";
            }
            else
            {
                return "?";
            }
        }

        static void Main(string[] args)
        {
            //Check if program started correctly
            if (args.Count() == 0)
            {
                PrintLine("No image specified in arguments. Please restart with image specified ! ", ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(-1);
            }
            Point exactLocation = new Point(0, 0);
            //Checking if the image exist
            if (!File.Exists(args[0]))
            {
                PrintLine("The arguments are not valid (file doesn't exist) !", ConsoleColor.Red);
                return;
            }
            Bitmap bitmap = new Bitmap(Image.FromFile(args[0])); //Open the image
            //The interpretation start here
            while (true)
            {
                Color instruction = bitmap.GetPixel(exactLocation.X, exactLocation.Y);
                if (instruction == Color.FromArgb(255,0,0)) //Red : Print instruction
                {
                    PrintLine(GetString(GetArguments(exactLocation.X, bitmap)), ConsoleColor.White);
                }
                else if (instruction == Color.FromArgb(255,255,0)) //Yellow : Waiting user for pressing a key and close
                {
                    PrintLine("Execution End, Press a key to close...", ConsoleColor.Gray);
                    Console.ReadKey();
                    Environment.Exit(0);
                } else if (instruction == Color.FromArgb(0,255,255)) //Cyan : Set the title of the Console Window
                {
                    Console.Title = GetString(GetArguments(exactLocation.X, bitmap));
                } else if (instruction == Color.FromArgb(0, 255, 0)) //Green : Imediately terminate execution
                {
                    Environment.Exit(0);
                }
                else if (instruction == Color.FromArgb(0, 255, 128)) //Green-Blue : Waiting user for pressing a key
                {
                    Console.ReadKey();
                }
                else if (instruction == Color.FromArgb(255, 0, 255)) //Magenta : Wait for specified amount of time (in seconds)
                {
                    //Sleep the actual thread, simillar to a wait instruction
                    try
                    {
                        System.Threading.Thread.Sleep(Convert.ToInt32(GetString(GetArguments(exactLocation.X, bitmap))) * 1000);
                    }
                    catch (Exception)
                    {
                        Exception("This instruction only supports numbers at arguments", exactLocation, instruction);
                    }
                } else if (instruction == Color.FromArgb(0, 0, 255)) //Blue : Show a MessageBox with specified text
                {
                    MessageBox.Show(GetString(GetArguments(exactLocation.X, bitmap)));
                }
                else
                {
                    //If a unknown instruction is detected
                    Exception("Unknown Instruction", exactLocation, instruction);
                }
                exactLocation.X++;
            }
        }
    }
}
