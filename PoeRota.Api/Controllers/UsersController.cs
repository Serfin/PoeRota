﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoeRota.Infrastructure.CommandHandlers;
using PoeRota.Infrastructure.Commands;
using PoeRota.Infrastructure.Commands.Users;
using PoeRota.Infrastructure.DTO;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        //GET users
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
            => await _userService.GetAllAsync();

        // GET users/email
        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);
        // POST CreateUser
        [HttpPost]
        public async Task Register([FromBody] CreateUser command)
            => await _commandDispatcher.DispatchAsync(command);
    }
}
