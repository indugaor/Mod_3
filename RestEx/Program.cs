using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestEx;
using RestSharp;
/*
string baseurl = "https://reqres.in/api";
var client =new RestClient(baseurl);

//GetMethod
var getUserRequest =new RestRequest("users/2",Method.Get);
var getUserResponse = client.Execute(getUserRequest);
Console.WriteLine("Get Response: \n " + getUserResponse.Content);


//postmethod
var createUserRequest = new RestRequest("users", Method.Post);
createUserRequest.AddParameter("name", "John Doe");
createUserRequest.AddParameter("job", "Engineer");

var createUserResponse = client.Execute(createUserRequest);
Console.WriteLine("Post Response: \n " + createUserResponse.Content);

//put method
var updateUserRequest = new RestRequest("users/2", Method.Put);
updateUserRequest.AddParameter("name", "Updated John");
updateUserRequest.AddParameter("job", "Software engineer");


var updateUserResponse = client.Execute(updateUserRequest);
Console.WriteLine("Put Response: \n " + updateUserResponse.Content);

//delete method

var deleteUserRequest = new RestRequest("users/2", Method.Delete);

var deleteUserResponse = client.Execute(deleteUserRequest);
Console.WriteLine("Delete Response: \n " + deleteUserResponse.Content);*/



string baseurl = "https://reqres.in/api";
var client = new RestClient(baseurl);

//GetMethod
/*GetAlluser(client);
GetSingleUser(client);
CreateUser(client);
UpdateUser(client);
DeleteUser(client);

static void GetAlluser(RestClient client)
{

    var getUserRequest = new RestRequest("users", Method.Get);
    getUserRequest.AddQueryParameter("page", "1");
    var getUserResponse = client.Execute(getUserRequest);
    Console.WriteLine("Get all Response: \n " + getUserResponse.Content);
}
static void GetSingleUser(RestClient client)
{
    var getUserRequest = new RestRequest("users/2", Method.Get);
    var getUserResponse = client.Execute(getUserRequest);

    if (getUserResponse.StatusCode == System.Net.HttpStatusCode.OK)
    {

        JObject? userJson = JObject.Parse(getUserResponse?.Content);

        string? userName = userJson?["data"]?["first_name"]?.ToString();
        string? userLast_Name = userJson?["data"]?["last_name"]?.ToString();

        Console.WriteLine($"user name : {userName} {userLast_Name}");
    }
    else
    {
        Console.WriteLine($"Error: {getUserResponse.ErrorMessage}");
    }

}

static void CreateUser(RestClient client)
{

    //postmethod
    var createUserRequest = new RestRequest("users", Method.Post);
    createUserRequest.AddHeader("Content-Type", "application/json");
    createUserRequest.AddJsonBody(new { name = "john doe", job = "Software engineer" });

    var createUserResponse = client.Execute(createUserRequest);
    Console.WriteLine("Post Response: \n " + createUserResponse.Content);
}


static void UpdateUser(RestClient client)
{
    //put method
    var updateUserRequest = new RestRequest("users/2", Method.Put);


    updateUserRequest.AddHeader("Content-Type", "application/json");
    updateUserRequest.AddJsonBody(new { name = "John doe", job = "Software Developer" });


    var updateUserResponse = client.Execute(updateUserRequest);
    Console.WriteLine("Put Response: \n " + updateUserResponse.Content);
}
//delete method

static void DeleteUser(RestClient client)
{
    var deleteUserRequest = new RestRequest("users/2", Method.Delete);

    var deleteUserResponse = client.Execute(deleteUserRequest);
    Console.WriteLine("Delete Response: \n " + deleteUserResponse.Content);
}
*/

//12-12-23  dailyworks
/*static void GetSingleUser(RestClient client)
{
    var getUserRequest = new RestRequest("users/2", Method.Get);
    var getUserResponse = client.Execute(getUserRequest);

    if (getUserResponse.StatusCode == System.Net.HttpStatusCode.OK)
    {


        //deserilaize json response content into c# object
        var response = JsonConvert.DeserializeObject<UserDataResponse>(getUserResponse.Content);


        UserData? user = response?.Data;

        Console.WriteLine($"User Id : {user?.Id} ");
        Console.WriteLine($"User Email : {user?.Email} ");
        Console.WriteLine($"User Name : {user?.FirstName} {user?.LastName}");
        Console.WriteLine($"User Avatar : {user?.Avatar} ");
    }
    else
    {
        Console.WriteLine($"Error: {getUserResponse.ErrorMessage}");
    }

}


GetSingleUser(client);
*/

APIwithEx exceptions = new APIwithEx();
exceptions.GetsingleUser();
