using System;
using System.Collections.Generic;

class Song
{
    string name;
    string author;
    Song prev;

    public void Name(string n)
    {
        name = n;
    }

    public void Author(string a)
    {
        author = a;
    }

    public void Prev(Song p)
    {
        prev = p;
    }
    
    public string Title()
        {
            return name + " - " + author;
        }

    public void Print()
    {
        Console.WriteLine(Title());
    }

    public override bool Equals(object d)
    {
        if (d == null || !(d is Song))
        {
            return false;
        }

        Song other = (Song)d;

        return name == other.name && author == other.author;
    }
}

class Program
{
    static void Main()
    {
        List<Song> songs = new List<Song>();

        Song song1 = new Song();
        song1.Name("Династия");
        song1.Author("Villian");
        song1.Prev(null);

        Song song2 = new Song();
        song2.Name("Prada party");
        song2.Author("Kai angel");
        song2.Prev(song1);

        Song song3 = new Song();
        song3.Name("Narcotic");
        song3.Author("9mice");
        song3.Prev(song2);

        Song song4 = new Song();
        song4.Name("Автозаправка");
        song4.Author("Темный принц");
        song4.Prev(song3);

        songs.Add(song1);
        songs.Add(song2);
        songs.Add(song3);
        songs.Add(song4);

        foreach (Song song in songs)
        {
            song.Print();
        }

        if (songs[0].Equals(songs[1]))
        {
            Console.WriteLine("Песни одинаковые");
        }
        else
        {
            Console.WriteLine("Песни разные");
        }
    }
}