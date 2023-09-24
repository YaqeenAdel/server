using YaqeenServices.DTOs;

namespace YaqeenServices.Services
{
    public interface IUserServices
    {
        Task<SingleResult<bool>> CreateUser(UserCreateDto userCreateDto, string idpUserIdentifier);
    }
}