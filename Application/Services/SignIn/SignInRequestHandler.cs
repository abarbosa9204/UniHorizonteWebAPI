using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Services.Passwords.Validator;
using Application.Services.Tokens.TokenGenerator;
using Application.Wrappers;

using Domain.DTO;
using Domain.Models;
using Domain.Responses;
using Domain.Responses.GenericResponses;

using MediatR;

using Persistence.Entities;
using Persistence.Repositories.Specifications.User;
using Persistence.Repositories.UserRepository;

namespace Application.Services.SignIn {

  public class SignInRequest : GenericRequest<SignInData> { }


  public class SignInRequestHandler : IRequestHandler<SignInRequest, GenericResponse> {

    private readonly IPasswordsValidator passwordsValidator;
    private readonly ITokenGenerator tokenGenerator;
    private readonly IGenericRepository<TblUsuario> repository;

    public SignInRequestHandler(IPasswordsValidator passwordsValidator, ITokenGenerator tokenGenerator, IGenericRepository<TblUsuario> repository) {
      this.passwordsValidator = passwordsValidator;
      this.tokenGenerator = tokenGenerator;
      this.repository = repository;
    }

    public async Task<GenericResponse> Handle(SignInRequest request, CancellationToken cancellationToken) {
      var responseFactory = new GenericResponseFactory();
      if(await passwordsValidator.checkPassword(request.Body)) {
        var user = await repository.FirstOrDefaultAsync(new UserByEmailSpecification(request.Body.Email));
        var credentials = new UserCredential { email = user.Correo, name = user.Nombre, surname = user.Apellido };

        var signInResponse = new SignInResponse {
          name = credentials.name,
          surname = credentials.surname,
          email = credentials.email,
          token = tokenGenerator.GenerateToken(credentials)
        };

        return responseFactory.GetOK(signInResponse);
      } else {
        return responseFactory.GetErrorValidation("El email o la contraeña son incorrectos");
      }
    }
  }
}
