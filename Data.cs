namespace QuizGame
{
    public class Data
    {
        public static string fileLocation = @"quizgamedata.txt";

        //Creates data file if it is not already created
        public static void InitiateDataFile(out User user) 
        {
            user = new User(Program.GetName());
            
            var defaultUserString = $"Username: {user.Username}\nUserMoney: 0\nGamesPlayed: 0\nQuestionsAnswered: 0\nGamesWon: 0\n";
            if (TestForDataFile())
            {
                if(FindName(user.Username!, out int lineNum))
                {
                    user.UpdateUserInfoFromFile();
                    Console.WriteLine("User info updated from file");
                    user.GetUserInfo();
                }
                else
                {
                    File.AppendAllText(fileLocation, defaultUserString);
                    Console.WriteLine("New Profile Created inside file!");
                }
            }
            else
            {
                File.WriteAllText(fileLocation, defaultUserString);
                Console.WriteLine("New file created");
                Thread.Sleep(500);
                Program.PlayIntro();
            }
        }

        //Tests to see if user has needed data file
        public static bool TestForDataFile() => File.Exists(fileLocation) ? true : false;

        //idk what to write in these, it does what it says on the tin
        public static bool FindName(string name, out int lineNum)
        {
            List<string> lines = File.ReadAllLines(fileLocation).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Equals($"Username: {name}"))
                {
                    lineNum = i;
                    return true;

                }
            }
            lineNum = -1;
            return false;
        }


    }
}