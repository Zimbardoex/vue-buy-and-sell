using AuctionApi.Models;
using AuctionApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UsersApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<User>> Get() =>
        _userService.Get();

    [HttpGet("{id:length(24)}", Name = "GetUser")]
    public ActionResult<User> Get(string id)
    {
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }


    [HttpPost]
    [Route("login")]
    public ActionResult<LoginResponse> Login(UserLogin userToAuthenticate)
    {
      List<User> users = _userService.Get();
      User user = users.Find(user => user.Email == userToAuthenticate.Email);

      if (user != null){
        string password = userToAuthenticate.Password;
        string hashedPassword = user.Password;
        string saltyString = System.Environment.GetEnvironmentVariable("SALTY_STRING");
        if (BCrypt.Net.BCrypt.Verify(password + saltyString, hashedPassword))
        {
          string token = _userService.generateJwt(user);
          return Ok(new { user, token});
        }
        else
        {
          return StatusCode(401);
        }
      } else {
        return StatusCode(401);
      }
    }

    [HttpPost]
    public ActionResult<User> Create(User user)
    {
      string saltyString = System.Environment.GetEnvironmentVariable("SALTY_STRING");
      string password = user.Password + saltyString;
      string salt = BCrypt.Net.BCrypt.GenerateSalt();
      string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

      user.Password = hashedPassword;
      _userService.Create(user);

      return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, User userIn)
    {
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      _userService.Update(id, userIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      _userService.Remove(user.Id);

      return NoContent();
    }
  }
}