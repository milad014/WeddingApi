using Microsoft.AspNetCore.Mvc;



namespace MyApiProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // route will be /home


    public class HomeController : Controller
    {
        [HttpGet]
        public int Index(){

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += i;
            }
            return sum; 
        }
    }
}
