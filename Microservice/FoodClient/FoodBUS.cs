using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoodClient
{
    class FoodBUS
    {
        String URL = "http://tnpu.somee.com/api/food";
        public List<Food> GetAll()
        {
            WebClient client = new WebClient();
            String response = client.DownloadString(URL);
            List<Food> foodlist = JsonConvert.DeserializeObject<List<Food>>(response);
            return foodlist;
        }

        public List<Food> Seacrh(String keyword)
        {
            WebClient client = new WebClient();
            String response = client.DownloadString(URL + "/search/" + keyword);
            List<Food> foodlist = JsonConvert.DeserializeObject<List<Food>>(response);
            return foodlist;
        }

        public Food GetFoodDetails(int id)
        {
            WebClient client = new WebClient();
            String response = client.DownloadString(URL + "/" + id);
            Food food = JsonConvert.DeserializeObject<Food>(response);
            return food;
        }

        public bool AddNewFood(Food newfood)
        {
            String data = JsonConvert.SerializeObject(newfood);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString(URL, "POST", data);
            bool result = bool.Parse(response);
            return result;
        }

        public bool UpdateFood(Food newfood)
        {
            String data = JsonConvert.SerializeObject(newfood);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString(URL +"/"+ newfood.Id, "PUT", data);
            bool result = bool.Parse(response);
            return result;
        }

        public bool DeleteFood(int id)
        {
            WebClient client = new WebClient();
            String response = client.UploadString(URL + "/" + id, "DELETE", "");
            return bool.Parse(response);
        }
    }
}
