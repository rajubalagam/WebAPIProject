using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPIProject.Models;
using WebAPIProject.Repository;

namespace APICodeProject.Controllers
{
    /// <summary>
    /// Pets controller to handle the api methods
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        /// <summary>
        /// The interface for the service calls
        /// </summary>
        public IPetsRepository repository;

        public PetsController(IPetsRepository _repository)
        {            
            repository = _repository;
        }

        /// <summary>
        /// Get the cats by owner gender API method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ResponseModel> GetCatsByOwnerGender()
        {
            List<RequestModel> ownersList = new List<RequestModel>();
            IEnumerable<ResponseModel> catsByOwnerGender = new List<ResponseModel>();

            ownersList = repository.GetOwners<List<RequestModel>>();

            catsByOwnerGender = repository.GetCatsByOwnerGender<List<ResponseModel>>(ownersList);
            return catsByOwnerGender.ToList();
        }

    }
}
