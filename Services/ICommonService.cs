using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services
{
    public interface ICommonService<T, TI, TU> //<BeerDto, BeerInsertDto, BeerUpdateDto> su pone para que sirve para otras implementaciones
    {

        public List<string> Errrors { get; }    

        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<T> Add(TI beerInsertDto);

        Task<T> Update(int id, TU beerUpdateDto);

        Task<T> Delete(int id);

        bool Validate(TI dto);
        bool Validate(TU dto);
    }
}
