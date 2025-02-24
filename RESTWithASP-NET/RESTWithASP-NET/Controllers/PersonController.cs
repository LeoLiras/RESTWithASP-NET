using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RESTWithASP_NET.Business;
using RESTWithASP_NET.Data.VO;
using RESTWithASP_NET.Hypermedia.Filters;

namespace RESTWithASP_NET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personService;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
