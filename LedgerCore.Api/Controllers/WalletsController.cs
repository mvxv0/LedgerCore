using LedgerCore.Application.DTOs;
using LedgerCore.Application.Exceptions;
using LedgerCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LedgerCore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletsController(IWalletService walletService) {
            _walletService = walletService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WalletResponseDto>> GetById(Guid id) 
        {
            var wallet = await _walletService.GetByIdAsync(id);
            if (wallet is null) return NotFound();

            return Ok(wallet);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<WalletResponseDto>>> GetByUserId(Guid userId)
        {
            var wallets = await _walletService.GetByUserIdAsync(userId);
            return Ok(wallets);
        }

        [HttpPost("deposit")]
        public async Task<ActionResult<TransactionResponseDto>> Deposit(DepositDto dto)
        {
            try
            {
                var result = await _walletService.DepositAsync(dto);
                return Ok(result);
            }
            catch (WalletNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidAmountException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
