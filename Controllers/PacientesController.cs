using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsultamedicaConfort.Data;
using ConsultamedicaConfort.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsultamedicaConfort.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ConsultamedicaConfortContext _context;

        public PacientesController(ConsultamedicaConfortContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pacientes.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Create()
        {
            ViewBag.Medicos = _context.Medicos.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente, int[] medicosSelecionados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();

                if (medicosSelecionados != null)
                {
                    foreach (var idMedico in medicosSelecionados)
                    {
                        _context.PacientesMedicos.Add(new PacienteMedico
                        {
                            PacienteId = paciente.Id,
                            MedicoId = idMedico
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Medicos = _context.Medicos.ToList();
            return View(paciente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();

            ViewBag.Medicos = _context.Medicos.ToList();
            ViewBag.MedicosSelecionados = _context.PacientesMedicos
                .Where(pm => pm.PacienteId == id)
                .Select(pm => pm.MedicoId)
                .ToList();

            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Paciente paciente, int[] medicosSelecionados)
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            _context.Update(paciente);
            await _context.SaveChangesAsync();

            // Remove vínculos antigos
            var antigos = _context.PacientesMedicos.Where(pm => pm.PacienteId == paciente.Id);
            _context.PacientesMedicos.RemoveRange(antigos);

            // Adiciona vínculos novos
            if (medicosSelecionados != null)
            {
                foreach (var idMedico in medicosSelecionados)
                {
                    _context.PacientesMedicos.Add(new PacienteMedico
                    {
                        PacienteId = paciente.Id,
                        MedicoId = idMedico
                    });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}
