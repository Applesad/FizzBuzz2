using FizzBuzz2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzz2.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public FizzBuzz? FizzBuzz { get; set; }

        public List<FizzBuzz>? Fizzlist = new() { };
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                Fizzlist = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);

            }
            
        }

    }
}
