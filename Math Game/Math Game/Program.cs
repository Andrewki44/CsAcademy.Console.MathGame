namespace Math_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Global Variables
            List<string[]> history = new List<string[]>();
            
            //Main Game Loop
            do
            {
                Console.Clear();

                Console.WriteLine("Welcome to Andrew's Console Math Game!");
                Console.WriteLine("Which operation would you like to play?");
                Console.WriteLine("| #1:\t+ Addition");
                Console.WriteLine("| #2:\t- Subtraction");
                Console.WriteLine("| #3:\tx Multiplication");
                Console.WriteLine("| #4:\t/ Division");
                Console.WriteLine("| #5:\t  View Game History");
                Console.WriteLine("| #0:\t  Exit");
                Console.Write("Enter the operator or menu option you wish to play: ");
                
                string? menuInput = Console.ReadLine();

                //Convert menuInput into sanitized option, or Exit
                switch (menuInput)
                {
                    case "1" or "+":
                        for (int i = 0; i < 10; i++)
                        {
                            history.Add(PlayAddition());
                        }
                        CheckGameHistory(ref history);
                        break;

                    case "2" or "-":
                        for (int i = 0; i < 10; i++)
                        {
                            history.Add(PlaySubtraction());
                        }
                        CheckGameHistory(ref history);
                        break;

                    case "3" or "x":
                        for (int i = 0; i < 10; i++)
                        {
                            history.Add(PlayMultiplication());
                        }
                        CheckGameHistory(ref history);
                        break;

                    case "4" or "/":
                        for (int i = 0; i < 10; i++)
                        {
                            history.Add(PlayDivision());
                        }
                        CheckGameHistory(ref history);
                        break;

                    case "5":
                        //Show game history                    
                        ViewHistory(history);
                        continue;
                    
                    case "0":   //Exit Application
                        return;

                    default:
                        continue;
                }
            } while (true);
        }

        static string[] PlayAddition()
        {
            Console.Clear();
            Random rnd = new Random();
            int num1 = rnd.Next(1, 11);
            int num2 = rnd.Next(1, 11);
            
            Console.WriteLine($"{num1} + {num2} = ...");

            do
            {
                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    // Evaluate answer into result, and mark into history
                    bool result = (answer == num1 + num2) ? true : false;
                    return new string[] { num1.ToString(), "+", num2.ToString(), answer.ToString(), result.ToString() };
                }
                else
                {
                    //Only accept numeric results
                    //Clear line and try again for text 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    continue;
                }
            } while (true);
        }

        static string[] PlaySubtraction()
        {
            Console.Clear();
            Random rnd = new Random();
            int num1, num2;

            //Ensure random numbers result in positive subtraction result
            do
            {
                num1 = rnd.Next(1, 11);
                num2 = rnd.Next(1, 11);
            } while (num1 - num2 < 0);

            Console.WriteLine($"{num1} - {num2} = ...");

            do
            {
                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    // Evaluate answer into result, and mark into history
                    bool result = (answer == num1 - num2) ? true : false;
                    return new string[] { num1.ToString(), "-", num2.ToString(), answer.ToString(), result.ToString() };
                }
                else
                {
                    //Only accept numeric results
                    //Clear line and try again for text 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    continue;
                }
            } while (true);
        }

        static string[] PlayMultiplication()
        {
            Console.Clear();
            Random rnd = new Random();
            int num1 = rnd.Next(1, 11);
            int num2 = rnd.Next(1, 11);

            Console.WriteLine($"{num1} x {num2} = ...");

            do
            {
                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    // Evaluate answer into result, and mark into history
                    bool result = (answer == num1 * num2) ? true : false;
                    return new string[] { num1.ToString(), "x", num2.ToString(), answer.ToString(), result.ToString() };
                }
                else
                {
                    //Only accept numeric results
                    //Clear line and try again for text 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    continue;
                }
            } while (true);
        }

        static string[] PlayDivision()
        {
            Console.Clear();
            Random rnd = new Random();
            int num1, num2;

            //Ensure random numbers result in integer division
            do
            {
                num1 = rnd.Next(1, 101);
                num2 = rnd.Next(1, 101);
            } while (num1 % num2 != 0);
            

            Console.WriteLine($"{num1} / {num2} = ...");

            do
            {
                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    // Evaluate answer into result, and mark into history
                    bool result = (answer == num1 / num2) ? true : false;
                    return new string[] { num1.ToString(), "/", num2.ToString(), answer.ToString(), result.ToString() };
                }
                else
                {
                    //Only accept numeric results
                    //Clear line and try again for text 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    continue;
                }
            } while (true);
        }

        static void CheckGameHistory(ref List<string[]> history)
        {
            int numOfGames = 10;
            int numOfWins = 0;

            for (int i = history.Count() - 10; i < history.Count(); i++)
            {
                //position [4] = result
                if (bool.Parse(history[i][4]))
                    numOfWins++;
            }

            Console.Clear();
            Console.WriteLine($"You won {numOfWins} out of {numOfGames} games!");
            Console.Write("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        static void ViewHistory(List<string[]> history)
        {
            // View History
            Console.Clear();
            Console.WriteLine("~~~ History ~~~\n");

            int numOfMatches = history.Count() / 10;
            for (int i = 1; i <= numOfMatches; i++)
            {
                //Match Loop
                Console.WriteLine($"Match #{i}. Operater: {history[(i-1)*10][1]}");
                for (int j = (i - 1) * 10; j < (i - 1) * 10 + 10; j++)
                {
                    //Game Loop
                    Console.WriteLine($"|\t{history[j][0]} {history[j][1]} {history[j][2]} = {history[j][3]}\t|\t{history[j][4]}");
                }
                Console.WriteLine();
            }
            
            Console.ReadLine();
            return;
        }

    }
}
