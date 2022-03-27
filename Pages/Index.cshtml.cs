using FizzBuzz2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace FizzBuzz2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string?   Name { get; set; }

        [BindProperty]
        public FizzBuzz? FizzBuzz { get;set; }
        public List<FizzBuzz>? Fizzlist = new() { };
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
            
            
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    Name = "User";
                }
                return Page();
            }
            
            TempData["AlertMessage"] = FizzBuzz.Check();
            FizzBuzz.Powiadomienie = FizzBuzz.Check();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
            if (ModelState.IsValid)
            {
                var Data = HttpContext.Session.GetString("Data");
                if (Data == null)
                {
                    Fizzlist = new List<FizzBuzz>();
                    Fizzlist.Add(FizzBuzz);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Fizzlist));

                }
                else
                {
                    Fizzlist = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);
                    Fizzlist.Add(FizzBuzz);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Fizzlist));

                }
                

            }
            return Page();

        }

    }
}