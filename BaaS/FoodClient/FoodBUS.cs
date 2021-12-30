using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodClient
{
    class FoodBUS
    {
        static IFirebaseConfig config = new FirebaseConfig
        { BasePath = "https://tnpu-8713c-default-rtdb.asia-southeast1.firebasedatabase.app/" };
        static FirebaseClient client = new FirebaseClient(config);
        public async void ListenFirebase(DataGridView gridFood)
        {
            EventStreamResponse response = await client.OnAsync("food",
                added: (sender, args, context) => { UpdateDataGridView(gridFood); },
                changed: (sender, args, context) => { UpdateDataGridView(gridFood); },
                removed: (sender, args, context) => { UpdateDataGridView(gridFood); }
            );
        }
        private void UpdateDataGridView(DataGridView gridFood)
        {
            List<Food> foodlist = GetAll();
            gridFood.BeginInvoke(new MethodInvoker(delegate {
                gridFood.DataSource = foodlist;
            }));

        }
        public List<Food> GetAll()
        {
            FirebaseResponse response = client.Get("food");
            Dictionary<String, Food> dictFoodList = response.ResultAs<Dictionary<String, Food>>();
            return dictFoodList.Values.ToList();
        }

        public Food GetFoodDetails(int id)
        {
            FirebaseResponse response = client.Get("food/F" + id);
            Food food = response.ResultAs<Food>();
            return food;
        }
        private String GetKeyByCode(int id)
        {
            FirebaseResponse response = client.Get("food");
            Dictionary<String, Food> dictFood = response.ResultAs<Dictionary<String, Food>>();
            String key = dictFood.FirstOrDefault(x => x.Value.Id == id).Key;
            return key;
        }
        public List<Food> Search(String keyword)
        {
            List<Food> foodlist = new List<Food>();
            foreach (var item in GetAll())
            {
                if (item.Name.ToLower().Contains(keyword.ToLower()))
                {
                    foodlist.Add(item);
                }
            }
            return foodlist;
        }
        public bool AddNewFood(Food newfood)
        {
            //client.Push("food", newfood);
            client.Set("food/F" + newfood.Id, newfood); //custom key 
            return true;
        }

        public bool UpdateFood(Food newfood)
        {
            try
            {
                String key = GetKeyByCode(newfood.Id);
                if (String.IsNullOrEmpty(key)) return false; 
                client.Set("food/" + key, newfood);
                return true;
            }
            catch { return false; }
        }
        public bool DeleteFood(int id)
        {
            try
            {
                String key = GetKeyByCode(id);
                if (String.IsNullOrEmpty(key)) return false; 
                client.Delete("food/" + key);
                return true;
            }
            catch { return false; }
        }
    }
}
