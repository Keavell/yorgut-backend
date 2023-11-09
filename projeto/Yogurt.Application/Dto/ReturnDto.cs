using Yogurt.Application.Utils;

namespace Yogurt.Application.Dto
{
    public class ReturnDto
    {
        public string Message { get; set; }

        public StatusCodeEnum.Return StatusCode { get; set; }

        public object? Objeto { get; set; }
        
        public List<object?> ListaDeObjetos { get; set; }

        public ReturnDto(string mensagem, StatusCodeEnum.Return statusCode)
        {
            Message = mensagem;
            StatusCode = statusCode;
        }

        public ReturnDto(string mensagem, StatusCodeEnum.Return statusCode, object objeto)
        {
            Message = mensagem;
            StatusCode = statusCode;
            Objeto = objeto;
        }
        
        public ReturnDto(string mensagem, StatusCodeEnum.Return statusCode, List<object?> listaDeObjetos)
        {
            Message = mensagem;
            StatusCode = statusCode;
            ListaDeObjetos = listaDeObjetos;
        }
    }
}
