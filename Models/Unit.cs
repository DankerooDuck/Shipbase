namespace GundamEvolutionDatabase.Models
{
    public class Unit
    {
        public int? UnitID { get; set; } // Unit ID for DB purposes

        public string? Name { get; set; } // Unit Name

        public int? Difficulty { get; set; } // Unit "Difficulty" in-game

        public string? Range { get; set; } // Unit "Range" in-game

        public int? Health { get; set; } // Unit "HP" in-game

        public int? DashLimit { get; set; } // Unit "Dash Limit" in-game

        public int? Shield { get; set; } // Unit "Shield" in-game

        public ICollection<Weapon>? Weapons { get; set; } // Collection of Weapon Objects

        public ICollection<Ability>? Abilities { get; set; } // Collection of Ability Objects

        public string? Description { get; set; }

        public string? Tag { get; set; }

        public string? ImageURL { get; set; } // URL to unit icon
    }
}
