using Microsoft.EntityFrameworkCore;
using RockaetseatAuction.API.Entities;

namespace RockaetseatAuction.API.Repositories;

public class RockaeatseatAuctionDbContext : DbContext
{
    //classe tradutora do bd
    // <entidades da tabela> TabelaDoDB
    public DbSet<Auction> Auctions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\nicol\\Downloads\\leilaoDbNLW.db");
    }

}
