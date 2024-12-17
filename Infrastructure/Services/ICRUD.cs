using Infrastructure.Resposes;

namespace Infrastructure.Services;

public interface ICRUD<T>
{
    public Task<Respons<List<T>>> GetAll();
    public Task<Respons<T>> GetById(int id);
    public Task<Respons<bool>> Create(T entity);
    public Task<Respons<bool>> Update(T entity);
    public Task<Respons<bool>> Delete(int id);
}