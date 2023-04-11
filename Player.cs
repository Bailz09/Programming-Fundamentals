namespace Hockey_Shootout
{
    public class Player
    {
        //properties for storing the players name and attributes
        public string Name { get; set; }
        public int ShotPower { get; set; }
        public int ShotAccuracy { get; set; }
        public int Agility { get; set; }

        public Player(string name, int shotPower, int shotAccuracy, int agility)//stores the attributes in this order from the new Player in program class
        {
            //stores the selected player attributes into the necessary variables
            Name = name;
            ShotPower = shotPower;
            ShotAccuracy = shotAccuracy;
            Agility = agility;
        }
    }
}
