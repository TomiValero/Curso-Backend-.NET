using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")] //Metodo sincrono
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); //Se usa como coronometro
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos terminada");


            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail terminada");

            Console.WriteLine("Todo ha terminado");
            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]//Metodo Asincrono
        public async Task<IActionResult> GetAsync() //Task representa una tarea asincrona
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); //Se usa como coronometro
            stopwatch.Start();

            //Creo una tarea y le asigno una funcions
            Task<int> task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de mail terminada");
                return 1;
            });

            Task<int> task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a base de datos terminada");
                return 2;
            });

            task1.Start(); //Inicia task1
            task2.Start(); //Inicia task2

            Console.WriteLine("hago otra cosa");



            int result1 = await task1; //Esperea el resultado de task sino no sigue
            int result2 = await task2; //Esperea el resultado de task sino no sigue

            //Sino se pone el await la tarea sigue ejecutandose en segundo plano hasta el final del metodo

            Console.WriteLine("Todo termino");
            stopwatch.Stop();

            return Ok(result1 + " " + result2 + " " + stopwatch.Elapsed);
        }
    }
}
