using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var loan = _loanService.GetLoan(id);
            if (loan == null) return NotFound();
            return Ok(loan);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            var loans = _loanService.GetLoansByUser(userId);
            return Ok(loans);
        }

        [HttpPost("borrow")]
        public IActionResult Borrow([FromQuery] int bookId, [FromQuery] int userId)
        {
            _loanService.BorrowBook(bookId, userId);
            return Ok("Book borrowed successfully.");
        }

        [HttpPost("return/{loanId}")]
        public IActionResult Return(int loanId)
        {
            _loanService.ReturnBook(loanId);
            return Ok("Book returned successfully.");
        }
    }
}