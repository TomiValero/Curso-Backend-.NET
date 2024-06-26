using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService; //'_' indica que es privado
        public PeopleController([FromKeyedServices("peopleService")]/*De esta manera se accedde al servicio por key*/ IPeopleService peopleService)
        {
            _peopleService = peopleService; //Aca se arregla para inyectar la dependencia y no depender de una implemantacion
            //_peopleService = new PeopleService(); // Esto esta mal luego se modifica, se puede usar la clse que implementa la interfaz para crear un objeto de la misma
        }

        [HttpGet("all")] //Ademas de entrar por get se tiene que entrar por "/all" https://localhost:7246/api/People/all
        public List<People>/*Tipo qeu va a devolver*/ GetPeople()
        {
            return Repository.People;
        }

        [HttpGet("{id}")]//IOndica qu een ela url debe pasar el id si quiero mas "{id}"/"{some}" https://localhost:7246/api/People/1
        public ActionResult<People> GetPeople(int id) //se usa ActionReuslt para devolver los resultados de la operacion
        {
            var people =  Repository.People.FirstOrDefault(x => x.Id == id); //decuelve algo o null

            if (people == null)
            {
                return NotFound(); //Retonorna un codigo 404 de no encontrado
            }

            return Ok(people); //retorna ok y el recurso  
        }

        [HttpGet("search/{search}")]
        public List<People> GetPeople(string search)
        {
            return Repository.People.Where(x => x.Name.ToUpper().Contains(search.ToUpper())).ToList();
        }

        [HttpPost]
        public IActionResult Add(People person)//la ventaje de IactionResult es que no recibe un tipo sirve sino se quiere retornar nada en el body
        {
            if (!(_peopleService.Validate(person)))//El servicio evelau la restriccion del nombre
            {
                return BadRequest(); //Devuelve un codigo dentro de los 400 que dice que la informacion mandada es erronea
            }

            Repository.People.Add(person);

            return NoContent();//Decuelve que esta todo bien pero no devuleve info del body
        }

    }


    public class Repository
    {
        public static List<People> People = new List<People>()
        {
            new People()
            {
                Id = 1,
                Name = "Pedro",
                Birthday = new DateTime(1990,12,3)
            },
            new People()
            {
                Id = 2,
                Name = "Hector",
                Birthday = new DateTime(2004,7,3)
            },
            new People()
            {
                Id = 3,
                Name = "Luis",
                Birthday = new DateTime(1998,8,24)
            },
            new People()
            {
                Id = 4,
                Name = "Hugo",
                Birthday = new DateTime(1888,2,21)
            },
        };
        
    }

    public class People
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
