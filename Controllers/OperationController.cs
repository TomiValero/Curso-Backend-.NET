using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]//url del controlador: http//localhotst.../api/operatio  (seria el nombre sin la plabara controller) a menos que lo cambie en esta linea
    [ApiController]
    public class OperationController : ControllerBase
    {

        [HttpGet]//Especificar por cual verbo http vamos a entrar (Metodo)
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string Host/*Trae el Host del header*/, [FromHeader(Name = "Content-Length")] /*Pone el nombre ahi xq tine un guion*/ string ContentLenght/*este nombre no importa*/)
        {
            Console.WriteLine(Host);//Se muestra el valor en la consola
            Console.WriteLine(ContentLenght);
            return numbers.A - numbers.B; //Solo para el ejemplo en realidad posto es para hacer cambios
        }

        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a * b; 
        }

        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a / b;
        }
    }

    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }



    }
}
