using System.Collections.Generic;
using WebAPIProject.Models;

namespace WebAPIProject.Repository
{
    /// <summary>
    /// The helper class to support the service call
    /// </summary>
    public interface IPetsRepository 
    {
        /// <summary>
        /// The helper method that will support for all get api service calls
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        List<ResponseModel> GetCatsByOwnerGender<TResult>(List<RequestModel> listofOwners);

        /// <summary>
        /// Get owners helper method to get all owners and the pets
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        List<RequestModel> GetOwners<TResult>();
    }
}
