using BankManagementSystem.Models;
using BankManagementSystem.Repository;
using BankManagementSystem.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UserServiceUnitTesting
{
    public class UsersServiceTests
    {
        private Mock<IUserRepository> mock;
        private UserService userService;
        private User newuser;

        public UsersServiceTests()
        {
            mock = new Mock<IUserRepository>();
            userService = new UserService(mock.Object);
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
                Contact = 1234567890
            ,
                BirthDate = new DateTime(1999, 12, 23),
                RegistrationDate = new DateTime(2021, 12, 23),
                AccountType = "salary",
                CitizenshipStatus = "normal",
                InitialDepositeAmount = 100000,
                BranchName = "Sukhliya",
                PanCard = "AAAAA1111H",
                RefAccountHolderName = "Himanshu"
            ,
                RefAccountHolderAddress = "xyz",
                RefAccountNo = 1111333399990000
            };
        }

        [Fact]
        public void AddUser_ValidInput_ReturnsUserAdded()
        {
            mock.Setup(p => p.Add(newuser)).Returns(Task.FromResult("User Added"));
            var result = userService.AddUser(newuser).Result;
            Assert.Equal("User Added", result);

        }

        

        [Fact]
        public void AuthenticateMember_ValidData_ReturnsUserObject()
        {
            mock.Setup(p => p.CheckCredentials("Yuvi123", "Yuvi@123")).Returns(Task.FromResult(newuser));
            var result = userService.AuthenticateMember("Yuvi123", "Yuvi@123").Result;
            Assert.Equal(newuser, result);

        }



        [Fact]
        public void UpdateUser_ValidInput_ReturnsUserUpdated()
        {
            mock.Setup(p => p.Update("R-123", newuser)).Returns(Task.FromResult("User Updated"));
            var result = userService.UpdateUser("R-123", newuser).Result;
            Assert.Equal("User Updated", result);
        }



        [Fact]
        public void GetUser_ValidData_ReturnsUserObject()
        {
            mock.Setup(p => p.Get("R-123")).Returns(Task.FromResult(newuser));
            var result = userService.GetUser("R-123").Result;
            Assert.Equal(newuser, result);

        }


    }
}
