namespace QuizGame
{
    class Question
    {
        string questionText;
        int difficulty;
        string genre;
        string correctAnswer;
        string incorrectAnswer1;
        string incorrectAnswer2;
        string incorrectAnswer3;

        //Question Constructor
        public Question(string questionText, int difficulty, string genre, string correctAnswer,
        string incorrectAnswer1, string incorrectAnswer2, string incorrectAnswer3){
            this.questionText = questionText;
            this.difficulty = difficulty;
            this.genre = genre;
            this.correctAnswer = correctAnswer;
            this.incorrectAnswer1 = incorrectAnswer1;
            this.incorrectAnswer2 = incorrectAnswer2;
            this.incorrectAnswer3 = incorrectAnswer3;
        }

        //Writes out all Question Variables
        public void GiveQuestionInfo() {
            Console.WriteLine($"\nQuestionText: {questionText}\nDifficulty: {difficulty}\nGenre: {genre}\nCorrect: {correctAnswer}\nIncorrect1: {incorrectAnswer1}\nIncorrect2: {incorrectAnswer2}\nIncorrect3: {incorrectAnswer3}");
        }


        public static void PlayQuestions(User user)
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (!AskQuestion(i, j, out string correctAnswer))
                    {
                        Console.WriteLine("And your answer was. . .");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(1000);
                        Console.WriteLine("Incorrect!");
                        Thread.Sleep(500);
                        Console.WriteLine($"\nThe correct answer was: {correctAnswer}");
                        Console.ResetColor();
                        Thread.Sleep(500);
                        Console.WriteLine($"You answered {((i-1)*5) + (j-1)} Questions correct!\n");
                        Thread.Sleep(500);
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey();
                        Console.Clear();
                        goto End;
                    }
                    else
                    {
                        Console.WriteLine("And your answer was. . .");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(1000);
                        Console.WriteLine("Correct!");
                        Thread.Sleep(500);
                        Console.ResetColor();
                        user.AddUserQuestionsAnswered();
                        Console.WriteLine($"You earned ${(i*100) + (j*20)} from that question!");
                        Thread.Sleep(500);
                        user.AddUserMoney((i*100) + (j*20));
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                prevNums.Clear();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            user.AddUserGamesWon();
            Thread.Sleep(500);
            Console.WriteLine("Congratulations on winning the game!");
            Thread.Sleep(200);
            Console.WriteLine($"You have now won {user.gamesWon}");
            Thread.Sleep(200);
            Console.ResetColor();
            End:
                user.AddUserGamesPlayed();
                Console.WriteLine("Your current stats are now:\n");
                user.GetUserInfo();
                user.UpdateFileFromUserInfo();
                Thread.Sleep(500);
        }

        public static List<int> prevNums = [];

        //Ask questions and returns if correct or not
        public static bool AskQuestion(int difficulty, int qNum, out string correctAnswer)
        {
            Random rnd = new Random();
            GetQuestion(difficulty, out Question question);

            correctAnswer = question.correctAnswer;

            switch (rnd.Next(0,4))
            {
                case 0:
                    Console.WriteLine($"Section {difficulty}: Question {qNum}\nGenre: {question.genre}");
                    Thread.Sleep(200);
                    Console.WriteLine(question.questionText);
                    Thread.Sleep(250);
                    Console.WriteLine($"(A){question.correctAnswer}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(B){question.incorrectAnswer1}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(C){question.incorrectAnswer2}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(D){question.incorrectAnswer3}");
                    string answer1 = Console.ReadLine()!;

                    if (answer1.ToLower().Equals("a")) //answer is correct
                    {
                        return true;
                    }
                    return false;

                case 1:
                    Console.WriteLine($"Section {difficulty}: Question {qNum}\nGenre: {question.genre}");
                    Thread.Sleep(200);
                    Console.WriteLine(question.questionText + "\n");
                    Thread.Sleep(250);
                    Console.WriteLine($"(A){question.incorrectAnswer3}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(B){question.correctAnswer}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(C){question.incorrectAnswer1}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(D){question.incorrectAnswer2}");
                    string answer2 = Console.ReadLine()!;

                    if (answer2.ToLower().Equals("b")) //answer is correct
                    {
                        return true;
                    }
                    return false;
                    
                case 2:
                    Console.WriteLine($"Section {difficulty}: Question {qNum}\nGenre: {question.genre}");
                    Thread.Sleep(200);
                    Console.WriteLine(question.questionText + "\n");
                    Thread.Sleep(250);
                    Console.WriteLine($"(A){question.incorrectAnswer2}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(B){question.incorrectAnswer3}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(C){question.correctAnswer}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(D){question.incorrectAnswer1}");
                    string answer3 = Console.ReadLine()!;

                    if (answer3.ToLower().Equals("c")) //answer is correct
                    {
                        return true;
                    }
                    return false;

                default:
                    Console.WriteLine($"Section {difficulty}: Question {qNum}\nGenre: {question.genre}");
                    Thread.Sleep(200);
                    Console.WriteLine(question.questionText + "\n");
                    Thread.Sleep(250);
                    Console.WriteLine($"(A){question.incorrectAnswer1}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(B){question.incorrectAnswer2}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(C){question.incorrectAnswer3}");
                    Thread.Sleep(250);
                    Console.WriteLine($"(D){question.correctAnswer}");
                    string answer4 = Console.ReadLine()!;

                    if (answer4.ToLower().Equals("d")) //answer is correct
                    {
                        return true;
                    }
                    return false;
            }

        }

        public static void GetQuestion(int difficulty, out Question question) {
        
            Random rnd = new Random();

            //List of all questions
            Question[] Diff1Questions = [
                new ("What is the capital of France?", 1, "Geography", "Paris", "Berlin", "London", "Madrid"),
                new ("Who painted the Mona Lisa?", 1, "Art", "Leonardo da Vinci", "Pablo Picasso", "Vincent van Gogh", "Michelangelo"),
                new ("Which planet is known as the Red Planet?", 1, "Science", "Mars", "Jupiter", "Saturn", "Neptune"),
                new ("What is the largest mammal in the world?", 1, "Science", "Blue whale", "Elephant", "Giraffe", "Hippopotamus"),
                new ("Which country is the largest by land area?", 1, "Geography", "Russia", "Canada", "China", "United States"),
                new ("What is the chemical symbol for water?", 1, "Science", "H2O", "CO2", "O2", "NaCl"),
                new ("Which US state is known as the Sunshine State?", 1, "Geography", "Florida", "California", "Texas", "Hawaii"),
                new ("Who was the first President of the United States?", 1, "History", "George Washington", "Thomas Jefferson", "Abraham Lincoln", "John Adams"),
                new ("What is the capital of Japan?", 1, "Geography", "Tokyo", "Beijing", "Seoul", "Bangkok"),
                new ("What is the largest ocean on Earth?", 1, "Geography", "Pacific Ocean", "Atlantic Ocean", "Indian Ocean", "Arctic Ocean"),
                new ("Who painted 'Starry Night'?", 1, "Art", "Vincent van Gogh", "Claude Monet", "Pablo Picasso", "Georgia O'Keeffe"),
                new ("What is the largest desert in the world?", 1, "Geography", "Sahara Desert", "Arabian Desert", "Gobi Desert", "Kalahari Desert"),
                new ("What is the chemical formula for table salt?", 1, "Science", "NaCl", "H2O", "CO2", "O2"),
                new ("What is the capital of Australia?", 1, "Geography", "Canberra", "Sydney", "Melbourne", "Brisbane"),
                new ("Who is the author of the book series 'Harry Potter'?", 1, "Literature", "J.K. Rowling", "Stephen King", "George R.R. Martin", "J.R.R. Tolkien"),
                new ("What is the deepest ocean trench in the world?", 1, "Geography", "Mariana Trench", "Puerto Rico Trench", "Java Trench", "Philippine Trench"),
                new ("Which element has the chemical symbol 'Fe'?", 1, "Science", "Iron", "Gold", "Silver", "Lead"),
                new ("Who founded Microsoft?", 1, "Technology", "Bill Gates", "Steve Jobs", "Mark Zuckerberg", "Larry Page"),
                new ("Which planet is known as the 'Red Planet'?", 1, "Science", "Mars", "Jupiter", "Venus", "Saturn"),
                new ("What is the largest organ in the human body?", 1, "Science", "Skin", "Liver", "Heart", "Lungs"),
                new ("What is the capital of South Korea?", 1, "Geography", "Seoul", "Tokyo", "Beijing", "Bangkok"),
                new ("Who was the first woman to fly solo across the Atlantic Ocean?", 1, "History", "Amelia Earhart", "Bessie Coleman", "Jacqueline Cochran", "Harriet Quimby"),
                new ("Which element has the chemical symbol 'Na'?", 1, "Science", "Sodium", "Nickel", "Neon", "Nitrogen"),
                new ("Which physicist developed the theory of general relativity?", 1, "Science", "Albert Einstein", "Isaac Newton", "Max Planck", "Niels Bohr"),
                new ("Who painted 'The Starry Night'?", 1, "Art", "Vincent van Gogh", "Edvard Munch", "Claude Monet", "Pablo Picasso"),
                new ("What is the smallest planet in our solar system?", 1, "Science", "Mercury", "Pluto", "Venus", "Earth") //26
            ];
        
            Question[] Diff2Questions = [
                new ("What year did World War II end?", 2, "History", "1945", "1918", "1939", "1950"),
                new ("Who wrote 'To Kill a Mockingbird'?", 2, "Literature", "Harper Lee", "Mark Twain", "Ernest Hemingway", "F. Scott Fitzgerald"),
                new ("Who is credited with discovering gravity when an apple fell on his head?", 2, "Science", "Isaac Newton", "Albert Einstein", "Galileo Galilei", "Stephen Hawking"),
                new ("Who painted the ceiling of the Sistine Chapel?", 2, "Art", "Michelangelo", "Raphael", "Leonardo da Vinci", "Donatello"),
                new ("In which year did Neil Armstrong first walk on the moon?", 2, "History", "1969", "1961", "1972", "1955"),
                new ("Who wrote '1984'?", 2, "Literature", "George Orwell", "Aldous Huxley", "Ray Bradbury", "J.K. Rowling"),
                new ("What is the largest bone in the human body?", 2, "Science", "Femur", "Skull", "Tibia", "Humerus"),
                new ("Which country hosted the 2016 Summer Olympics?", 2, "Sports", "Brazil", "United States", "China", "Russia"),
                new ("Who wrote 'The Great Gatsby'?", 2, "Literature", "F. Scott Fitzgerald", "Ernest Hemingway", "Mark Twain", "Harper Lee"),
                new ("Which planet is known as the 'Morning Star' or 'Evening Star'?", 2, "Science", "Venus", "Mercury", "Mars", "Jupiter"),
                new ("Who wrote 'Pride and Prejudice'?", 2, "Literature", "Jane Austen", "Charlotte Brontë", "Emily Brontë", "Louisa May Alcott"),
                new ("In which year did the Titanic sink?", 2, "History", "1912", "1905", "1920", "1930"),
                new ("Who wrote 'The Catcher in the Rye'?", 2, "Literature", "J.D. Salinger", "Ernest Hemingway", "F. Scott Fitzgerald", "Mark Twain"),
                new ("Who painted 'Guernica'?", 2, "Art", "Pablo Picasso", "Vincent van Gogh", "Salvador Dalí", "Claude Monet"),
                new ("Which country won the first FIFA World Cup in 1930?", 2, "Sports", "Uruguay", "Brazil", "Germany", "Italy"),
                new ("What is the largest artery in the human body?", 2, "Science", "Aorta", "Carotid artery", "Femoral artery", "Coronary artery"),
                new ("Which mountain range is the tallest in the world?", 2, "Geography", "The Himalayas", "The Andes", "The Rockies", "The Alps"),
                new ("Which country won the most medals in the 2020 Tokyo Olympics?", 2, "Sports", "United States", "China", "Japan", "Russia"),
                new ("Which element has the chemical symbol 'Hg'?", 2, "Science", "Mercury", "Hydrogen", "Helium", "Magnesium"),
                new ("What is the largest species of bear?", 2, "Science", "Polar bear", "Grizzly bear", "Brown bear", "Black bear") //20
            ];

            Question[] Diff3Questions = [
                new ("Who is known as the Bard of Avon?", 3, "Literature", "William Shakespeare", "Jane Austen", "Charles Dickens", "Emily Dickinson"),
                new ("Who was the first person to step on the South Pole?", 3, "History", "Roald Amundsen", "Robert Falcon Scott", "Ernest Shackleton", "Douglas Mawson"),
                new ("Who composed 'The Four Seasons'?", 3, "Music", "Antonio Vivaldi", "Johann Sebastian Bach", "Wolfgang Amadeus Mozart", "Ludwig van Beethoven"),
                new ("What is the largest moon in the solar system?", 3, "Science", "Ganymede", "Titan", "Europa", "Callisto"),
                new ("Who developed the first successful polio vaccine?", 3, "Science", "Jonas Salk", "Louis Pasteur", "Alexander Fleming", "Edward Jenner"),
                new ("Who painted 'The Persistence of Memory'?", 3, "Art", "Salvador Dalí", "Pablo Picasso", "Vincent van Gogh", "Claude Monet"),
                new ("Who wrote 'War and Peace'?", 3, "Literature", "Leo Tolstoy", "Fyodor Dostoevsky", "Anton Chekhov", "Alexander Pushkin"),
                new ("What is the oldest continuously inhabited city in the world?", 3, "History", "Damascus", "Jerusalem", "Athens", "Varanasi"),
                new ("Who composed 'The Nutcracker' ballet?", 3, "Music", "Pyotr Ilyich Tchaikovsky", "Johann Sebastian Bach", "Ludwig van Beethoven", "Wolfgang Amadeus Mozart"),
                new ("Who is known as the 'Father of Geometry'?", 3, "Mathematics", "Euclid", "Pythagoras", "Archimedes", "Aristotle"),
                new ("Who wrote 'The Canterbury Tales'?", 3, "Literature", "Geoffrey Chaucer", "William Shakespeare", "John Milton", "Jane Austen"),
                new ("Who discovered penicillin?", 3, "Science", "Alexander Fleming", "Louis Pasteur", "Jonas Salk", "Robert Koch"),
                new ("Who was the first woman to win a Nobel Prize?", 3, "History", "Marie Curie", "Rosalind Franklin", "Mother Teresa", "Florence Nightingale"),
                new ("Which composer wrote 'The Marriage of Figaro'?", 3, "Music", "Wolfgang Amadeus Mozart", "Ludwig van Beethoven", "Johann Sebastian Bach", "Antonio Vivaldi") //14
            ];  

            //Question picker
            switch (difficulty)
            {
                case 1:
                    repeat1:
                    int currentNum1 = rnd.Next(0,Diff1Questions.Length);

                    foreach (var item in prevNums)
                    {
                        if (currentNum1 == item)
                        {
                            goto repeat1;
                        }
                    }

                    question = Diff1Questions[currentNum1];
                    prevNums.Add(currentNum1);
                    break;
                case 2:
                    repeat2:
                    int currentNum2 = rnd.Next(0,Diff2Questions.Length);
                    
                    foreach (var item in prevNums)
                    {
                        if (currentNum2 == item)
                        {
                            goto repeat2;
                        }
                    }
                    question = Diff2Questions[currentNum2];
                    prevNums.Add(currentNum2);
                    break;
                default:
                    repeat3:
                    int currentNum3 = rnd.Next(0,Diff3Questions.Length);
                    
                    foreach (var item in prevNums)
                    {
                        if (currentNum3 == item)
                        {
                            goto repeat3;
                        }
                    }
                    question = Diff3Questions[currentNum3];
                    prevNums.Add(currentNum3);
                    break;
            }
        }

    }
}