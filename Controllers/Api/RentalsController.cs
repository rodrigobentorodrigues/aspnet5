using Course.DTOs;
using System.Web.Http;

namespace Course.Controllers.Api
{
    public class RentalsController : ApiController
    {

        [HttpPost]
        public IHttpActionResult CreateNew(NewRentalDTO rental)
        {
            return Ok();
        }

    }
}
