using Microsoft.EntityFrameworkCore;
using RockaetseatAuction.API.Entities;
using RockaetseatAuction.API.Repositories;
namespace RockaetseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute() {
        
        var repository = new RockaeatseatAuctionDbContext();
        var today = DateTime.Now;
        return repository
            .Auctions
            .Include(auction => auction.Items)
            .First();
    }
}
