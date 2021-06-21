using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integrate_dotnet_core_create_react_app.Business.Services;
using integrate_dotnet_core_create_react_app.Core.Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace integrate_dotnet_core_create_react_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetUsersController : Controller
    {
        private readonly TargetUserService _targetUserService;

        public TargetUsersController(TargetUserService targetUserService)
        {
            _targetUserService = targetUserService;
        }

        // GET: TargetUsers
        public async Task<IActionResult> Index()
        {
            return View(await _targetUserService.Get());
        }

        // GET: TargetUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetUser = _targetUserService.GetById(id.Value);
            if (targetUser == null)
            {
                return NotFound();
            }

            return View(targetUser);
        }

        // GET: TargetUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TargetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TargetUserRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                await _targetUserService.Create(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: TargetUsers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var targetUser = await _context.TargetUsers.Where(tu => tu.Id == id).SingleOrDefaultAsync();
        //    if (targetUser == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(targetUser);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TargetUserRequestDto targetUserRequestDto)
        {
            await _targetUserService.UpdateTargetUser(id, targetUserRequestDto);
            return NoContent();
        }

        // POST: TargetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Age")] TargetUser targetUser)
        //{
        //    if (id != targetUser.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(targetUser);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TargetUserExists(targetUser.id))
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
        //    return View(targetUser);
        //}

        // GET: TargetUsers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var targetUser = await _context.TargetUsers
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (targetUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(targetUser);
        //}

        //// POST: TargetUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var targetUser = await _context.TargetUsers.FindAsync(id);
        //    _context.TargetUsers.Remove(targetUser);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TargetUserExists(int id)
        //{
        //    return _context.TargetUsers.Any(e => e.Id == id);
        //}
    }
}
