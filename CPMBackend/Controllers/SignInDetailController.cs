using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInDetailController : ControllerBase
    {
        private readonly SignInDetailContext _context;

        public SignInDetailController(SignInDetailContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignInDetail>>> GetSignInDetails()
        {
            if (_context.SignInDetails == null)
            {
                return NotFound();
            }
            return await _context.SignInDetails.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SignInDetail>> GetSignInDetail(int id)
        {   
            if (_context.SignInDetails == null)
            {
                return NotFound();
            }

            var signInDetail = await _context.SignInDetails.FindAsync(id);

            if (signInDetail == null)
            {
                return NotFound();
            }

            return signInDetail;                
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignInDetail(int id, SignInDetail signInDetail)
        {
            if (signInDetail == null || signInDetail.SignInDetailId != id)
            {
                return BadRequest("Sign-in data is incorrect.");
            }

            var existingSignInDetail = await _context.SignInDetails.FindAsync(id);
            if (existingSignInDetail == null)
            {
                return NotFound($"Sign-in details with id {id} not found.");
            }

            existingSignInDetail.UserEmail = signInDetail.UserEmail;
            existingSignInDetail.UserPassword = signInDetail.UserPassword;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult<SignInDetail>> PostSignInDetail(SignInDetail signInDetail)
        {
            if(_context.SignInDetails == null)
            {
                return Problem("Entity set 'SignInDetailContext.SignInDetails' is null.");

            }
            _context.SignInDetails.Add(signInDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignInDetail", new { id = signInDetail.SignInDetailId }, signInDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignInDetail(int id)
        {
            var signInDetail = await _context.SignInDetails.FindAsync(id);
            if (signInDetail == null)
            {
                return NotFound($"Sign-in details with id {id} not found.");
            }

            _context.SignInDetails.Remove(signInDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool SignInDetailExists(int id)
        //{

        //}
    }
}