using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Application.Services.Emails;
using Application.Services.Passwords.Encrypter;
using Application.Services.SignUp;
using Application.Services.SignUp.Validator;
using Application.Services.Tokens.TokenGenerator;
using Application.Wrappers;

using BCrypt.Net;

using Domain.Models;
using Domain.Responses;
using Domain.Responses.GenericResponses;

using MediatR;

using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositories.UserRepository;

namespace Application.Services.SignUp {

  public class SignUpRequest : GenericRequest<UserSignUpData> { }

  public class SignUpRequestHandler : IRequestHandler<SignUpRequest, GenericResponse> {
    private readonly IGenericRepository<TblUsuario> _repository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IPasswordsEncrypter _encrypter;
    private readonly ISignUpValidator _validator;

    public SignUpRequestHandler(IGenericRepository<TblUsuario> repository, ITokenGenerator tokenGenerator, IPasswordsEncrypter encrypter, ISignUpValidator validator) {
      _repository = repository;
      _tokenGenerator = tokenGenerator;
      _encrypter = encrypter;
      _validator = validator;
    }

    public async Task<GenericResponse> Handle(SignUpRequest request, CancellationToken cancellationToken) {      
      var responseFactory = new GenericResponseFactory();

      if(await _validator.ValidateEmail(request.Body.email)) {
        return responseFactory.GetErrorValidation("Ya existe un usuario con ese email!");
      } else if(await _validator.ValidatePersonId(request.Body.personId)) {
        return responseFactory.GetErrorValidation("Ya existe un usuario con esa cedula!");
      } else {
        var credentials = new UserCredential { email = request.Body.email, name = request.Body.name, surname = request.Body.surname };

        var userDTO = new TblUsuario {
          RowId = new Guid(),
          Cedula = request.Body.personId,
          Nombre = request.Body.name,
          Apellido = request.Body.surname,
          Password = _encrypter.GetHashedPassword(request.Body.password),
          Correo = request.Body.email,
          Telefono = request.Body.phone,
          Estado = true,
          FechaCreacion = DateTime.Now
        };

        await _repository.AddAsync(userDTO);
        await _repository.SaveChangesAsync();

        var signInResponse = new SignInResponse {          
          name = request.Body.name,
          surname = request.Body.surname,
          email = request.Body.email,
          token = _tokenGenerator.GenerateToken(credentials)
        };

        return responseFactory.GetCreated(signInResponse);
      }
    }
  }
}
