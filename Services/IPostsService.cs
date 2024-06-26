using Backend.DTOs;

namespace Backend.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get(); //Enumerable sirve para listas y distintas colleciones sin tener tantas cosas como list, es mas rapido y es solo de lectura
    }
}
