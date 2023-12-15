using MiniProject.Utilites;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    [TestFixture]
    public class BookingAPITest : CoreCodes
    {
        [Test, Order(1)]
        public void GetToken()
        {
            test = extent.CreateTest(" Create token");
            Log.Information("Create token Test Started");


            var createTokenRequest = new RestRequest("auth", Method.Post);
            createTokenRequest.AddHeader("Content-Type", "application/json");
            createTokenRequest.AddJsonBody(new
            {
                username = "admin",
                password = "password123"
            });

            var createTokenResponse = client.Execute(createTokenRequest);


            try
            {
                Assert.That(createTokenResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information("Api Response:" + createTokenResponse.Content);
                Log.Information("Create token test passed");

                test.Pass("Create token test passed  ");
            }

            catch (AssertionException)
            {
                test.Fail("create token test failed ");
            }
        }


        [Test]
        [Order(2)]

        public void GetBooking()
        {
            test = extent.CreateTest("Get Booking ");
            Log.Information("GetBooking Test Started");

            var request = new RestRequest("booking", Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


                var bookingDataList = JsonConvert.DeserializeObject<List<BookingResponse>>(response.Content);

                Log.Information("Api Response:" + response.Content);



                Assert.NotNull(bookingDataList);
                Log.Information("bookingdata returned");


                Log.Information("GetBooking test passed all asserts");

                test.Pass("GetBooking test passed all asserts");
            }

            catch (AssertionException)
            {

                test.Fail("GetBooking test failed ");
            }

        }

        [Test]
        [Order(3)]
        [TestCase(2)]
        public void GetSingleBooking(int userid)
        {
            test = extent.CreateTest("Get Single Booking ");
            Log.Information("GetSingleBooking Test Started");

            var request = new RestRequest("booking/" + userid, Method.Get).AddHeader("accept", "application/json");
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


                var bookingDataList = JsonConvert.DeserializeObject<BookingDetails>(response.Content);

                Log.Information("Api Response:" + response.Content);
                Log.Information("GetSingleBooking test passed all asserts");

                test.Pass("GetSingleBooking test passed all asserts");

            }
            catch (AssertionException)
            {

                test.Fail("GetSingleBooking test failed ");
            }

        }

        [Test]
        [Order(4)]
        [TestCase(12)]
        public void UpdateBooking(int userid)
        {


            var createTokenRequest = new RestRequest("auth", Method.Post);
            createTokenRequest.AddHeader("Content-Type", "application/json");
            createTokenRequest.AddJsonBody(new
            {
                username = "admin",
                password = "password123"
            });

            var createTokenResponse = client.Execute(createTokenRequest);
            var token = JsonConvert.DeserializeObject<BookingDetails>(createTokenResponse.Content);
            test = extent.CreateTest(" Update User");
            Log.Information("Update User Test Started");

            var updateUserRequest = new RestRequest("booking/" + userid, Method.Put);


            updateUserRequest.AddHeader("Content-Type", "application/json");
            updateUserRequest.AddHeader("Accept", "application/json");
            updateUserRequest.AddHeader("Cookie", "token=" + token?.Token);

            updateUserRequest.AddJsonBody(new
            {
                firstname = "James",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });


            var updateUserResponse = client.Execute(updateUserRequest);

            try
            {
                Assert.That(updateUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information("Api Response:" + updateUserResponse.Content);
                var bookingdata = JsonConvert.DeserializeObject<BookingDetails>(updateUserResponse.Content);

                Assert.NotNull(bookingdata);

                Assert.That(bookingdata.FirstName, Is.EqualTo("James"));
                Log.Information("Booking Updated");

                Log.Information("Update test passed");

                test.Pass("Update test passed ");
            }
            catch (AssertionException)
            {
                test.Fail("Update Booking test failed ");
            }

        }


        [Test, Order(5)]
        public void CreateBooking()
        {

            test = extent.CreateTest(" Create ");
            Log.Information("Create Booking Test Started");
            var createBookingRequest = new RestRequest("booking", Method.Post);
            createBookingRequest.AddHeader("Content-Type", "application/json");
            createBookingRequest.AddHeader("Accept", "application/json");

            createBookingRequest.AddJsonBody(new
            {
                firstname = "James",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });

            var createBookingResponse = client.Execute(createBookingRequest);

            try
            {
                Assert.That(createBookingResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information("Api Response:" + createBookingResponse.Content);

                var bookingdata = JsonConvert.DeserializeObject<BookingDetails>(createBookingResponse.Content);

                Assert.NotNull(bookingdata);
                Log.Information("Booking data created");

                Log.Information("Create test passed");

                test.Pass("Create test passed  all asserts");

            }
            catch (AssertionException)
            {
                test.Fail("create booking test failed ");
            }
        }
        [Test]
        [Order(6)]
        [TestCase(18)]
        public void DeleteBooking(int userid)
        {


            var createTokenRequest = new RestRequest("auth", Method.Post);
            createTokenRequest.AddHeader("Content-Type", "application/json");
            createTokenRequest.AddJsonBody(new
            {
                username = "admin",
                password = "password123"
            });

            var createTokenResponse = client.Execute(createTokenRequest);
            var token = JsonConvert.DeserializeObject<BookingDetails>(createTokenResponse.Content);
            test = extent.CreateTest(" Delete Booking");
            Log.Information("Delete Booking Test Started");

            var deleteBookRequest = new RestRequest("booking/" + userid, Method.Delete);
            deleteBookRequest.AddHeader("Content-Type", "application/json");
            deleteBookRequest.AddHeader("Accept", "application/json");
            deleteBookRequest.AddHeader("Cookie", "token=" + token?.Token);

            var deleteBookingResponse = client.Execute(deleteBookRequest);
            try
            {
                Assert.That(deleteBookingResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

                Log.Information("Api Response:" + deleteBookingResponse.Content);
                Log.Information("Delete Booking test passed");

                test.Pass("Delete Booking test passed ");

            }

            catch (AssertionException)
            {
                test.Fail("Delete Booking test failed");

            }

        }
    }
}
