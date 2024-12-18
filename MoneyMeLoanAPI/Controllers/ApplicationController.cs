using Microsoft.AspNetCore.Mvc;
using MoneyMeLoanAPI.Data;
using MoneyMeLoanAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyMeLoanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/application
        [HttpGet]
        public ActionResult<IEnumerable<Application>> GetApplications()
        {
            return Ok(_context.Applications.ToList());
        }

        // GET: api/application/{id}
        [HttpGet("{id}")]
        public ActionResult<Application> GetApplication(int id)
        {
            var application = _context.Applications.Find(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        // POST: api/application
        [HttpPost]
        public ActionResult<Application> CreateApplication([FromBody] Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate age
            if (application.DateOfBirth == null ||
                (DateTime.Now.Year - application.DateOfBirth.Value.Year) < 18 ||
                (DateTime.Now.Year - application.DateOfBirth.Value.Year == 18 && DateTime.Now < application.DateOfBirth.Value.AddYears(18)))
            {
                return BadRequest("Applicant must be at least 18 years old.");
            }

            // Blacklisted mobile numbers
            var blacklistedMobileNumbers = new List<string> { "1234567890", "0987654321" };
            if (blacklistedMobileNumbers.Contains(application.Mobile))
            {
                return BadRequest("Mobile number is blacklisted.");
            }

            // Blacklisted email domains
            var blacklistedDomains = new List<string> { "blacklist.com", "spam.com" };
            var emailDomain = application.Email.Split('@').Last();
            if (blacklistedDomains.Contains(emailDomain))
            {
                return BadRequest("Email domain is blacklisted.");
            }

            // Calculate repayment details
            const decimal establishmentFee = 300.00m;
            decimal interest = application.AmountRequired * 0.10m; // Example interest calculation
            application.RepaymentAmount = application.AmountRequired + interest + establishmentFee;
            application.EstablishmentFee = establishmentFee;
            application.TotalInterest = interest;

            // Save application
            _context.Applications.Add(application);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetApplication), new { id = application.Id }, application);
        }



    }
}
