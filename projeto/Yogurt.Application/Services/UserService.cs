using Yogurt.Application.Dto;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Domain.Entities.User;
using Yogurt.Infraestructure.Interfaces.User;

namespace Yogurt.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;

        public UserService(IUserRepository repository)
        {
            _usuarioRepository = repository;
        }

        public async Task<ReturnDto> Login(string? email, string? senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return new ReturnDto("Informe o email e a senha para logar no site",
                    StatusCodeEnum.Return.BadRequest);
            }

            var result = await _usuarioRepository.GetByEmail(email);

            if (result == null)
            {
                return new ReturnDto("Login ou senha inválidos!", StatusCodeEnum.Return.NotFound);
            }

            return Utils.Utils.RetornarHash(senha) != result.Password
                ? new ReturnDto("Login ou senha inválidos!", StatusCodeEnum.Return.BadRequest)
                : new ReturnDto("Logado com Sucesso!", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> SendToken(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new ReturnDto("Os campos Email e Senha não podem ser nulos.", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _usuarioRepository.GetByEmail(email);

            if (result == null)
            {
                return new ReturnDto("Email inválido!", StatusCodeEnum.Return.NotFound);
            }

            string token = Utils.Utils.GenerateToken(email);
            string message = SendEmaill.SendEmail(result, token);
            _usuarioRepository.UpdateToken(token, result);


            return new ReturnDto(message, message.Contains("Sucesso") ? StatusCodeEnum.Return.Sucess : StatusCodeEnum.Return.NotFound);
        }

        public async Task<ReturnDto> Register(string email, string password, string userName, string telefone)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userName) || telefone == null)
            {
                return new ReturnDto("Os campos Email, Senha, UserName e Telefone não podem ser nulos.",
                    StatusCodeEnum.Return.NotFound);
            }

            if (userName.Length < 3)
            {
                return new ReturnDto("O Username não pode conter menos de 3 caractéres.", StatusCodeEnum.Return.BadRequest);
            }

            if (password.Length < 8)
            {
                return new ReturnDto("A senha não pode conter menos de 8 caractéres.", StatusCodeEnum.Return.BadRequest);
            }

            if (!Utils.Utils.VerificarEmail(email))
            {
                return new ReturnDto("O email informado é invalido! por favor, informe um email válido.",
                    StatusCodeEnum.Return.NotFound);
            }

            await _usuarioRepository.Insert(new UserEntity(email, Utils.Utils.RetornarHash(password), $"@{userName}", telefone));

            var user = await _usuarioRepository.GetByUsername($"@{userName}");

            return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess, user.Id);
        }

        public async Task<ReturnDto> VerifyToken(string token, string password)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(password))
            {
                return new ReturnDto("Os campos informados senha e token não pode ser nulo.", StatusCodeEnum.Return.NotFound);
            }

            if (password.Length < 8)
            {
                return new ReturnDto("A senha não pode conter menos de 8 caractéres.", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _usuarioRepository.GetByToken(token);

            if (result == null)
            {
                return new ReturnDto("O token informado é inválido!", StatusCodeEnum.Return.NotFound);
            }

            if (result.Password == Utils.Utils.RetornarHash(password))
            {
                return new ReturnDto("A nova senha não pode ser igual a senha atual.", StatusCodeEnum.Return.BadRequest);
            }

            _usuarioRepository.UpdatePassword(Utils.Utils.RetornarHash(password), result);
            _usuarioRepository.UpdateToken("", result);

            return new ReturnDto("Sucesso!", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> DeleteUser(Guid? userId, string? password)
        {

            if (string.IsNullOrEmpty(password) || !userId.HasValue)
            {
                return new ReturnDto("Um dos valores necessários para realizar tal ação se encontra nulo.", StatusCodeEnum.Return.BadRequest);
            }

            var resultUser = await _usuarioRepository.GetById(userId.Value);

            if (resultUser == null)
            {
                return new ReturnDto("Usuario não foi encontrado", StatusCodeEnum.Return.NotFound);
            }

            if (resultUser.Password != Utils.Utils.RetornarHash(password))
            {
                return new ReturnDto("Dados do usuario não correspondentes!", StatusCodeEnum.Return.BadRequest);
            }

            try
            {
                await _usuarioRepository.RemoveByEntity(resultUser);
            }
            catch (Exception ex)
            {
                return new ReturnDto("Houve um erro no processamento do pedido!", StatusCodeEnum.Return.BadRequest);
            }


            return new ReturnDto("Usuario deletado com sucesso!", StatusCodeEnum.Return.Sucess);
        }
    }
}
