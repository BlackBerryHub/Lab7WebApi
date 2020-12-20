using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Lab7WebApi.Models;

namespace Lab7WebApi.Controllers.api
{
    public class PacientsController : ApiController
    {
        // GET: Pacients
        Model1 db = new Model1();
        public IEnumerable<Pacients> GetPacients()
        {
            return db.Pacients.ToList();
        }

        public Pacients GetPacients(int id)
        {
            return db.Pacients.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddPacients(Pacients pacient)
        {
            try
            {
                db.Entry(pacient).State = EntityState.Added;
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdatePacients(int id, Pacients pacient)
        {
            try
            {
                if (id == pacient.ID_Pacinents)
                {
                    db.Entry(pacient).State = EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        public HttpResponseMessage DeletePacients(int id)
        {
            Pacients pacient = db.Pacients.Find(id);
            if (pacient != null)
            {
                db.Pacients.Remove(pacient);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }
        }

    }
}