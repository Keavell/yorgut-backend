using Yogurt.Application.Dto;
using Yogurt.Domain.Entities;

namespace Yogurt.Application.Interfaces
{
    public interface IUserService
    {
        Task<ReturnDto> Login(string email, string senha);

        Task<ReturnDto> SendToken(string email);

        Task<ReturnDto> Register(string email, string password, string userName, string telefone);

        Task<ReturnDto> VerifyToken(string token, string password);

        Task<ReturnDto> DeleteUser(Guid? userId, string? password);

    }
}
