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
    public class PacientsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44306/api/");
        HttpClient client;

        public PacientsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Pacients> pacient = new List<Pacients>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "pacients").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                pacient = JsonConvert.DeserializeObject<List<Pacients>>(data);
            }
            return View(pacient);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Pacients pacient)
        {
            string data = JsonConvert.SerializeObject(pacient);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "pacients", content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Pacients documents = new Pacients();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "pacients/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                documents = JsonConvert.DeserializeObject<Pacients>(data);
            }
            return View("Create", documents);
        }

        [HttpPost]
        public ActionResult Edit(Pacients pacient)
        {
            string data = JsonConvert.SerializeObject(pacient);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "pacients/" + pacient.ID_Pacinents, content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View("Create", pacient);
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "pacients/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}