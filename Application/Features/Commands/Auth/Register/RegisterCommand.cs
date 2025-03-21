﻿using Application.Dtos.Auth.Commands;
using MediatR;

namespace Application.Features.Commands.Auth.Register
{
    public record RegisterCommand : IRequest<RegisterCommandResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
