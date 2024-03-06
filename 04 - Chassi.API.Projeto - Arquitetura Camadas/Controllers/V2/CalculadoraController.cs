using Microsoft.AspNetCore.Mvc;

namespace Chassi.API.Projeto.Controllers.V2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("[controller]/api/v{version:apiVersion}/")]
    public class CalculadoraController : ControllerBase
    {

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{numero1}/{numero2}")]
        public IActionResult Sum(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                decimal soma = ConvertDecimal(numero1) + ConvertDecimal(numero2);
                return Ok(soma.ToString());
            }
            return BadRequest("Número Inválido!");
        }
        [HttpGet("subtraction/{numero1}/{numero2}")]
        public IActionResult Subtraction(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                decimal subtracao = ConvertDecimal(numero1) - ConvertDecimal(numero2);
                return Ok(subtracao.ToString());
            }
            return BadRequest("Número Inválido!");
        }
        [HttpGet("multiplication/{numero1}/{numero2}")]
        public IActionResult Multiplication(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                decimal multiplicacao = ConvertDecimal(numero1) * ConvertDecimal(numero2);
                return Ok(multiplicacao.ToString());
            }
            return BadRequest("Número Inválido!");
        }
        [HttpGet("division/{numero1}/{numero2}")]
        public IActionResult Division(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                decimal division = ConvertDecimal(numero1) / ConvertDecimal(numero2);
                return Ok(division.ToString());
            }
            return BadRequest("Número Inválido!");
        }
        [HttpGet("mean/{numero1}/{numero2}")]
        public IActionResult Mean(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                decimal media = (ConvertDecimal(numero1) + ConvertDecimal(numero2)) / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Número Inválido!");
        }
        [HttpGet("square-root/{numero1}")]
        public IActionResult SquareRoot(string numero1)
        {
            if (IsNumeric(numero1))
            {
                var squareRoot = Math.Sqrt((double)ConvertDecimal(numero1));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Número Inválido!");
        }
        private bool IsNumeric(string strNumero)
        {
            double number;
            bool isNumber = double.TryParse(strNumero
                , System.Globalization.NumberStyles.Any
                , System.Globalization.NumberFormatInfo.InvariantInfo
                , out number);
            return isNumber;

        }
        private decimal ConvertDecimal(string strNumero)
        {
            decimal decimalNumber;
            if (decimal.TryParse(strNumero, out decimalNumber))
            {
                return decimalNumber;
            }
            return 0;

        }


    }
}
