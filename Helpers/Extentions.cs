using Microsoft.AspNetCore.Http;
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

        public static int CalculateAge(this DateTime thisDatetime)
        {
            var age = DateTime.Today.Year - thisDatetime.Year;
            if (thisDatetime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}