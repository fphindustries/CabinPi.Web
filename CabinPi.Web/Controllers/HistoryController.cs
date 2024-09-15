using CabinPi.Web.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabinPi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private DataService _dataService;

        public HistoryController(DataService dataService)
        {
            _dataService = dataService;
        }
        // GET: api/<HistoryController>
        [HttpGet]
        public async Task<MeasurementHistory> Get()
        {

            return await _dataService.GetMeasurmentHistory();
        }
      
    }
}
