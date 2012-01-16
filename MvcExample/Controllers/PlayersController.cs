﻿using System.Web.Mvc;
using MvcExample.Models.Players;
using Simpler.Web;

namespace MvcExample.Controllers
{
    public class PlayersController : ResourceController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Index(outputs => View(outputs.Model));
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            return Show(inputs => new PlayerKey(id),
                        outputs => View(outputs.Model));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return Edit(inputs => new PlayerKey(id),
                        outputs => View(outputs.Model));
        }

        [HttpPost]
        public ActionResult Update(PlayerEdit model)
        {
            return !ModelState.IsValid
                       ? Edit(inputs => new PlayerKey(model.PlayerId),
                              outputs => View(outputs))
                       : Update(inputs => model,
                                outputs => RedirectToShow(new {id = model.PlayerId}));
        }
    }
}
