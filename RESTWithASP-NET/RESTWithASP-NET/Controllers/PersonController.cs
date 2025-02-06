using Microsoft.AspNetCore.Mvc;
using RESTWithASP_NET.Model;
using RESTWithASP_NET.Services.Implementations;

namespace RESTWithASP_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();
        }


        #region old
        //[HttpGet("sum/{firstNumber}/{secondNumber}")]
        //public IActionResult Sum(string firstNumber, string secondNumber)
        //{
        //    if (isNumeric(firstNumber) && isNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("div/{firstNumber}/{secondNumber}")]
        //public IActionResult Div(string firstNumber, string secondNumber)
        //{
        //    if (isNumeric(firstNumber) && isNumeric(secondNumber))
        //    {
        //        var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        //        return Ok(div.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("mltp/{firstNumber}/{secondNumber}")]
        //public IActionResult Mltp(string firstNumber, string secondNumber)
        //{
        //    if (isNumeric(firstNumber) && isNumeric(secondNumber))
        //    {
        //        var mltp = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        //        return Ok(mltp.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("subtr/{firstNumber}/{secondNumber}")]
        //public IActionResult Subtr(string firstNumber, string secondNumber)
        //{
        //    if (isNumeric(firstNumber) && isNumeric(secondNumber))
        //    {
        //        var subtr = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        //        return Ok(subtr.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //private decimal ConvertToDecimal(string strNumber)
        //{
        //    decimal decimalValue;
        //    if (decimal.TryParse(strNumber, out decimalValue))
        //    {
        //        return decimalValue;
        //    }
        //    return 0;
        //}

        //private bool isNumeric(string strNumber)
        //{
        //    double number;
        //    bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
        //                                     System.Globalization.NumberFormatInfo.InvariantInfo, out number);

        //    return isNumber;
        //}
        #endregion
    }
}
