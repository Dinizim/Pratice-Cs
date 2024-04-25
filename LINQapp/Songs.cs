using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQapp;
public class Songs
{
    public Songs(int id, string name, string band, DateTime realeaseDate)
    {
        Id = id;
        Name = name;
        Band = band;
        RealeaseDate = realeaseDate;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Band { get; set; }
    public DateTime RealeaseDate { get; set; }

    public override string ToString() => $"ID :{Id} || Name : {Name} || Band : {Band} || Realease Date : {RealeaseDate.Year}";
}
