using System;

namespace Hockey_Shootout
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hockey Shootout!");

            // Create 2 player arrays
            Player[] superstars = 
            {
                new Player("Auston Mathews", 90, 85, 95),
                new Player("Connor McDavid", 95, 90, 85),
                new Player("Alexander Ovechkin", 85, 95, 90)
            };

            Player[] legends = 
            {
                new Player("Bobby Orr", 100, 90, 95),
                new Player("Wayne Gretzky", 95, 100, 90),
                new Player("Mario Lemieux", 90, 95, 100)
            };
            bool gameon = true;//boolean variable to control the game loop 
            while (gameon)//main game loop (while playAgain = true....)
            {  
                Console.WriteLine("Please select a player type:");
                Console.WriteLine("1 - Superstars");
                Console.WriteLine("2 - Legends");
                
                Player[] players = null;//choose which array based on user selection, set to null so i dont get an unassigned variable error when creating a new game
                bool valid;//a boolean statement for the possibility of an invalid input when selecting which player array (superstars or legends)

                do //a do-while loop to check if a 1 or a 2 was entered
                {
                    valid = true;//set valid variable to true
                    int playerType = int.Parse(Console.ReadLine());//get user selection for which array
                
                    if (playerType == 1)
                    {
                        players = superstars;//set the players array to superstars if user selects 1
                    }
                    else if (playerType == 2)
                    {
                        players = legends;//else set it to legends
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input please enter 1 or 2");
                        valid = false; //set the boolean to false if anything besides a 1 or 2 is entered
                    }
                }
                while (!valid);//repeats the loop if the valid variable gets set to false
               
                Game game = new Game(players);//create a new Game with the chosen player array
                int playerSelection = game.SelectPlayer();//get the users player selection from the game class
                Goalie goalie = game.RandomGoalie();//get the goalie attributes from the game class, which are randomized for every new game.

                //print the results of the randomized goalie attributes
                Console.WriteLine($"The goalie has a Save Percentage of {goalie.SavePercentage} Quickness of {goalie.Quickness} and Agility rating of {goalie.Agility}.");

                int score = 0;//set the score variable to zero 

                for (int i = 1; i <= 5; i++)//a for loop for 5 rounds of the shootout
                {
                    score += game.PlayRound(players[playerSelection], goalie, i);//add the result of the current round to the total score
                }

                Console.WriteLine($"You scored {score} out of 5 shots.");//print the final tally
                Console.WriteLine("Do you want to play again? (Y/N)");//ask user if they want to play again

                string playagain = Console.ReadLine();//get user input
                switch (playagain.ToLower())//a switch for playing again or not
                {
                    case "y"://when y is entered... 
                        gameon = true; // gameon variable updates to true and game starts again
                        break;
                    default://similar to an else statement, where as if anything besides y is entered...
                        gameon = false; //set gameon variable to false thus ending the game
                        break;
                }
            }
            Console.WriteLine("Thanks for playing the Hockey Shootout!");//display the message
        }
    }
}
