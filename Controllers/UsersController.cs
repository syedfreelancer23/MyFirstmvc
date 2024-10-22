
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

using MyFirstmvc.Models;
using MyFirstmvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure; // Add this line if UsersContext is in the Data namespace

namespace MyFirstmvc.Controllers
{
    public class UsersController : Controller
    {
         
        private readonly ILogger _logger;
        // GET: UsersController
         private readonly UsersContext _context;
  public UsersController(UsersContext context)
        {
            _logger = context.GetService<ILogger<UsersController>>();
            _context = context;
        }

public async Task<IActionResult> Index()    
{
  
    //_logger.Log("Hello from UsersController.Index()");
    return View(await _context.Users.FromSqlRaw("select * from Users").ToListAsync());
  
   //return View(await _context.Users.ToListAsync());
}
        // GET: Users/Details/5
public async Task<IActionResult> Details(int? id)
        {
                if (id == null)
            {
                return NotFound();
            }

            #region  working code commented
            /*
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
             */ 
             #endregion
var user =await _context.Users.FromSql($"select * from users where ID={id}").FirstOrDefaultAsync();
           if(user==null)
           {
            return NotFound();
           }
            return View(user);
        }
         // GET: Users/Create
public IActionResult Create()
{
    return View();

}
// POST: Users/Create
// To protect from overposting attacks, enable the specific properties you want to bind to, for 
// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("ID,Name,Email,Password,PhoneNumber,IsActive")] Users user)
{

    if (ModelState.IsValid)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    TempData["ConfirmationMessage"] = "Customer succesfully created";
    return View(user);
}

// GET: Users/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var user = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
    if (user == null)
    {
        return NotFound();
    }

    return View(user);
}

// POST: Users/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{

    var user = await _context.Users.FindAsync(id);
    if (user != null)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
}

 // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
}
}
