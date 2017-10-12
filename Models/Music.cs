using System;
using System.Collections.Generic;

namespace CD.Models
{
  public class Music
  {
    public string Record { get; set; }
    public int Price { get; set; }
    public int Year { get; set; }
    public int Id { get; set; }

    private static List<Music> _instances = new List<Music> {};

    public Music (string title, int price, int year)
    {
      Record = title;
      Price = price;
      Year = year;
      Id = _instances.Count;
      _instances.Add(this);
    }

    public List<Music> GetAll ()
    {
      return _instances;
    }

    public void ClearAll()
    {
      _instances.Clear();
    }

    public static Music Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
