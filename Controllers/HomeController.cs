using Microsoft.AspNetCore.Mvc;
using System;
using CD.Models;
using System.Collections.Generic;

namespace CD.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/artists")]
    public ActionResult Artists()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult ArtistForm()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult AddArtist()
    {
      Artist newArtists = new Artist(Request.Form["artist-name"]);
      List<Artist> allArtists = Artist.GetAll();
      return View("Artists", allArtists);
    }

    [HttpGet("/artists/{id}")]
    public ActionResult ArtistDetail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Music> artistMusic = selectedArtist.GetMusic();
      model.Add("artist", selectedArtist);
      model.Add("music", artistMusic);
      return View(model);
    }

    [HttpGet("/artists/{id}/music/new")]
    public ActionResult ArtistMusicForm(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Music> allMusic = selectedArtist.GetMusic();
      model.Add("artist", selectedArtist);
      model.Add("music", allMusic);
      return View(model);
    }

    [HttpPost("/music")]
    public ActionResult AddMusic()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(Int32.Parse(Request.Form["artist-id"]));
      List<Music> artistMusic = selectedArtist.GetMusic();
      string musicTitle = Request.Form["music-name"];
      int musicPrice = int.Parse(Request.Form["music-price"]);
      int musicYear = int.Parse(Request.Form["music-year"]);
      Music newMusic = new Music(musicTitle, musicPrice, musicYear);
      artistMusic.Add(newMusic);
      model.Add("music", artistMusic);
      model.Add("artist", selectedArtist);
      return View("ArtistDetail", model);
    }

    [HttpGet("/artists/search_by_artist")]
    public ActionResult ArtistSearch()
    {
      return View();
    }

    [HttpPost("/artists/results")]
    public ActionResult ArtistSearchResults()
    {
      List<Artist> allArtists = Artist.GetAll();
      List<Artist> matchedArtists = Artist.SearchArtists(allArtists, Request.Form["artist-search"]);
      return View(matchedArtists);
    }
  }
}
