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
    public class ProcedureController : ApiController
    {
        // GET: Procedure
        Model1 db = new Model1();
        public IEnumerable<Procedure> GetProcedure()
        {
            return db.Procedure.ToList();
        }

        public Procedure GetProcedure(int id)
        {
            return db.Procedure.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddProcedure(Procedure procedure)
        {
            try
            {
                db.Entry(procedure).State = EntityState.Added;
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
        public HttpResponseMessage UpdateProcedure(int id, Procedure procedure)
        {
            try
            {
                if (id == procedure.ID_Procedure)
                {
                    db.Entry(procedure).State = EntityState.Modified;
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
        public HttpResponseMessage DeleteProcedure(int id)
        {
            Procedure procedure = db.Procedure.Find(id);
            if (procedure != null)
            {
                db.Procedure.Remove(procedure);
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