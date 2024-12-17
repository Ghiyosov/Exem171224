using System.Net;
using Dapper;
using Domein.Models;
using Infrastructure.DataContex;
using Infrastructure.Resposes;

namespace Infrastructure.Services;

public class JobService(IContext _context):ICRUD<Job>
{
    public async Task<Respons<List<Job>>> GetAll()
    {
        var sql = @"select * from Jobs";
        var res = await _context.GetConnection().QueryAsync<Job>(sql);
        return new Respons<List<Job>>(res.ToList());
    }

    public async Task<Respons<Job>> GetById(int id)
    {
        var sql = @"select * from Jobs where JobId = @id";
        var res = await _context.GetConnection().QuerySingleOrDefaultAsync<Job>(sql, new { id });
        return new Respons<Job>(res);
    }

    public async Task<Respons<bool>> Create(Job entity)
    {
        var sql = @"insert into Jobs (EmployeeId, Title, Description, Salary, Country, City, Status, CreatedAt, UpdatedAt)
            values (@EmployeeId, @Title, @Description, @Salary, @Country, @City, @Status, @CreatedAt, @UpdatedAt);";
        var res = await _context.GetConnection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.Created, "Jod Created");
    }

    public async Task<Respons<bool>> Update(Job entity)
    {
        var sql = @"update Jobs set EmployeeId=@EmployeeId, Title=@Title, Description=@Description, Salary=@Salary, Country=@Country, City=@City, Status=@Status, CreatedAt=@CreatedAt, UpdatedAt=@UpdatedAt where JobId = @JobId";
        var res = await _context.GetConnection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.OK, "Jod updated");
    }

    public async Task<Respons<bool>> Delete(int id)
    {
        var sql = @"delete from Jobs where JobId = @JobId";
        var res = await _context.GetConnection().ExecuteAsync(sql, new { JobId = id });
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.OK, "Jod deleted");
    }
}