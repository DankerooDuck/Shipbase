namespace GundamEvolutionDatabase.Models
{
    public class GameMode
    {
        public int GameModeID { get; set; }

        public ICollection<Map>? Maps { get; set; }

    }
}
