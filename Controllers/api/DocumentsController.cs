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
    public class DocumentsController : ApiController
    {
        // GET: Documents
        Model1 db = new Model1();
        public IEnumerable<Documents> GetDocuments()
        {
            return db.Documents.ToList();
        }

        public Documents GetDocuments(int id)
        {
            return db.Documents.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddDocument(Documents documents)
        {
            try
            {
                db.Entry(documents).State = EntityState.Added;
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch(Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateDocument(int id, Documents documents)
        {
            try
            {
                if(id == documents.ID_Documents)
                {                 
                    db.Entry(documents).State = EntityState.Modified;
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
        public HttpResponseMessage DeleteDocument(int id)
        {
            Documents document = db.Documents.Find(id);
            if(document != null)
            {
                db.Documents.Remove(document);
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