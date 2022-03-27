using System.ComponentModel.DataAnnotations;

namespace FizzBuzz2.Models
{
    public class FizzBuzz
    {
        
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required, Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakredu {1} i {2}.")]
        public int? Number { get; set; }
        public string? Powiadomienie { get; set; }
        public string Check()
        {
            string s = "";
            if (Number % 3 == 0) s += "Fizz";
            if (Number % 5 == 0) s += "Buzz";
            if (s == "") s = "Liczba: " + Number.ToString() + " nie spełnia kryteriów FizzBuzz";
            return s;
        }
    }
}
