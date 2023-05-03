using Microsoft.AspNetCore.Mvc;

namespace GundamEvolutionDatabase.Models
{
    public interface IUnitRepository
    {
        IEnumerable<Unit>? Units { get; }

        Unit? DeleteUnit(int unitID);


        void SaveUnit(Unit unit);
    }
}
