using assignment1C_.Controllers;
using assignment1C_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace assignment1C_.Models
{
    public class ContactController : Controller
    {
        private readonly ApplicationDBcontext _context;

       
        
        public ContactController(ApplicationDBcontext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var contact = await _context.Manager.Include(c => c.CategoryId).ToListAsync();

            return View(contact);




        }

        public async Task<IActionResult> Details(int id)
        {
            var contact = await _context.Manager.Include(c => c.CategoryId).FirstOrDefaultAsync(c => c.ContactId == id);
            if (contact == null) return NotFound();
            return View(contact);

        }


        public async Task<IActionResult> upsert (int? id)
        {
            if (id == null)
            {
                return View(new Manager());
            }
            var contact = await _context.Manager.FindAsync(id);
            if (contact == null) return NotFound();

            return View(contact);

        }

        [HttpGet]
        public async Task<IActionResult> upsert (Manager contact)
        {

            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            if (contact.ContactId == 0)
            {
                _context.Manager.Add(contact);
            }

            else
            { 
                _context.Manager.Update(contact);
            }


            await _context.SaveChangesAsync();

           return RedirectToAction("Index");

        }


        public async Task<IActionResult> delete(int id)
        {
            var contact = await _context.Manager.FindAsync(id);

            if (contact == null) return NotFound();

            return View(contact);


        }


        [HttpPost]
        public async Task<IActionResult> deleteConfirmed (int id)
        {
            var contact = await _context.Manager.FindAsync(id);
            if (contact == null) return NotFound(); 

            _context.Manager.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");



        }











        // firstName
        // lastName
        // phoneNumber
        // email
        // categoryId
        // organization


    }
}
