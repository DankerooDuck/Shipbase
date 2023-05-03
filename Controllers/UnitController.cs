using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GundamEvolutionDatabase.Models;
using GundamEvolutionDatabase.Models.ViewModels;

namespace GundamEvolutionDatabase.Controllers
{
    public class UnitController : Controller
    {
        private IUnitRepository _unitRepository;

        public UnitController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public IActionResult List()
        {
            var viewModel = new UnitListViewModel
            {
                Units = _unitRepository.Units
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var unit = _unitRepository.Units.FirstOrDefault(u => u.UnitID == id);
            if (unit == null)
            {
                return NotFound();
            }
            return PartialView("Details", unit);
        }
    }
}
