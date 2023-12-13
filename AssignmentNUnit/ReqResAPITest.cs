using AssignmentNUnit.Utilities;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNUnit
{
    [TestFixture]
    public class ReqResAPITest : CoreCodes
    {
        [Test]
        [Order(1)]
        [TestCase(2)]
        public void GetSingleUser(int userId)
        {
            test = extent.CreateTest("Get Single User");
            Log.Information("GetSingleUser Test Started");

            var request = new RestRequest("posts/" + userId, Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

                var userdata = JsonConvert.DeserializeObject<UserData>(response.Content);
                Log.Information("Api Response:" + response.Content);


                Assert.NotNull(userdata);
                Log.Information("User returned");
                Assert.That(userdata.Id, Is.EqualTo(userId));
                Log.Information("user id matches with fetch");
                Assert.IsNotEmpty(userdata.Body);
                Log.Information("user body matches with fetch");

                Log.Information("GetSingleUser test passed all asserts");

                test.Pass("GetSingleUser test passed all asserts");
            }

            catch (AssertionException)
            {

                test.Fail("GetSingleUser test failed ");
            }

        }

        [Test, Order(2)]

        public void CreateUser()
        {

            test = extent.CreateTest(" Create User");
            Log.Information("Create User Test Started");
            var createUserRequest = new RestRequest("posts", Method.Post);
            createUserRequest.AddHeader("Content-Type", "application/json");
            createUserRequest.AddJsonBody(new
            {
                userId = "43",
                id = "43",
                title = "Home",
                body = "architecto"
            });

            var createUserResponse = client.Execute(createUserRequest);

            try
            {
                Assert.That(createUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
                Log.Information("Api Response:" + createUserResponse.Content);

                var userdata = JsonConvert.DeserializeObject<UserData>(createUserResponse.Content);

                Assert.NotNull(userdata);
                Log.Information("User data created");

                Log.Information("Create test passed");

                test.Pass("Create test passed  all asserts");

            }
            catch (AssertionException)
            {
                test.Fail("create user test failed ");
            }

        }

        [Test, Order(3)]
        [TestCase(2)]

        public void UpdateUser(int userId)
        {
            test = extent.CreateTest(" Update User");
            Log.Information("Update User Test Started");

            var updateUserRequest = new RestRequest("posts/" + userId, Method.Put);


            updateUserRequest.AddHeader("Content-Type", "application/json");
            updateUserRequest.AddJsonBody(new
            {
                userId = "143",
                id = "43",
                title = "Homes",
                body = "architecto"
            });


            var updateUserResponse = client.Execute(updateUserRequest);

            try
            {

                Assert.That(updateUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information("Api Response:" + updateUserResponse.Content);
                var userdata = JsonConvert.DeserializeObject<UserData>(updateUserResponse.Content);

                Assert.NotNull(userdata);

                Log.Information("User Updated");

                Log.Information("Update test passed");

                test.Pass("Update test passed ");

            }
            catch (AssertionException)
            {
                test.Fail("Update user test failed ");
            }

        }

        [Test, Order(4)]
        [TestCase(2)]

        public void DeleteUser(int userId)


        {


            test = extent.CreateTest(" Delete User");
            Log.Information("Delete User Test Started");
            var deleteUserRequest = new RestRequest("posts/" + userId, Method.Delete);

            var deleteUserResponse = client.Execute(deleteUserRequest);
            try
            {
                Assert.That(deleteUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

                Log.Information("Api Response:" + deleteUserResponse.Content);
                Log.Information("Delete user test passed");

                test.Pass("Delete user test passed ");

            }

            catch (AssertionException)
            {
                test.Fail("Delete user test failed");

            }
        }


        [Test, Order(5)]
        [TestCase(245)]
        public void GetnonExsistingUser(int userid)
        {

            test = extent.CreateTest(" Get non exsisting User");
            Log.Information("Get non exsisting User Test Started");
            var request = new RestRequest("posts/" + userid, Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
                Log.Information("Api Response:" + response.Content);

                Log.Information("Get non Exsisting user test passed");

                test.Pass("Get non Exsisting user passed ");
            }
            catch (AssertionException)
            {
                test.Fail("Get non Exsisting test failed ");
            }

        }

    }
}
