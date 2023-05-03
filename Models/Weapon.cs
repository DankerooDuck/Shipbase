using Microsoft.AspNetCore.Mvc;

namespace GundamEvolutionDatabase.Models
{
    public class Weapon
    {
        public int WeaponID { get; set; } // Weapon ID for DB purposes

        public Unit Unit { get; set; }

        public string? WeaponName { get; set; } // Name of Weapon (Ex. 'GN Beam Pistol')

        public int? DamageHead { get; set; } // Weapon Damage to Head

        public int? DamageBody { get; set; } // Weapon Damage to Body

        public int? DamageLimb { get; set; } // Weapon Damage to Limbs

        public int? DamagePerSecond { get; set; }

        public int? MagazineSize { get; set; } // Weapon Magazine Size

        public int? ReloadTimeStandard { get; set; } // Weapon Reload Duration Standard

        public int? ReloadTimeAlt { get; set; } // Weapon Reload Duration Alternative (Ex. GN Beam Pistol on back is 3s)

        public int? WeaponSwitchTime { get; set; } // Duration of time it takes to switch to weapon

        public int? FallOffDistance { get; set; } // Distance at which the damage will fall off

        // ATTRIBUTE 1
        public string? AbilityAttributeName1 { get; set; } // Name

        public string? AbilityAttributeData1 { get; set; } // Data

        // ATTRIBUTE 2
        public string? AbilityAttributeName2 { get; set; } // Name

        public string? AbilityAttributeData2 { get; set; } // Data

    }
}
