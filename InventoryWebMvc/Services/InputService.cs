using InventoryWebMvc.Data;
using InventoryWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using InventoryWebMvc.Services.Exceptions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventoryWebMvc.Services
{
    public class InputService
    {
        private readonly InventoryWebMvcContext _context;

        public InputService(InventoryWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Input>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Input select obj;
            if(minDate.HasValue)
            {
                result = result.Where(x => x.Moment >= minDate.Value);
            }

            if(maxDate.HasValue)
            {
                result = result.Where(x => x.Moment <= maxDate.Value);
            }

            return await result.Include(x => x.Product).OrderByDescending(x => x.Moment).ToListAsync();

        }

        public async Task<List<Input>> FindAllAsync()
        {
            return await _context.Input.OrderBy(x => x.Moment).Include(obj => obj.Product).ToListAsync();
        }

        public async Task InsertAsync(Input obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Input> FindByIdAsync(int id)
        {
            return await _context.Input.Include(obj => obj.Product).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Input.FindAsync(id);
            _context.Input.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Input obj)
        {
            bool hasAny = await _context.Input.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            } catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
