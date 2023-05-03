using Microsoft.AspNetCore.Mvc;

namespace GundamEvolutionDatabase.Models
{
    public class Ability
    {
        public int AbilityID { get; set; } // Ability ID for DB purposes

        public string? AbilityName { get; set;} // Ability Name

        public string? AbilityEffect { get; set;} // Ability Effect

        public bool? Ultimate { get; set;} // Is this ability an ultimate?

        // ABILITY ATTRIBUTE 1
        public string? AbilityAttributeName1 { get; set;} // Name

        public string? AbilityAttributeData1 { get; set; } // Data

        // ABILITY ATTRIBUTE 2
        public string? AbilityAttributeName2 { get; set; } // Name

        public string? AbilityAttributeData2 { get; set; } // Data

        // ABILITY ATTRIBUTE 3
        public string? AbilityAttributeName3 { get; set; } // Name

        public string? AbilityAttributeData3 { get; set; } // Data

    }
}
