using System.Text;
using System.Text.Json.Serialization;
using CRUDUsingWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDUsingWebApi.Controllers
{
   
    public class StudentController : Controller
    {
        private string url = "https://localhost:7022/api/StudentAPI";
        HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(std);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + "/" + id).Result; // safer URL
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content?.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "Application/JSON");
            HttpResponseMessage response = client.PutAsync($"{url}/{std.Id}", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(std);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           
            HttpResponseMessage response = client.DeleteAsync(url + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("error");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync($"{url}/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var std = JsonConvert.DeserializeObject<Student>(result);

                if (std != null)
                {
                    return View(std);
                }
            }

            return NotFound();
        }


    }
}
