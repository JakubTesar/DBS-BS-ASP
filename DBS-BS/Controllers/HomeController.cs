﻿using System.Diagnostics;
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
        _dbContext.Users.Add(new TweetEntity()
        {
            Content = "Test",
            Author = "a@a.cz"
        });
        _dbContext.SaveChanges();
        
        return View(_dbContext.Users.Where(i =>i.TweetId == 1).ToList());
    }
}