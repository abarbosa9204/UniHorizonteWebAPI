using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Emails.Validator;
using Application.Services.Passwords.Encrypter;
using Application.Services.Passwords.Validator;
using Application.Services.PersonIDs;
using Application.Services.SignIn;
using Application.Services.SignUp;
using Application.Services.SignUp.Validator;
using Application.Services.Tokens.Generator;
using Application.Services.Tokens.TokenGenerator;
using Application.Services.Tokens.Validator;
using Application.Wrappers;

using Domain.Models;
using Domain.Responses.GenericResponses;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtension {
    public static void AddApplicationServices(this IServiceCollection services) {
      services.AddScoped<IRequestHandler<SignUpRequest, GenericResponse>, SignUpRequestHandler>();
      services.AddScoped<IRequestHandler<SignInRequest, GenericResponse>, SignInRequestHandler>();
      services.AddScoped<IPasswordsEncrypter, PasswordsEncrypter>();
      services.AddScoped<IEmailsValidators, EmailsValidator>();
      services.AddScoped<IPersonIdsValidator, PersonIdsValidator>();
      services.AddScoped<IPasswordsValidator, PasswordsValidator>();
      services.AddScoped<ISignUpValidator, SignUpValidator>();
      services.AddScoped<ITokenGenerator, TokenGenerator>();
      services.AddScoped<ITokenValidator, TokenValidator>();
    }
  }
}
