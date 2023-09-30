using Microsoft.Extensions.Logging;
using YaqeenDAL.Model;

namespace YaqeenDAL.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly YaqeenDbContext _context;
        private readonly ILogger<T> _logger;
        public GenericRepository(YaqeenDbContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<int> CommitAsync()
        {
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error_{nameof(CreateAsync)}");
                return Task.FromResult(-1);
            }
        }

        public async Task<bool> CreateAsync(T entity)
        {
            if (await CreateNonCommitAsync(entity))
            {
                var commitResult = await CommitAsync();
                return commitResult > 0;
            }
            return false;
        }

        public async Task<bool> CreateNonCommitAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error_{nameof(CreateAsync)}");
                return false;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteNonCommitAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> RetrieveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNonCommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}