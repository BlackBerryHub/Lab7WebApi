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
    public class EquipmentsController : ApiController
    {
        // GET: Equipments
        Model1 db = new Model1();
        public IEnumerable<Equipments> GetEquipments()
        {
            return db.Equipments.ToList();
        }

        public Equipments GetEquipments(int id)
        {
            return db.Equipments.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddEquipments(Equipments equipments)
        {
            try
            {
                db.Entry(equipments).State = EntityState.Added;
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
        public HttpResponseMessage UpdateEquipments(int id, Equipments equipments)
        {
            try
            {
                if (id == equipments.ID_Equipment)
                {
                    db.Entry(equipments).State = EntityState.Modified;
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
        public HttpResponseMessage DeleteEquipments(int id)
        {
            Equipments equipments = db.Equipments.Find(id);
            if (equipments != null)
            {
                db.Equipments.Remove(equipments);
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