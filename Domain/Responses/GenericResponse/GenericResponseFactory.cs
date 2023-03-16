using System.Net;

namespace Domain.Responses.GenericResponses {
  public class GenericResponseFactory : IGenericResponseFactory {
    //200 - Petición aceptada
    public GenericResponse GetOK(object? resultData) {
      GenericResponse oGeneralResponse = new();
      oGeneralResponse.Status = (int) HttpStatusCode.OK;
      oGeneralResponse.Message = "¡El proceso se ha ejecutado correctamente!";
      oGeneralResponse.Data = resultData;
      oGeneralResponse.Date = DateTime.Now;
      return oGeneralResponse;
    }
    //201 - Creación de recursis
    public GenericResponse GetCreated(object? resultData) {
      GenericResponse oGeneralResponse = new();
      oGeneralResponse.Status = (int) HttpStatusCode.Created;
      oGeneralResponse.Message = "¡Registros procesados correctamente!";
      oGeneralResponse.Data = resultData;
      oGeneralResponse.Date = DateTime.Now;
      return oGeneralResponse;
    }
    //204 - Se acepta solicitud pero no hay datos para retornar
    public GenericResponse GetNoContent() {
      GenericResponse oGeneralResponse = new();
      oGeneralResponse.Status = (int) HttpStatusCode.NoContent;
      oGeneralResponse.Message = "¡No existen registros para la petición realizada!";
      oGeneralResponse.Data = null;
      oGeneralResponse.Date = DateTime.Now;
      return oGeneralResponse;
    }

    public GenericResponse GetError(Exception exception) {
      GenericResponse oGeneralResponse = new GenericResponse();
      oGeneralResponse.Status = (int) HttpStatusCode.InternalServerError;
      oGeneralResponse.Message = "Internal Server Error";
      oGeneralResponse.ErrorMessage = exception.Message ?? "¡Ha ocurrido un error inesperado!";
      oGeneralResponse.Data = null;
      oGeneralResponse.Date = DateTime.Now;
      return oGeneralResponse;
    }
    public GenericResponse GetErrorValidation(string message) {
      GenericResponse oGeneralResponse = new();
      oGeneralResponse.Status = (int) HttpStatusCode.BadRequest;
      oGeneralResponse.Message = "Bad Request";
      oGeneralResponse.ErrorMessage = message;
      oGeneralResponse.Data = null;
      oGeneralResponse.Date = DateTime.Now;
      return oGeneralResponse;
    }

  }
}