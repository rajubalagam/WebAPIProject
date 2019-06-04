using APICodeProject.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using WebAPIProject.Models;
using WebAPIProject.Repository;
using Xunit;

namespace APICodeProject.Tests
{

    /// <summary>
    /// The unit test class to test cats list by owner gender
    /// </summary>
    public class PetsControllerTests
    {
        public PetsController controller;        
        public Mock<IPetsRepository> repository;
        /// <summary>
        /// Test method to unit test the cats by owner gender
        /// </summary>
        [Fact]
        public void CatsByOwnerGenderTest()
        {
            List<RequestModel> ownerList = new List<RequestModel> { new RequestModel { Name = "Bob", Age = 23, Gender = "Male", Pets = new List<Pet> { new Pet { Name = "Garfield", Type = "Cat" } } } };
            List<ResponseModel> listOfPets = new List<ResponseModel> { new ResponseModel { Gender = "Male", Names = new List<string> { "Garfield" } } };

            var helper = new Mock<IPetsRepository>();
            var petsController = new PetsController(helper.Object);
            helper.Setup(p => p.GetOwners<List<RequestModel>>()).Returns(ownerList);
            helper.Setup(p => p.GetCatsByOwnerGender<List<ResponseModel>>(ownerList)).Returns(listOfPets);

            var pets = petsController.GetCatsByOwnerGender();

            Assert.True(listOfPets[0].Gender == pets[0].Gender);
            Assert.True(listOfPets[0].Names.Count == pets[0].Names.Count);         
        }
    }
}
