using Games_Rental_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Net.Http;

namespace Games_Rental_MVC.Repositories
{
    public class ApiRentalRepository : IRepository<RentalHistories, int, string, string>
    {
       
        public async Task<IEnumerable<RentalHistories>> GetAll(string text, string text2)
        {

            List<RentalHistories> reservationList = new List<RentalHistories>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44366/api/RentalHistories"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<RentalHistories>>(apiResponse);
                }
            }
            return (IEnumerable<RentalHistories>)reservationList;
            
        }


        public Task<RentalHistories> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RentalHistories> Insert(Members Entity)
        {
            throw new NotImplementedException();
        }

        public Task<RentalHistories> Insert(RentalHistories Entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(RentalHistories Entity)
        {
            throw new NotImplementedException();
        }
    }
}
