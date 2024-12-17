using System.Net;
using System.Net.Mime;
using Dapper;
using Domein.Models;
using Infrastructure.DataContex;
using Infrastructure.Resposes;

namespace Infrastructure.Services;

public class ApplicationService(IContext _context):ICRUD<Application>
{
    public async Task<Respons<List<Application>>> GetAll()
    {
        var sql = @"select * from Applications";
        var res = await _context.GetConnection().QueryAsync<Application>(sql);
        return new Respons<List<Application>>(res.ToList());
    }

    public async Task<Respons<Application>> GetById(int id)
    {
        var sql = @"select * from Applications where ApplicationId = @id";
        var res = await _context.GetConnection().QuerySingleOrDefaultAsync<Application>(sql, new { id });
        return new Respons<Application>(res);
    }

    public async Task<Respons<bool>> Create(Application entity)
    {
        var sql = @"insert into Applications (JobId, ApplicantId, Resume, Status, CreatedAt, UpdatedAt)
                    values (@JobId, @ApplicantId, @Resume , @Status, @CreatedAt, @UpdatedAt);";
        var res = await _context.GetConnection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.Created, "Application Created");
    }

    public async Task<Respons<bool>> Update(Application entity)
    {
        var sql = @"update Applications set JobId=@JobId, ApplicantId=@ApplicantId, Resume=@Resume, Status=@Status, CreatedAt=@CreatedAt, UpdatedAt=@UpdatedAt where ApplicationId = @ApplicationId";
        var res = await _context.GetConnection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.OK, "Application updated");
    }

    public async Task<Respons<bool>> Delete(int id)
    {
        var sql = @"delete from Applications where ApplicationId = @id";
        var res = await _context.GetConnection().ExecuteAsync(sql, new { id });
        return res == 0
            ? new Respons<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Respons<bool>(HttpStatusCode.OK, "Application deleted");
    }
}