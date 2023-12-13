using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestExNUnit
{
    [TestFixture]
    internal class ReqResAPITests
    {
        private RestClient client;
        private string baseurl = "https://reqres.in/api";

        [SetUp]
        public void Setup()
        {
            client = new RestClient(baseurl);


        }

        [Test]
        [Order(1)]
        public void GetSingleUser()
        {
            var request = new RestRequest("users/2", Method.Get);
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var userdata = JsonConvert.DeserializeObject<UserDataResponse>(response.Content);
            UserData? user = userdata?.Data;


            Assert.NotNull(user);
            Assert.That(user.Id, Is.EqualTo(2));
            Assert.IsNotEmpty(user.Email);

            Console.WriteLine(response.Content);


        }

        [Test, Order(2)]

        public void CreateUser()
        {
            var createUserRequest = new RestRequest("users", Method.Post);
            createUserRequest.AddHeader("Content-Type", "application/json");
            createUserRequest.AddJsonBody(new { name = "john doe", job = "Software engineer" });

            var createUserResponse = client.Execute(createUserRequest);
            Assert.That(createUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

            var userdata = JsonConvert.DeserializeObject<UserData>(createUserResponse.Content);

            Assert.NotNull(userdata);




        }

        [Test, Order(3)]

        public void UpdateUser()
        {


            var updateUserRequest = new RestRequest("users/2", Method.Put);


            updateUserRequest.AddHeader("Content-Type", "application/json");
            updateUserRequest.AddJsonBody(new { name = "John doe", job = "Software Developer" });


            var updateUserResponse = client.Execute(updateUserRequest);

            Assert.That(updateUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var userdata = JsonConvert.DeserializeObject<UserData>(updateUserResponse.Content);

            Assert.NotNull(userdata);

        }

        [Test, Order(4)]

        public void DeleteUser()
        {
            var deleteUserRequest = new RestRequest("users/2", Method.Delete);

            var deleteUserResponse = client.Execute(deleteUserRequest);
            Assert.That(deleteUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));
        }


        [Test, Order(5)]
        public void GetnonExsistingUser()
        {
            var request = new RestRequest("users/245", Method.Get);
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));


        }

    }
}
