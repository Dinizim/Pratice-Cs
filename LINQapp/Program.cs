namespace LINQapp;

internal class Program
{
    static void Main(string[] args)
    {
        int year = 1991;
        int month = 12;
        var Songs = new List<Songs>
        {
            new Songs(1, "Bohemian Rhapsody", "Queen", new DateTime(1975, 10, 31)),
            new Songs(2, "Smells Like Teen Spirit", "Nirvana", new DateTime(1991, 9, 10)),
            new Songs(3, "Hotel California", "Eagles", new DateTime(1976, 12, 8)),
            new Songs(4, "One", "Metallica", new DateTime(1989, 1, 2)),
            new Songs(5, "November rain", "Guns N' Roses", new DateTime(1991, 6, 8))
        };


        Console.WriteLine("Songs released in " + year + "\n");

        var songsOnYear = Songs
            .Where(x => x.RealeaseDate.Year == year)
            .ToList();

        foreach (var item in songsOnYear)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("\nSongs released at month " + month + "\n");

        var songsOnMonth = Songs
            .Where(x => x.RealeaseDate.Month == month)
            .ToList();

        foreach (var item in songsOnMonth)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("\nReturn Songs in alphabetical order.\n");

        var songsOrder = Songs
            .OrderBy(x => x.Name)
            .ToList();

        foreach (var item in songsOrder)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("\nLast two songs registered in alphabetical order\n");

        var lastTwoSongs = Songs
            .TakeLast(2)
            .OrderBy(x => x.Name)
            .ToList();

        foreach (var song in lastTwoSongs)
        {
            Console.WriteLine(song.ToString());
        }


    }
}
