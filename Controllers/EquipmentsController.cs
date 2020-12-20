using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Lab7WebApi.Models;
using System.Text;

namespace Lab7WebApi.Controllers
{
    public class EquipmentsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44306/api/");
        HttpClient client;

        public EquipmentsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Equipments> equipment = new List<Equipments>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "equipments").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                equipment = JsonConvert.DeserializeObject<List<Equipments>>(data);
            }
            return View(equipment);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Equipments equipment)
        {
            string data = JsonConvert.SerializeObject(equipment);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "equipments", content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Equipments documents = new Equipments();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "equipments/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                documents = JsonConvert.DeserializeObject<Equipments>(data);
            }
            return View("Create", documents);
        }

        [HttpPost]
        public ActionResult Edit(Equipments equipment)
        {
            string data = JsonConvert.SerializeObject(equipment);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "equipments/" + equipment, content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View("Create", equipment);
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "equipments/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}