using System;
using System.Collections.Generic;
using HairSalon;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers {
    public class HomeController : Controller {
        [HttpGet ("/")]
        public ActionResult Index () {
            return View ();
        }

        [HttpGet ("/Stylists")]
        public ActionResult StylistList () {
            return View ("Stylists", Stylist.GetAll ());
        }

        [HttpPost ("/Stylists")]
        public ActionResult Stylists () {
            Stylist newStylist = new Stylist (Request.Form["inputStylist"]);
            newStylist.Save ();
            return View (Stylist.GetAll ());
        }

        [HttpGet ("/Stylists/{id}")]
        public ActionResult ClientList (int id) {
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Stylist selectedStylist = Stylist.Find (id);
            List<Client> stylistClients = selectedStylist.GetClients ();
            model.Add ("stylist", selectedStylist);
            model.Add ("client", stylistClients);
            return View (model);
        }

        [HttpPost ("/Stylists/{id}")]
        public ActionResult AddClient (int id) {
            string clientName = Request.Form["inputClient"];
            Client newClient = new Client (clientName, id);
            newClient.Save ();
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Stylist selectedStylist = Stylist.Find (Int32.Parse (Request.Form["stylist-id"]));
            List<Client> stylistClients = selectedStylist.GetClients ();
            model.Add ("client", stylistClients);
            model.Add ("stylist", selectedStylist);
            return View ("ClientList", model);
        }

        [HttpPost ("/Stylists/{id}/Delete")]
        public ActionResult YoureFired (int id) {
            Stylist.DeleteStylist (id);
            Client.DeleteClients (id);
            return View ("Index");
        }

        [HttpPost ("/Stylists/Delete")]
        public ActionResult YoureAllFired () {
            Client.DeleteAll ();
            Stylist.DeleteAll ();
            return View ("Index");
        }

        [HttpPost ("/Clients/Delete")]
        public ActionResult DeleteClients () {
            Client.DeleteAll ();
            return View ("Index");
        }

        [HttpGet ("/Stylists/{id}/Update")]
        public ActionResult ClientUpdate (int id) {
            Client thisClient = Client.Find (id);
            return View (thisClient);
        }

        [HttpPost ("/Stylists/{id}/Update")]
        public ActionResult ClientEdit (int id) {
            Client thisClient = Client.Find (id);
            thisClient.UpdateClient (Request.Form["new-name"]);
            return RedirectToAction ("Stylists");
        }

    }
}