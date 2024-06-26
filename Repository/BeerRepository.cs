using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _context;

        public BeerRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> Get()
        {
            return await _context.Beers.ToListAsync();
        }

        public async Task<Beer> GetById(int id)
        {
            return await _context.Beers.FindAsync(id);
        }

        public async Task Add(Beer beer)
        {
             await _context.Beers.AddAsync(beer);
        }

        public void Update(Beer beer)
        {
            _context.Beers.Attach(beer);
            _context.Beers.Entry(beer).State = EntityState.Modified;
        }

        public void Delete(Beer beer)
        {
            _context.Beers.Remove(beer);
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }

        public IEnumerable<Beer> Search(Func<Beer, bool> filter) //LLega una funcion que evalua true or false, ejemplo: (x => x.nombre == "Ipa")
        {
            return _context.Beers.Where(filter).ToList();
        }
       
    }
}
