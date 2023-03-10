using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers;

public class StylistsController : Controller
{
  private readonly HairSalonContext _db;

  public StylistsController(HairSalonContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Client> model = _db.Clients.ToList();
    return View(model);
  }

  public ActionResult Create() {return View();}

  [HttpPost]
  public ActionResult Create(Stylist newStylist)
  {
    _db.Add(newStylist);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}
