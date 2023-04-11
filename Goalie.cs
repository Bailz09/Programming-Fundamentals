namespace Hockey_Shootout
{
    public class Goalie
    {
        //properties for storing the random goalie's attributes
        public int SavePercentage { get; set; }
        public int Quickness { get; set; }
        public int Agility { get; set; }
        public Goalie(int savePercentage, int quickness, int agility2)//stores the attributes in this order from the random generators
        {
            //stores the randomly generated attributes into necessary variables
            SavePercentage = savePercentage;
            Quickness = quickness;
            Agility = agility2;
        }
    }
}
