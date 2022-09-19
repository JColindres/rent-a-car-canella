using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTservice.Models;
using RESTservice.Models.Response;

namespace RESTservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarajesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    var lista = db.Garajes.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lista;
                    oRespuesta.Mensaje = "Registros retornados";
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
                return Ok(oRespuesta.Mensaje);
            }
            return Ok(oRespuesta.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    var garaje = db.Garajes.Find(id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = garaje;
                    oRespuesta.Mensaje = "Registros encontrado";
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta.Data);
        }

        [HttpPost]
        public IActionResult Post(Garaje model)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    Garaje garaje = new Garaje();
                    garaje.Nombre = model.Nombre;

                    db.Add(garaje);
                    db.SaveChanges();

                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Registro agregado";

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Put(Garaje model)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    Garaje garaje = db.Garajes.Find(model.IdGaraje);
                    garaje.Nombre = model.Nombre;

                    db.Entry(garaje).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Registro actualizado";
                    oRespuesta.Data = garaje;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta.Data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    Garaje garaje = db.Garajes.Find(id);
                    db.Remove(garaje);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Registro elimando";
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
