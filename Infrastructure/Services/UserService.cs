using System.Net;
using Dapper;
using Domein.Models;
using Infrastructure.DataContex;
using Infrastructure.Resposes;

namespace Infrastructure.Services;

public class UserService(IContext _context):ICRUD<User>
{
    public async Task<Respons<List<User>>> GetAll()
    {
        var sql = @"select * from Users";
        var res = await _context.GetConnection().QueryAsync<User>(sql);
        return new Respons<List<User>>(res.ToList());
    }

    public async Task<Respons<User>> GetById(int id)
    {
        var sql = @"select * from Users where UserId = @id";
        var res = await _context.GetConnection().QuerySingleOrDefaultAsync<User>(sql, new { id });
        return new Respons<User>(res);
    }

    public async Task<Respons<bool>> Create(User entity)
    {
        var sql = @"insert into Users (FullName, Email, Phone, Role, CreatedAt) 
                    values (@FullName, @Email, @Phone, @Role, @CreatedAt);";
        var res = await _context.GetConnection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.Created, "User Created");
    }

    public async Task<Respons<bool>> Update(User entity)
    {
        var sql = @"update Users set FullName=@FullName, Email=@Email, Phone=@Phone, Role=@Role, CreatedAt=@CreatedAt where UserId = @UserId";
        var res = await _context.GetConnection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.OK, "User updated"); 
    }

    public async Task<Respons<bool>> Delete(int id)
    {
        var sql = @"delete from Users where UserId = @id";
        var res = await _context.GetConnection().ExecuteAsync(sql, new { id });
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.OK, "User deleted"); 
    }
}