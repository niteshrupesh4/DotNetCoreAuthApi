using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace DatingApp.API.Helpers
{
    public static class Extentions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

        }

        public static void AddPagination(this HttpResponse response, int currenttPage, 
            int itemperPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currenttPage, itemperPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static int CalculateAge(this DateTime thisDatetime)
        {
            var age = DateTime.Today.Year - thisDatetime.Year;
            if (thisDatetime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}