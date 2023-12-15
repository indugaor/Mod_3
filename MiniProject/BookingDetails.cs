using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class BookingDetails
    {
        [JsonProperty("firstname")]
        public string? FirstName { get; set; }


        [JsonProperty("lastname")]
        public string? LastName { get; set; }


        [JsonProperty("totalprice")]
        public int TotalPrice { get; set; }

        [JsonProperty("depositpaid")]
        public bool DepositPaid { get; set; }


        [JsonProperty("bookingdates")]
        public BookingDatesDetails? BookingDates { get; set; }



        [JsonProperty("additionalneeds")]
        public string? AdditionalNeeds { get; set; }



        [JsonProperty("token")]
        public string? Token { get; set; }

    }

    public class BookingResponse
    {

        [JsonProperty("bookingid")]
        public int BookingId { get; set; }


        [JsonProperty("booking")]
        public BookingDetails? Booking { get; set; }
    }

    public class BookingDatesDetails
    {
        [JsonProperty("checkin")]
        public string? CheckIn { get; set; }

        [JsonProperty("checkout")]
        public string? CheckOut { get; set; }

    }


}
