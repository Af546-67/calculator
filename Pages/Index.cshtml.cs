using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcoreapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnPost()
        {
            if (Request.Method.Equals("POST", System.StringComparison.OrdinalIgnoreCase))
            {
                string operation = Request.Form["operation"];
                bool isNumber1Valid = int.TryParse(Request.Form["number1"], out int number1);
                bool isNumber2Valid = int.TryParse(Request.Form["number2"], out int number2);

                double result = 0;
                bool hasResult = false;

                if (operation == "ADD")
                {
                    if (isNumber1Valid && isNumber2Valid)
                    {
                        result = number1 + number2;
                        hasResult = true;
                    }
                }
                else if (operation == "MUL")
                {
                    if (isNumber1Valid && isNumber2Valid)
                    {
                        result = number1 * number2;
                        hasResult = true;
                    }
                }
                else if (operation == "SUB")
                {
                    if (isNumber1Valid && isNumber2Valid)
                    {
                        result = number1 - number2;
                        hasResult = true;
                    }
                }
                else if (operation == "DIV")
                {
                    if (isNumber1Valid && isNumber2Valid)
                    {
                        if (number2 != 0)
                        {
                            result = (double)number1 / number2;
                            hasResult = true;
                        }
                    }
                }
                else if (operation == "SQR")
                {
                    if (isNumber1Valid && isNumber2Valid)
                    {
                        result = (number1 * number1) + (number2 * number2);
                        hasResult = true;
                    }
                    else if (isNumber1Valid)
                    {
                        result = number1 * number1;
                        hasResult = true;
                    }
                    else if (isNumber2Valid)
                    {
                        result = number2 * number2;
                        hasResult = true;
                    }
                }
                else if (operation == "POW")
                {
                    if (isNumber1Valid && isNumber2Valid)
                    {
                        result = Math.Pow(number1, 3) + Math.Pow(number2, 3);
                        hasResult = true;
                    }
                    else if (isNumber1Valid)
                    {
                        result = Math.Pow(number1, 3);
                        hasResult = true;
                    }
                    else if (isNumber2Valid)
                    {
                        result = Math.Pow(number2, 3);
                        hasResult = true;
                    }
                }

                if (hasResult)
                {
                    ViewData["result"] = result.ToString();
                }
                else
                {
                    ViewData["result"] = "Invalid input or operation.";
                }
            }
        }
    }
}
