using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockaetseatAuction.API.Entities;
using RockaetseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RockaetseatAuction.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        
       [HttpGet]
       [ProducesResponseType(typeof (Auction), StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status204NoContent)]

       public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentAuctionUseCase();
        var Result = useCase.Execute();

        if(Result is null)
        {
            return NoContent();
        }
        return Ok(Result);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return NotFound("Essa porra foi getzada");
    }


}

