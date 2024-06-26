using Backend.DTOs;
using System.Text.Json;

namespace Backend.Services
{
    public class PostsService : IPostsService
    {
        private HttpClient _httpClient;//Sirve para conectarse a funciones http(get,post,put,delete) como un cliente

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient; //Asigna el hhtpclient de la inyeccion de dependencia
        }

        //Async solo va en la implementacion no en la interfaz(solo en metodos que tengan body)
        public async Task<IEnumerable<PostDto>> Get()
        {
            
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress/*Url de la inyeccion*/); //Guarda la respuesta luego de enviar el get
            var body = await result.Content.ReadAsStringAsync(); //Lee el boy de la respuesta

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, //Hace que no tenga en cuenta las mayusculas en la
                                                    //clase PostDto para asi encontrar el equivalente en la deserializacion
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options); //Encuentra las propiedades equivalentes y las guarda en un Inumerable de PostDto

            return post;
        }

    }
}
