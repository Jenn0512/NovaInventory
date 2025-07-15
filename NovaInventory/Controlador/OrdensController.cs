using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovaInventory.Modelo;

namespace NovaInventory.Controlador
{
    public class OrdensController : Controller
    {
        private readonly NovaContext _context;

        public OrdensController(NovaContext context)
        {
            _context = context;
        }

        // GET: Ordens
        public async Task<IActionResult> Index()
        {
            var novaContext = _context.Ordenes.Include(o => o.Cliente).Include(o => o.Producto);
            return View(await novaContext.ToListAsync());
        }

        // GET: Ordens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .Include(o => o.Cliente)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordens/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: Ordens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrden,IdCliente,IdProducto,Cantidad,FechaOrden")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", orden.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", orden.IdProducto);
            return View(orden);
        }

        // GET: Ordens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", orden.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", orden.IdProducto);
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrden,IdCliente,IdProducto,Cantidad,FechaOrden")] Orden orden)
        {
            if (id != orden.IdOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.IdOrden))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", orden.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", orden.IdProducto);
            return View(orden);
        }

        // GET: Ordens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .Include(o => o.Cliente)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden != null)
            {
                _context.Ordenes.Remove(orden);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordenes.Any(e => e.IdOrden == id);
        }
    }
}
