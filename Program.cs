namespace QuizGame
{
    class Program
    {
        /*
        // Welcome to my Quiz Game!

        // This is my first *real* C# project.
        // I have tried my best to learn and keep up with all the naming/general C# conventions,
        // but i'm sure i've probably missed something somewhere :/

        //(Any tips or suggestions would be greatly appreciated.)

        // It's probably trivial to cheat and find answers within here, but I hope you had fun regardless

        // Thanks for playing &| taking a peak behind the scenes!

        // ~~ Mathall
        */
        static void Main(String[] args)
        {
            Data.InitiateDataFile(out User user);

            
            StartGame:
                Thread.Sleep(500);
                Console.WriteLine("Press any key to Start. . .");
                Console.ReadKey();
                Console.Clear();
                
                Question.PlayQuestions(user);

                
                NeedAnswer:
                Console.WriteLine("Would you like to play again? (Y/N)");
                string answer = Console.ReadLine()!;
                if (answer.ToLower().Equals("y"))
                {
                    Console.WriteLine("Restarting. . .");
                    Thread.Sleep(500);
                    goto StartGame;
                }
                else if (answer.ToLower().Equals("n"))
                {
                    goto End;
                }
                    Console.WriteLine("Please only enter Y or N!");
                    goto NeedAnswer;
            End:
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        //Requests for user input name, and checks to confirm that it is valid, returns valid name
        public static string GetName()
        {
            while (true)
            {
                Console.WriteLine("What is your name? (case sensitive)");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !input.All(char.IsLetterOrDigit))
                {
                    Console.WriteLine("Please make sure that the name only contains letters or digits!");
                    continue;
                }
                return input;
            }
        }
        public static void PlayIntro()
        {
            Console.WriteLine("Hello!");
            Thread.Sleep(1500);
            Console.WriteLine("Welcome to my Quiz Game!");
            Thread.Sleep(1250);
            Console.WriteLine("This game has a save mechanic, so you are able to save your progress between sessions!");
            Thread.Sleep(1500);
            Console.WriteLine("As long as you make sure to input your name correctly...!");
            Thread.Sleep(1400);
            Console.WriteLine("Anyways thanks for trying my first \"game.\" ");
            Thread.Sleep(1500);
        }
    }
}