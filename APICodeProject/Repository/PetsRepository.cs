using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using WebAPIProject.Models;

namespace WebAPIProject.Repository
{
    /// <summary>
    /// The helper class to support the service call
    /// </summary>
    public class PetsRepository : IPetsRepository
    {
        IConfiguration _config;

        public PetsRepository(IConfiguration config)
        {
            _config = config;
        }
        /// <summary>
        /// Get all owners based on the json url 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public List<RequestModel> GetOwners<TResult>()
        {
            List<RequestModel> owners = new List<RequestModel>();
            string address = _config.GetSection("MySettings").GetSection("OwnerAPIUrl").Value;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync(address).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                owners = JsonConvert.DeserializeObject<List<RequestModel>>(stringData);
            }
            return owners;
        }


        /// <summary>
        /// The helper method that will support for all get api service calls
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<ResponseModel> GetCatsByOwnerGender<TResult>(List<RequestModel> listOfPets)
        {
            var list = listOfPets.GroupBy(x => x.Gender, p => p.Pets,
                                    (key, g) => new ResponseModel
                                    {
                                        Gender = key,
                                        Names =
                                    g.Where(v => v != null).SelectMany(p => p)
                                    .Where(p => p.Type == Common.PetType.Cat.ToString())
                                    .OrderBy(p => p.Name).Select(p => p.Name).ToList()
                                    });
            return list.ToList();
        }
    }
}
