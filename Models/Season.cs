namespace GundamEvolutionDatabase.Models
{
    public class Season
    {
        public int SeasonID { get; set; } // Season #

        public ICollection<Map>? Maps { get; set; } // Maps Introduced in Season

        public ICollection<Unit>? Units { get; set; } // Units Introduced in Season


    }
}
