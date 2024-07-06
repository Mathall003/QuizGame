using System.ComponentModel;

namespace QuizGame
{
    public class User(string? username)
    {
        public string? Username
        {
            get => username;
            set => username = !string.IsNullOrEmpty(value) ? value : "Invalid name!";
        }
        public int userMoney;
        [DefaultValue(0)]
        public int gamesPlayed;
        [DefaultValue(0)]
        public int questionsAnswered;
        [DefaultValue(0)]
        public int gamesWon;
        [DefaultValue(0)]


        public void GetUserInfo()
        {
            Console.WriteLine($"Your name is {Username}, and you have ${userMoney}!\nYou have played {gamesPlayed} games, answered {questionsAnswered} questions correctly.\nAnd you have won {gamesWon} game(s)");
        }

        //Takes the users stats from data file and puts it into the users object
        public void UpdateUserInfoFromFile()
        {
            List<string> lines = File.ReadAllLines(Data.fileLocation).ToList();
            Data.FindName(Username!, out int lineNum);

            //Splits lines to separate int value from 
            userMoney = Convert.ToInt32(lines[lineNum + 1].Split(' ')[1]);
            gamesPlayed = Convert.ToInt32(lines[lineNum + 2].Split(' ')[1]);
            questionsAnswered = Convert.ToInt32(lines[lineNum + 3].Split(' ')[1]);
            gamesWon = Convert.ToInt32(lines[lineNum + 4].Split(' ')[1]);
        }

        //takes the User properties and rewrites the file with updated properties
        public void UpdateFileFromUserInfo()
        {
            List<string> lines = File.ReadAllLines(Data.fileLocation).ToList();
            Data.FindName(Username!, out int lineNum);

            LineChanger($"UserMoney: {userMoney}", lineNum+1);
            LineChanger($"GamesPlayed: {gamesPlayed}", lineNum+2);
            LineChanger($"QuestionsAnswered: {questionsAnswered}", lineNum+3);
            LineChanger($"GamesWon: {gamesWon}", lineNum+4);
            Console.WriteLine("Data file updated!");
        }

        //rewrites a line given the text to update, and line number
        static void LineChanger(string newText, int lineToEdit)
        {
            string[] lineArr = File.ReadAllLines(Data.fileLocation);
            lineArr[lineToEdit] = newText;
            File.WriteAllLines(Data.fileLocation, lineArr);
        }

        public void AddUserMoney(int moneyToAdd)
        {
            userMoney += moneyToAdd;
        }

        public void AddUserQuestionsAnswered()
        {
            questionsAnswered++;
        }

        public void AddUserGamesPlayed()
        {
            gamesPlayed++;
        }

        public void AddUserGamesWon()
        {
            gamesWon++;
        }
    }
}