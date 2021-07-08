using BankManagementSystem.Controllers;
using BankManagementSystem.Models;
using BankManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UserServiceUnitTesting
{
    public class UsersControllerTests
    {
        private Mock<IUserService> mock;
        private UsersController userController;
        private User newuser;

        public UsersControllerTests()
        {
            mock = new Mock<IUserService>();
            userController = new UsersController(mock.Object);
            newuser = new User()
            {
                UserId = "R-123",
                UserAccountNo = 1234123412341234,
                Name = "Yuvraj",
                UserName = "Yuvi123",
                Password = "Yuvi@123",
                GuardianType = "father",
                GuardianName = "Himanshu",
                Address = "ayz",
                Citizenship = "Indian",
                State = "Mp",
                Country = "India",
                Email = "gaga@gmail.com",
                Gender = "Male",
                MartialStatus = "single",
                Contact = 1234567890,
                BirthDate = new DateTime(1999, 12, 23),
                RegistrationDate = new DateTime(2021, 12, 23),
                AccountType = "salary",
                CitizenshipStatus = "normal",
                InitialDepositeAmount = 100000,
                BranchName = "Sukhliya",
                PanCard = "AAAAA1111H",
                RefAccountHolderName = "Himanshu",
                RefAccountHolderAddress = "xyz",
                RefAccountNo = 1111333399990000
            };
        }
        /// <summary>
        //Test for login
        /// </summary>
        [Fact]
        public void SignUp_ValidInput_ReturnsOkResult()
        {
            mock.Setup(p => p.AddUser(newuser)).Returns(Task.FromResult("User Added"));
            var response = (OkObjectResult)userController.SignUp(newuser).Result;
            Assert.Equal(200,response.StatusCode);
           
        }

        [Fact]
        public void SignUp_InValidInput_ReturnsBadRequest()
        {
            mock.Setup(p => p.AddUser(null)).Returns(Task.FromResult("Please Provide Data"));
            var result = (BadRequestObjectResult)userController.SignUp(null).Result;
            Assert.Equal(400, result.StatusCode);

        }

        [Fact]
        public void SignIn_ValidData_ReturnsOkResult()
        {
            mock.Setup(p => p.AuthenticateMember("Yuvi123","Yuvi@123")).Returns(Task.FromResult(newuser));
            var result = (OkObjectResult)userController.SignIn(new UserLogin() { UserName = "Yuvi123", Password = "Yuvi@123" }).Result;
            Assert.Equal(200,result.StatusCode);
            
        }

        [Fact]
        public void SignIn_InValidData_ReturnsBadRequest()
        {
            var result = (BadRequestObjectResult)userController.SignIn(new UserLogin() { UserName = null, Password = "Yuvi@123" }).Result;
            Assert.Equal(400, result.StatusCode);

        }

        [Fact]
        public void PutUser_ValidInput_ReturnsOkResult()
        {
            mock.Setup(p => p.UpdateUser("R-123",newuser)).Returns(Task.FromResult("User Updated"));
            var result = (OkObjectResult)userController.PutUser("R-123",newuser).Result;
            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public void PutUser_InValidInput_ReturnsBadRequest()
        {
            var result = (BadRequestResult)userController.PutUser("R-124", newuser).Result;
            Assert.Equal(400, result.StatusCode);

        }

        [Fact]
        public void GetUser_ValidData_ReturnsOkResult()
        {
            mock.Setup(p => p.GetUser("R-123")).Returns(Task.FromResult(newuser));
            var result = (OkObjectResult)userController.GetUser("R-123").Result;
            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public void GetUser_InValidData_ReturnsNotFoundResult()
        {
            var result = (NotFoundResult)userController.GetUser(null).Result;
            Assert.Equal(404, result.StatusCode);

        }



    }
}
