using System;

namespace Hockey_Shootout
{
    public class Game
    {
        public Player[] Players { get; set; }//call the Player class and get the attributes into Players array

        public Game(Player[] players)//two arrays are necessary Players and players to distinguish between the superstars and the legends players
        {
            Players = players;//sets players parameters as Player array
        }

        public int SelectPlayer()//a method to select desired player
        {
            Console.WriteLine("Please select a player:");

            for (int i = 0; i < Players.Length; i++)//a for loop to display the Players array which has become either legends or superstars at this point
            {
                Console.WriteLine($"{i + 1}. {Players[i].Name} - Shot Power: {Players[i].ShotPower} - Shot Accuracy: {Players[i].ShotAccuracy} - Agility: {Players[i].Agility}");
            }

            return int.Parse(Console.ReadLine()) - 1;
        }

        public Goalie RandomGoalie()//a method to generate a goalie with Random attributes between 50 and 99
        {
            return new Goalie(new Random().Next(50, 100), new Random().Next(50, 100), new Random().Next(50, 100));
        }

        public int PlayRound(Player player, Goalie goalie, int round)
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
