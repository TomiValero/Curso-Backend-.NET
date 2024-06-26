using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRepository;

        private IMapper _mapper;

        public List<string> Errrors { get; }

        public BeerService(
            IRepository<Beer> beerRepository,
            IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errrors = new List<string>();
        }


        public async Task<IEnumerable<BeerDto>> Get()
        {
          var beers = await _beerRepository.Get();

            return beers.Select(b => _mapper.Map<BeerDto>(b));
        }

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id); 
            
            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);

                return beerDto;//Devuelve beerDto en el body(json)
            }
          
            return null;
            
        }

        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            var beer = _mapper.Map<Beer>(beerInsertDto); //apartrir de beerInsertDto quiero un beer

            await _beerRepository.Add(beer);//agrega una beer(Metodo que tiene por se un DbSet en StoreContext)
            await _beerRepository.Save(); //Sin esta linea no se guardan los cambios en la db

           var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beerRepository.GetById(id);  //Busca una beer por id en storecontext(bd)

            if (beer != null)
            {
                beer = _mapper.Map<BeerUpdateDto, Beer>(beerUpdateDto, beer); //(beerUpdateDto(objeto origen), beer(objeto destino))

                _beerRepository.Update(beer);
                await _beerRepository.Save();

                var beerDto = _mapper.Map<BeerDto>(beer);

                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id); //Busca una beer por id en storecontext(bd)

            if (beer != null)
            {

                var beerDto = _mapper.Map<BeerDto>(beer);

                _beerRepository.Delete(beer);
                await _beerRepository.Save();

                return beerDto;
            }

            return null;
        }

        public bool Validate(BeerInsertDto beerInsertDto)
        {
            if(_beerRepository.Search(b => b.Name == beerInsertDto.Name).Count() > 0)
            {
                Errrors.Add("No puedo existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }

        public bool Validate(BeerUpdateDto beerUpdateDto)
        {
            if (_beerRepository.Search(b => b.Name == beerUpdateDto.Name && beerUpdateDto.Id != b.BeerId).Count() > 0)
            {
                Errrors.Add("No puedo existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }
    }
}
