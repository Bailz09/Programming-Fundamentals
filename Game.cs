using System;

namespace Hockey_Shootout
{
    public class Game
    {
        public void Startgame()
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

                Player[] players = null;// Initialize a Player array (players) that will be assigned to either the superstars or legends array based on user selection. Set to null initially to avoid unassigned variable errors.

                bool valid;//a boolean statement for the possibility of an invalid input when selecting which player array (superstars or legends)
                try//a try for exception handling 
                {
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
                }
                catch (FormatException ex)//since i already have a do while to prevent invalid numerical entries, the catch is there for non numerical entries
                {
                    Console.WriteLine("Invalid Entry please enter a numeric value");
                }

                int playerSelection = this.SelectPlayer(players);//get the users player selection from the SelectPlayer method below
                Goalie goalie = this.RandomGoalie();//get the goalie attributes from the RandomGoalie method below, which are randomized for every new game.
                //The Goalie class lets the program know that you need 3 attributes to fill, which is done below with 3 random generators
                //print the results of the randomized goalie attributes
                Console.WriteLine($"The goalie has a Save Percentage of {goalie.SavePercentage} Quickness of {goalie.Quickness} and Agility rating of {goalie.Agility}.");

                int score = 0;//set the score variable to zero 

                for (int i = 1; i <= 5; i++)//a for loop for 5 rounds of the shootout
                {
                    score += this.PlayRound(players[playerSelection], goalie, i);//add the result of the current round to the total score
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

        public int SelectPlayer(Player[] players)
        {
            int choice = -1;
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("Please select a player:");

                for (int i = 0; i < players.Length; i++)//a for loop that loops through the players array, the length of the loop will always equal 3 in this case since there
                                                        //is 3 players in each of the arrays but i used the .Length for future scalability
                {
                    Console.WriteLine($"{i + 1}. {players[i].Name} - Shot Power: {players[i].ShotPower} - Shot Accuracy: {players[i].ShotAccuracy} - Agility: {players[i].Agility}");
                }

                try//a try and catch for invalid non numeric inputs
                {
                    choice = int.Parse(Console.ReadLine()) - 1;//choice is -1 because of the index of the array

                    if (choice >= 0 && choice < players.Length)//an if statement setting the valid boolean to true if a valid input is entered
                    {
                        valid = true;
                    }
                    else//if the numbered entered is not between 1 and 3....
                    {
                        Console.WriteLine("Invalid numeric value. Please enter a number between 1 and 3.");
                    }
                }
                catch (FormatException)//the catch for non numeric values
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                }
            }

            return choice;//returns the player selection
        }

        public Goalie RandomGoalie()//a method to generate a goalie with Random attributes between 50 and 99
        {
            return new Goalie(new Random().Next(50, 100), new Random().Next(50, 100), new Random().Next(50, 100));//return a new Goalie object with Random Attributes
        }

        public int PlayRound(Player player, Goalie goalie, int round)//play round method with 3 parameters being passed to the method, player and goalie info to calculate chance of scoring and round number to display the current round
        {
            Console.WriteLine($"Round {round}: Please press any Key to shoot on net");
            string shot = Console.ReadLine();//Ask the user to shoot

            int shotAccuracy = player.ShotAccuracy; //create a variable called shotAccuracy and get the value from player class(ShotAccuracy)
            int shotPower = player.ShotPower;//create a variable called shotPower and get the value from player class(ShotPower)
            int agility = player.Agility;//create a variable called agility and get the value from player class(Agility)
            int savePercentage = goalie.SavePercentage;//create a variable called savePercentage and get the value from goalie class(SavePercentage)
            int quickness = goalie.Quickness;//create a variable called quickness and get the value from goalie class(Quickness)
            int agility2 = goalie.Agility;//create a variable called agility2 and get the value from goalie class(Agility)
            int total = (shotAccuracy + shotPower + agility) - (savePercentage + quickness + agility2);//create a variable called netAttributes that is calculated by subtracting the total Goalie 
                                                                                                       //attributes from the Player's attributes
            int scoringchance = 50 + (total / 2); //create a variable called chanceOfScoring, calculated by adding 50 to half of the net attributes
            if (new Random().Next(60, 101) <= scoringchance)//generate a random number between 60 and 100 and if that number is less than or equal to the chance of scoring
            {
                Console.WriteLine($"Goal! You scored in round {round}!");//then print you scored in the round number
                return 1;//store a 1 for the final score calculation in the Program class
            }
            else
            {
                Console.WriteLine($"Save! The goalie stopped your shot in round {round}.");//if the number is greater than chance of scoring...
                return 0;
            }
        }
    }
}

