using Microsoft.AspNetCore.Mvc;
using System;

namespace assignment1C_.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDBcontext _context;

        public ContactController(ApplicationDBcontext context)
        {
            _context = context;
        }


        public async Task<IActionResult> index ()
        {
            var contact = await context.manager.Include(c  => c.Category).ToListAsync();
            return View(contact);




        }

        public async Task<IActionResult> details (int id)
        {
            var contact = await _context.manager.Include(c => c.Category).FristorDelfaultAsynce(c => c.contactId == id);
            if (contact == null) return NotFound();
            return View(contact);

        }


        public async Task<IActionResult> upsert (int? id)
        {
            if (id == null)
            {
                return View(new manager());
            }
            var contact = await _context.manager.FindAsync(id);
            if (contact == null) return NotFound();

            return View(contact);

        }

        [HttpGet]
        public async Task<IActionResult> upsert (manager contact)
        {

            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            if (contact.contactId == 0)
            {
                _context.manager.Add(contact);
            }

            else
            { 
                _context.manager.update(contact);
            }


            await _context.SaveChangesAsync();

           return RedirectToAction("Index");

        }


        public async Task<IActionResult> delete(int id)
        {
            var contact == await _context.manager.Findasync(id);

            if (contact == null) return NotFound();

            return View(contact);


        }


        [HttpPost]
        public async Task<IActionResult> deleteConfirmed (int id)
        {
            var contact = await _context.manager.Findasync(id);
            if (contact == null) return NotFound(); 

            _context.manager.Remove(contact);
            await _context.SavechangesAsync();
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
