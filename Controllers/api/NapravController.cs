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
    public class NapravController : ApiController
    {
        // GET: Naprav
        Model1 db = new Model1();
        public IEnumerable<Naprav> GetNaprav()
        {
            return db.Naprav.ToList();
        }

        public Naprav GetNaprav(int id)
        {
            return db.Naprav.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddNaprav(Naprav naprav)
        {
            try
            {
                db.Entry(naprav).State = EntityState.Added;
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
        public HttpResponseMessage UpdateNaprav(int id, Naprav naprav)
        {
            try
            {
                if (id == naprav.ID_Naprav)
                {
                    db.Entry(naprav).State = EntityState.Modified;
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
        public HttpResponseMessage DeleteNaprav(int id)
        {
            Naprav naprav = db.Naprav.Find(id);
            if (naprav != null)
            {
                db.Naprav.Remove(naprav);
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