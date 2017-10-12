using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CD.Models
{
  public class Artist
  {
    public string Maker { get; set; }
    public int Id { get; set; }
    private static List<Artist> _instances = new List<Artist> {};
    private List<Music> _music;

    public Artist (string artistName)
    {
      Maker = artistName;
      _instances.Add(this);
      Id = _instances.Count;
      _music = new List<Music>{};
    }
    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public List<Music> GetMusic()
    {
      return _music;
    }
    public void AddMusic(Music music)
    {
      _music.Add(music);
    }
    public static List<Artist> SearchArtists(List<Artist> artists, string searched)
    {
      Regex regex = new Regex($@"{searched}", RegexOptions.IgnoreCase);
      List<Artist> searchMatch = new List<Artist> {};
      foreach(Artist artist in artists)
      {
        Match match = regex.Match(artist.Maker);
        if (match.Success)
        {
          searchMatch.Add(artist);
        }
      }
      return searchMatch;
    }
  }
}
