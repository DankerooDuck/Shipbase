namespace GundamEvolutionDatabase.Models
{
    public class Map
    {
        public int MapID { get; set; } // for db

        public string? Name { get; set; } // map name

        public string? GameMode { get; set; } // game mode

        public string? Description { get; set; } // description

        public string? ImageURL { get; set; } // map image

        public ICollection<GameMode>? GameModes { get; set; }
    }
}
