using System.Diagnostics;
using DBS_BS.FormModels;
using Microsoft.AspNetCore.Mvc;
using DBS_BS.Models;

namespace DBS_BS.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
       /* _dbContext.Users.Add(new TweetEntity()
        {
            Content = "Test",
            Author = "a@a.cz"
        });*/
       // _dbContext.SaveChanges();
        
        return View(_dbContext.Users.ToList());
    }
    public IActionResult CreateTweet()
    {
        return View(new TweetFormModel());
    }
    [HttpPost]
    public IActionResult CreateTweet(TweetFormModel tweetFormModel)
    {
        AddTweet(tweetFormModel);
        return Redirect("Index");
    }

    public void AddTweet(TweetFormModel tweetFormModel)
    {
        _dbContext.Users.Add(new TweetEntity()
        {
            Content = tweetFormModel.Content,
            Author = tweetFormModel.Author,
            CreatedAt = DateTime.Now.ToString()
        });
        _dbContext.SaveChanges();
    }

    public IActionResult EditTweet(int id)
    {
        return View(_dbContext.Users.Where(i => i.TweetId == id).ToList()[0]);
    }
    [HttpPost]
    public IActionResult EditTweet(TweetEntity tweetEntity)
    {
        EditDBTweet(tweetEntity);
        return Redirect("/Home");
    }

    public void EditDBTweet(TweetEntity tweetEntity)
    {
        if (_dbContext.Users.Where(i => i.TweetId == tweetEntity.TweetId).ToList()[0].TweetId == tweetEntity.TweetId)
        {
            var tweet = _dbContext.Users.Where(i => i.TweetId == tweetEntity.TweetId).ToList()[0];
            tweet.Author = tweetEntity.Author;
            tweet.Content = tweetEntity.Content;
            tweet.UpdatedAt = DateTime.Now.ToString();
        }
        _dbContext.SaveChanges();
    }

    public IActionResult LikeTweet(int id)
    {
        var tweet = _dbContext.Users.Where(i => i.TweetId == id).ToList()[0];
        tweet.Likes++;
        _dbContext.SaveChanges();
        return Redirect("/Home");

    }
    public IActionResult DeleteTweet(int id)
    {
        var tweet = new TweetEntity() { TweetId = id };
        _dbContext.Users.Attach(tweet);
        _dbContext.Users.Remove(tweet);
        _dbContext.SaveChanges();
        return Redirect("/");
    }
}