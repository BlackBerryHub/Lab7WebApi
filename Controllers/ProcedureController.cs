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
    public class ProcedureController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44306/api/");
        HttpClient client;

        public ProcedureController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Procedure> procedure = new List<Procedure>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "procedure").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                procedure = JsonConvert.DeserializeObject<List<Procedure>>(data);
            }
            return View(procedure);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Procedure procedure)
        {
            string data = JsonConvert.SerializeObject(procedure);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "procedure", content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Procedure documents = new Procedure();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "procedure/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                documents = JsonConvert.DeserializeObject<Procedure>(data);
            }
            return View("Create", documents);
        }

        [HttpPost]
        public ActionResult Edit(Procedure procedure)
        {
            string data = JsonConvert.SerializeObject(procedure);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "procedure/" + procedure.ID_Procedure, content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View("Create", procedure);
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "procedure/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}