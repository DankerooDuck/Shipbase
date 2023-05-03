using System.Collections.Generic;
using GundamEvolutionDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using GundamEvolutionDatabase.Models.ViewModels;

namespace GundamEvolutionDatabase.Models.ViewModels
{
    public class UnitListViewModel
    {
        public IEnumerable<Unit>? Units { get; set; }
    }
}
