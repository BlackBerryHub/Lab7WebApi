﻿using Newtonsoft.Json;
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
    public class NapravController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44306/api/");
        HttpClient client;

        public NapravController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Naprav> naprav = new List<Naprav>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "naprav").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                naprav = JsonConvert.DeserializeObject<List<Naprav>>(data);
            }
            return View(naprav);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Naprav naprav)
        {
            string data = JsonConvert.SerializeObject(naprav);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "naprav", content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Naprav documents = new Naprav();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "naprav/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                documents = JsonConvert.DeserializeObject<Naprav>(data);
            }
            return View("Create", documents);
        }

        [HttpPost]
        public ActionResult Edit(Naprav naprav)
        {
            string data = JsonConvert.SerializeObject(naprav);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "naprav/" + naprav.ID_Naprav, content).Result;
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View("Create", naprav);
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "naprav/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}