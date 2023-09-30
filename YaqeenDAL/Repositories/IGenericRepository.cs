using YaqeenDAL.Model;

namespace YaqeenDAL.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        public Task<T> RetrieveAsync(int id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> CreateNonCommitAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> UpdateNonCommitAsync();
        public Task<bool> DeleteAsync(int id);
        public Task<bool> DeleteNonCommitAsync(int id);
        public Task<int> CommitAsync();
    }
}