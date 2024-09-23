using CountryService2024.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CountryService2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository repo;

        public CountryController(ICountryRepository repo)
        {
            this.repo = repo;
        }
        //[HttpGet]
        //[HttpHead]
        //public IEnumerable<Country> Get()
        //{
        //    //logger.LogInformation(1001, "GetAll called");
        //    //logger.LogTrace("Trace log");
        //    //logger.LogDebug("Debug log");
        //    //logger.LogInformation("Informationlog");
        //    //logger.LogError("Error log");
        //    //logger.LogCritical("Critical log");
        //    return repo.GetAll();
        //}
        //// GET: api/Country/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        return Ok(repo.GetCountry(id));
        //    }
        //    catch(CountryException ex) 
        //    {                
        //        return NotFound(); 
        //    }
        //}
        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public ActionResult<Country> Get(int id)
        {
            try
            {
                return repo.GetCountry(id);
            }
            catch (CountryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        // GET: api/Country
        //[HttpGet]
        //[HttpHead]
        //public IEnumerable<Country> Getall([FromQuery] string continent)
        //{
        //    if (!string.IsNullOrWhiteSpace(continent))
        //    {             
        //        return repo.GetAll(continent);               
        //    }
        //    else
        //        return repo.GetAll();
        //}
        //// GET: api/Country
        [HttpGet]
        [HttpHead]
        public IEnumerable<Country> Getall([FromQuery] string continent, [FromQuery] string capital)
        {
            if (!string.IsNullOrWhiteSpace(continent))
            {
                if (!string.IsNullOrWhiteSpace(capital.Trim()))
                    return repo.GetAll(continent, capital);
                else
                    return repo.GetAll(continent);
            }
            else
                return repo.GetAll();
        }
    }
}
