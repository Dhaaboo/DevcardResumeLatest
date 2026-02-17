using DevcardResume.Data;
using DevcardResume.Data.Models;
using DevcardResume.Data.Repo;
using DevcardResume.Data.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevcardResume.Controllers
{
    public class PeopleController : Controller
    {
        private readonly APPDBC _dbs;
        private readonly IDataProtector _dbPro;
        private readonly IPerRepo _Repo;

        public PeopleController(APPDBC db, IDataProtectionProvider provider, PeopleDataPro _dtPro, IPerRepo Repo)
        {
            _dbs = db;
            _Repo = Repo;
            _dbPro = provider.CreateProtector(_dtPro.PeopleInfo);
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(await _Repo.GetPersonAsync());
            //return View(await _dbs._Peoples.ToListAsync());
        }

        // GET: People/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                if (id == string.Empty)
                {
                    Response.StatusCode = 404;
                    return View("NotFound", id);
                }

                var _Pl = await _dbs._Peoples.FirstOrDefaultAsync(m => m.PID  == Convert.ToInt32(_dbPro.Unprotect( id)));
                if (_Pl == null)
                {
                    Response.StatusCode = 404;
                    return View("NotFound", id);
                }
                return View(_Pl);
            }
            catch(Exception ex)
            {
                return NotFound(); //+ ex.ToString();
            }
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PID,FirstName,LastName,City")] People people)
        {
            if (ModelState.IsValid)
            {
                _dbs.Add(people);
                await _dbs.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }

        // GET: People/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(String? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("NotFound", id);
            }
            int _decpid = Convert.ToInt32(_dbPro.Unprotect(id));
            var _Pr = await _dbs._Peoples.FirstOrDefaultAsync(m => m.PID == _decpid);
            //var people = await _dbs._Peoples.FindAsync(id);
            if (_Pr == null)
            {
                Response.StatusCode = 404;
                return View("NotFound", _decpid);
            }
            return View(_Pr);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PID,FirstName,LastName,City")] People people)
        {
            if (id != people.PID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbs.Update(people);
                    await _dbs.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleExists(people.PID))
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
            return View(people);
        }

        // GET: People/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(String? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("NotFound", id);
            }

            int _decpid = Convert.ToInt32(_dbPro.Unprotect(id));
            var _Pr = await _dbs._Peoples.FirstOrDefaultAsync(m => m.PID == _decpid);
           // var people = await _dbs._Peoples.FirstOrDefaultAsync(m => m.PID == id);
            if (_Pr == null)
            {
                Response.StatusCode = 404;
                return View("InfoNotFound", _decpid);
            }

            return View(_Pr);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var people = await _dbs._Peoples.FindAsync(id);
            if (people != null)
            {
                _dbs._Peoples.Remove(people);
            }

            await _dbs.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleExists(int id)
        {
            return _dbs._Peoples.Any(e => e.PID == id);
        }
    }
}
