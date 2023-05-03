using System.Collections.Generic;
using GundamEvolutionDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using GundamEvolutionDatabase.Models.ViewModels;

namespace GundamEvolutionDatabase.Models.ViewModels
{
    public class UnitViewModel
    {
        public int? UnitID { get; set; }
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
        public string? Tag { get; set; }
        public int? Difficulty { get; set; }
        public string? Description { get; set; }
    }
}
