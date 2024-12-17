using Domein.Models;
using Infrastructure.Resposes;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController(ICRUD<User> _crud):ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<Respons<List<User>>> GetAll()
    {
        return await _crud.GetAll();
    }

    [HttpGet("GetById")]
    public async Task<Respons<User>> GetById(int id)
    {
        return await _crud.GetById(id);
    }

    [HttpPost("Create")]
    public async Task<Respons<bool>> Create(User user)
    {
        return await _crud.Create(user);
    }

    [HttpPut("Update")]
    public async Task<Respons<bool>> Update(int id, [FromBody] User update)
    {
        return await _crud.Update(update);
    }

    [HttpDelete("Delete")]
    public async Task<Respons<bool>> Delete(int id)
    {
        return await _crud.Delete(id);
    }
}