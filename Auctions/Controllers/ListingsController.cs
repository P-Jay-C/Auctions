using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auctions.Data;
using Auctions.Models;
using Auctions.Data.Services;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

namespace Auctions.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingsService _listingsService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ListingsController(
                                  IListingsService listingsService, 
                                  IWebHostEnvironment webHostEnvironment)
        {
            _listingsService = listingsService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Listings
        public async Task<IActionResult> Index()
        {
              return _listingsService.GetAll() != null ? 
                          View(await _listingsService.GetAll().ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Listings'  is null.");
        }

        // GET: Listings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _listingsService.GetById((id));

            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingViewModel listing)
        {
            if(listing.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string fileName = listing.Image.FileName;
                string filePath = Path.Combine(uploadDir,fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    listing.Image.CopyTo(fileStream );
                }

                var listObj = new Listing()
                {
                    Title = listing.Title,
                    Description = listing.Description,
                    Price = listing.Price,
                    IdentityUserId = listing.IdentityUserId,
                    ImagePath = fileName
                    
                };

                await _listingsService.Add(listObj);
                return RedirectToAction("Index");
            }
            

            return View(listing);
        }

        //// GET: Listings/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Listings == null)
        //    {
        //        return NotFound();
        //    }

        //    var listing = await _context.Listings.FindAsync(id);
        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(listing);
        //}

        //// POST: Listings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,ImagePath,Issold,IndentityUserId")] Listing listing)
        //{
        //    if (id != listing.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(listing);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ListingExists(listing.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(listing);
        //}

        //// GET: Listings/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Listings == null)
        //    {
        //        return NotFound();
        //    }

        //    var listing = await _context.Listings
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(listing);
        //}

        //// POST: Listings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Listings == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Listings'  is null.");
        //    }
        //    var listing = await _context.Listings.FindAsync(id);
        //    if (listing != null)
        //    {
        //        _context.Listings.Remove(listing);
        //    }s

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ListingExists(int id)
        //{
        //  return (_context.Listings?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
