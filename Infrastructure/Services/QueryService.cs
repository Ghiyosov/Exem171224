using System.Net.Mime;
using Dapper;
using Domein.Models;
using Infrastructure.DataContex;
using Infrastructure.Resposes;

namespace Infrastructure.Services;

public class QueryService(IContext _context)
{
    //Получение средней зарплаты по всем вакансиям.
    public async Task<Respons<List<string>>> GetAvarageSalary()
    {
        var sql = @"select Title||' Salary : '||AVG(Salary)
                    from Jobs
                    group by Title
                    order by AVG(Salary)";
        var res = await _context.GetConnection().QueryAsync<string>(sql);
        return new Respons<List<string>>(res.ToList());
    }

    //Получение заявок с определенным статусом (Pending, Accepted, Rejected).
    public async Task<Respons<List<Application>>> GetApplicationsByStatus(string status)
    {
        var sql = @"select * from Applications
                    where Status = @status";
        var res = await _context.GetConnection().QueryAsync<Application>(sql, new { status = status });
        return new Respons<List<Application>>(res.ToList());
    }

    
    //Получение количества заявок, отправленных конкретным пользователем.
    public async Task<Respons<string>> GetJobsByStatus(int userId)
    {
        var sql = @"select u.FullName||' applications count : '||count(*)
                    from Users as u
                    join Applications as a on u.UserId=a.ApplicantId
                    where u.UserId = @userId
                    group by u.FullName";
        var res = await _context.GetConnection().QuerySingleOrDefaultAsync<string>(sql, new { userId = userId });
        return new Respons<string>(res);
    }
    
    //Получение 10 последних опубликованных вакансий.
    public async Task<Respons<List<Job>>> Get10LastJobs()
    {
        var sql = @"select * from Jobs
                    order by CreatedAt desc
                    limit 10";
        var res = await _context.GetConnection().QueryAsync<Job>(sql);
        return new Respons<List<Job>>(res.ToList());
    }
    
    //Получение вакансии с самой высокой зарплатой.
    public async Task<Respons<Job>> GetMaxSalaryJob()
    {
        var sql = @"select * from Jobs
                    order by Salary desc
                    limit 1";
        var res = await _context.GetConnection().QuerySingleOrDefaultAsync<Job>(sql);
        return new Respons<Job>(res);
    }
    
    //Получение вакансии с самой низкой зарплатой.
    public async Task<Respons<Job>> GetMinSalaryJob()
    {
        var sql = @"select * from Jobs
                    order by Salary 
                    limit 1";
        var res = await _context.GetConnection().QuerySingleOrDefaultAsync<Job>(sql);
        return new Respons<Job>(res);
    }
    
    //Получение 5 последних заявок на конкретную вакансию.
    public async Task<Respons<List<Application>>> Get5LastApplication(int jobId)
    {
        var sql = @"select * from Applications
                    where JobId = @jobId
                    order by CreatedAt desc
                    limit 5";
        var res = await _context.GetConnection().QueryAsync<Application>(sql, new { jobId = jobId });
        return new Respons<List<Application>>(res.ToList());
    }
    
    //Получение количества вакансий в конкретном городе.
    public async Task<Respons<string>> GetJobsByCity(string city)
    {
        var sql = @"select City||' count job : '||count(*)
                    from Jobs
                    where City = @city
                    group by City";
        var res = await _context.GetConnection().QuerySingleOrDefaultAsync<string>(sql, new { city });
        return new Respons<string>(res);
    }
}