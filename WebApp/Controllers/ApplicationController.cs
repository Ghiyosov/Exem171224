using Domein.Models;
using Infrastructure.Resposes;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicationController(ICRUD<Application> _crud):ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<Respons<List<Application>>> GetAll()
    {
        return await _crud.GetAll();
    }

    [HttpGet("GetById")]
    public async Task<Respons<Application>> GetById(int id)
    {
        return await _crud.GetById(id);
    }

    [HttpPost("Create")]
    public async Task<Respons<bool>> Create([FromBody] Application application)
    {
        return await _crud.Create(application);
    }

    [HttpPut("Update")]
    public async Task<Respons<bool>> Update([FromBody] Application application)
    {
        return await _crud.Update(application);
    }

    [HttpDelete("Delete")]
    public async Task<Respons<bool>> Delete(int id)
    {
        return await _crud.Delete(id);
    }
}