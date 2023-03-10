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

  public ActionResult Create(int stylistId)
  {
    if(_db.Stylists.ToList().Count == 0)
    {
      ViewBag.Bool = false;
    }
    ViewBag.TargetStylist = stylistId;
    ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName", new {value = stylistId});
    return View();
  }

  [HttpPost]
  public ActionResult Create(Client newClient)
  {
    _db.Clients.Add(newClient);
    _db.SaveChanges();
    return RedirectToAction("Index", "Stylists");
  }
}
