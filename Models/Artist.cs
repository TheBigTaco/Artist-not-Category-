using System;
using System.Collections.Generic;

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
  }
}
