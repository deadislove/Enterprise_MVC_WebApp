using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class Enterprise_MVC_CoreController : Controller
    {
        private readonly DemoDbContext _context;
        private readonly IEnterprise_MVC_CoreRepository repo;

        public Enterprise_MVC_CoreController(DemoDbContext context, IEnterprise_MVC_CoreRepository _repo)
        {
            _context = context;
            this.repo = _repo;
        }        

        // GET: Enterprise_MVC_Core
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Enterprise_MVC_Cores.ToListAsync());

            return View(repo.GetData());
        }

        // GET: Enterprise_MVC_Core/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise_MVC_Core = await _context.Enterprise_MVC_Cores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (enterprise_MVC_Core == null)
            {
                return NotFound();
            }

            return View(enterprise_MVC_Core);
        }

        // GET: Enterprise_MVC_Core/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enterprise_MVC_Core/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(enterprise_MVC_Core);                
                //await _context.SaveChangesAsync();

                repo.Add(enterprise_MVC_Core);

                return RedirectToAction(nameof(Index));
            }
            return View(enterprise_MVC_Core);
        }

        // GET: Enterprise_MVC_Core/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enterprise_MVC_Core = await _context.Enterprise_MVC_Cores.FindAsync(id);
            var enterprise_MVC_Core = repo.FindById(id.Value);
            if (enterprise_MVC_Core == null)
            {
                return NotFound();
            }
            return View(enterprise_MVC_Core);
        }

        // POST: Enterprise_MVC_Core/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (id != enterprise_MVC_Core.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(enterprise_MVC_Core);
                    //await _context.SaveChangesAsync();

                    repo.Edit(enterprise_MVC_Core);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Enterprise_MVC_CoreExists(enterprise_MVC_Core.ID))
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
            return View(enterprise_MVC_Core);
        }

        // GET: Enterprise_MVC_Core/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enterprise_MVC_Core = await _context.Enterprise_MVC_Cores
            //    .FirstOrDefaultAsync(m => m.ID == id);
            var enterprise_MVC_Core = repo.FindById(id.Value);

            if (enterprise_MVC_Core == null)
            {
                return NotFound();
            }

            return View(enterprise_MVC_Core);
        }

        // POST: Enterprise_MVC_Core/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var enterprise_MVC_Core = await _context.Enterprise_MVC_Cores.FindAsync(id);
            //_context.Enterprise_MVC_Cores.Remove(enterprise_MVC_Core);
            //await _context.SaveChangesAsync();

            repo.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool Enterprise_MVC_CoreExists(int id)
        {
            //return _context.Enterprise_MVC_Cores.Any(e => e.ID == id);
            return repo.FindById(id) != null;
        }
    }
}
