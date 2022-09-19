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
    public class VehiculoesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    var lista = db.Vehiculos.ToList();
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
                    var vehiculo = db.Vehiculos.Find(id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = vehiculo;
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
        public IActionResult Post(Vehiculo model)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.Matricula = model.Matricula;
                    vehiculo.Marca = model.Marca;
                    vehiculo.Color = model.Color;
                    vehiculo.Alquiler = model.Alquiler;
                    vehiculo.GarajeIdGaraje = model.GarajeIdGaraje;

                    db.Add(vehiculo);
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
        public IActionResult Put(Vehiculo model)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RENT_A_CAR_CANELLAContext db = new RENT_A_CAR_CANELLAContext())
                {
                    Vehiculo vehiculo = db.Vehiculos.Find(model.IdVehiculo);
                    vehiculo.Matricula = model.Matricula;
                    vehiculo.Marca = model.Marca;
                    vehiculo.Color = model.Color;
                    vehiculo.Alquiler = model.Alquiler;
                    vehiculo.GarajeIdGaraje = model.GarajeIdGaraje;

                    db.Entry(vehiculo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Registro actualizado";
                    oRespuesta.Data = vehiculo;
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
                    Vehiculo vehiculo = db.Vehiculos.Find(id);
                    db.Remove(vehiculo);
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
