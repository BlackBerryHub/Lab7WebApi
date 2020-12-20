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
    public class DocumentsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44306/api/");
        HttpClient client;

        public DocumentsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Documents> documents = new List<Documents>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "documents").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                documents = JsonConvert.DeserializeObject<List<Documents>>(data);
            }
            return View(documents);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Documents document)
        {
            string data = JsonConvert.SerializeObject(document);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "documents", content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Documents documents = new Documents();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "documents/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                documents = JsonConvert.DeserializeObject<Documents> (data);
            }
            return View("Create", documents);
        }

        [HttpPost]
        public ActionResult Edit(Documents document)
        {
            string data = JsonConvert.SerializeObject(document);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "documents/"+document.ID_Documents, content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View("Create", document);
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "documents/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}