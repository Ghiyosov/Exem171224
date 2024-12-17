using Domein.Models;
using Infrastructure.Resposes;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class JobController(ICRUD<Job> _crud):ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<Respons<List<Job>>> GetAll()
    {
        return await _crud.GetAll();
    }

    [HttpGet("GetById")]
    public async Task<Respons<Job>> GetById(int id)
    {
        return await _crud.GetById(id);
    }

    [HttpPost("Add")]
    public async Task<Respons<bool>> Add(Job job)
    {
        return await _crud.Create(job);
    }

    [HttpPost("Update")]
    public async Task<Respons<bool>> Update(Job job)
    {
        return await _crud.Update(job);
    }

    [HttpPost("Delete")]
    public async Task<Respons<bool>> Delete(int id)
    {
        return await _crud.Delete(id);
    }
}