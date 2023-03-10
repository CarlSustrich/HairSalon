using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers;

public class ClientsController : Controller
{
  private readonly HairSalonContext _db;

  public ClientsController(HairSalonContext db)
  {
    _db = db;
  }

  public ActionResult Create()
  {
    ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName");
    return View();
  }
}
