using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class VehiculoController : Controller
    {
        Uri Baseurl = new Uri("https://localhost:7256/api");
        HttpClient client;

        public VehiculoController()
        {
            client = new HttpClient();
            client.BaseAddress = Baseurl;
        }

        public ActionResult Index()
        {
            List<VehiculoViewModel> modelList = new List<VehiculoViewModel>();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/Vehiculoes").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                if (data != null)
                {
                    modelList = JsonConvert.DeserializeObject<List<VehiculoViewModel>>(data);

                }
            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehiculoViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + "/Vehiculoes", content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            VehiculoViewModel student = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7156/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Vehiculoes/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VehiculoViewModel>();
                    readTask.Wait();

                    student = readTask.Result;
                }
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(VehiculoViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress + "/Vehiculoes", content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7156/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Vehiculoes/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
