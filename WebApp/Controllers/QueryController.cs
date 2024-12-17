using Domein.Models;
using Infrastructure.Resposes;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class QueryController(QueryService _query):ControllerBase
{
    [HttpGet("average-salary")]
    public async Task<Respons<List<string>>> GetAvarageSalary()
    {
        return await _query.GetAvarageSalary();
    }

    [HttpGet("status/{status}")]
    public async Task<Respons<List<Application>>> GetApplicationsByStatus(string status)
    {
        return await _query.GetApplicationsByStatus(status);
    }

    [HttpGet("{userId}/count")]
    public async Task<Respons<string>> GetJobsByStatus(int userId)
    {
        return await _query.GetJobsByStatus(userId);
    }

    [HttpGet("/recent")]
    public async Task<Respons<List<Job>>> Get10LastJobs()
    {
        return await _query.Get10LastJobs();
    }

    [HttpGet("highest-salary")]
    public async Task<Respons<Job>> GetMaxSalaryJob()
    {
        return await _query.GetMaxSalaryJob();
    }

    [HttpGet("lowest-salary")]
    public async Task<Respons<Job>> GetMinSalaryJob()
    {
        return await _query.GetMinSalaryJob();
    }

    [HttpGet("{jobId}/latest ")]
    public async Task<Respons<List<Application>>> Get5LastApplication(int jobId)
    {
        return await _query.Get5LastApplication(jobId);
    }

    [HttpGet("location/{city}")]
    public async Task<Respons<string>> GetJobsByCity(string city)
    {
        return await _query.GetJobsByCity(city);
    }
}