﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TvShowReader.Controllers
{
  public class AureliaController : Controller
  {
    // GET: Aurelia
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult GetLastSearches()
    {
      return View("_LastSearches");
    }
  }
}