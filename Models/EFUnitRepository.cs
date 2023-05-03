using Microsoft.AspNetCore.Mvc;

namespace GundamEvolutionDatabase.Models
{
    public class EFUnitRepository : IUnitRepository
    {
        private ApplicationDBContext _context;

        public IEnumerable<Unit> Units => _context?.Units ?? Enumerable.Empty<Unit>();

        public EFUnitRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // SAVE UNIT  
        public void SaveUnit(Unit unit)
        {
            if (unit.UnitID == 0)
            {
                _context.Units?.Add(unit);
            }
            else
            {
                Unit? dbEntry = _context.Units?.FirstOrDefault(u => u.UnitID == unit.UnitID);
                if (dbEntry != null)
                {
                    dbEntry.Name = unit.Name;
                    dbEntry.Difficulty = unit.Difficulty;
                    dbEntry.Range = unit.Range;
                    dbEntry.Health = unit.Health;
                    dbEntry.DashLimit = unit.DashLimit;
                    dbEntry.Shield = unit.Shield;
                    dbEntry.Weapons =  unit.Weapons;
                    dbEntry.Abilities = unit.Abilities;
                    dbEntry.Description = unit.Description;
                    dbEntry.Tag = unit.Tag;
                }
            }
            _context.SaveChanges();
        }

        // DELETE UNIT
        public Unit? DeleteUnit(int unitID)
        {
            Unit? dbEntry = _context.Units?.FirstOrDefault(u => u.UnitID == unitID);
            if (dbEntry != null )
            {
                _context.Units?.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
