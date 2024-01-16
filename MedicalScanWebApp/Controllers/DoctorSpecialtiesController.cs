using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalScanWebApp.DatabaseContext;
using MedicalScanWebApp.Models;

namespace MedicalScanWebApp.Controllers
{
    public class DoctorSpecialtiesController : Controller
    {
        private readonly MedicalScanDbContext _context;

        public DoctorSpecialtiesController(MedicalScanDbContext context)
        {
            _context = context;
        }

        // GET: DoctorSpecialties
        public async Task<IActionResult> Index()
        {
            var medicalScanDbContext = _context.DoctorSpecialties.Include(d => d.Doctor).Include(d => d.Specialty);
            return View(await medicalScanDbContext.ToListAsync());
        }

        // GET: DoctorSpecialties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecialty = await _context.DoctorSpecialties
                .Include(d => d.Doctor)
                .Include(d => d.Specialty)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorSpecialty == null)
            {
                return NotFound();
            }

            return View(doctorSpecialty);
        }

        // GET: DoctorSpecialties/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "Name");
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name");
            return View();
        }

        // POST: DoctorSpecialties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,SpecialtyId")] DoctorSpecialty doctorSpecialty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorSpecialty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "Name", doctorSpecialty.DoctorId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name", doctorSpecialty.SpecialtyId);
            return View(doctorSpecialty);
        }

        // GET: DoctorSpecialties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecialty = await _context.DoctorSpecialties.FindAsync(id);
            if (doctorSpecialty == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "Name", doctorSpecialty.DoctorId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name", doctorSpecialty.SpecialtyId);
            return View(doctorSpecialty);
        }

        // POST: DoctorSpecialties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,SpecialtyId")] DoctorSpecialty doctorSpecialty)
        {
            if (id != doctorSpecialty.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorSpecialty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorSpecialtyExists(doctorSpecialty.DoctorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "Name", doctorSpecialty.DoctorId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name", doctorSpecialty.SpecialtyId);
            return View(doctorSpecialty);
        }

        // GET: DoctorSpecialties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecialty = await _context.DoctorSpecialties
                .Include(d => d.Doctor)
                .Include(d => d.Specialty)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorSpecialty == null)
            {
                return NotFound();
            }

            return View(doctorSpecialty);
        }

        // POST: DoctorSpecialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorSpecialty = await _context.DoctorSpecialties.FindAsync(id);
            if (doctorSpecialty != null)
            {
                _context.DoctorSpecialties.Remove(doctorSpecialty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorSpecialtyExists(int id)
        {
            return _context.DoctorSpecialties.Any(e => e.DoctorId == id);
        }
    }
}
