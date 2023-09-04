using Amazon.Runtime.Internal.Settings;
using YaqeenServices.DTOs;

namespace YaqeenServices.Servcies
{
    public interface IUserServices
    {
        Task<SingleResult<bool>> CreateUser(UserCreateDto userCreateDto, string idpUserIdentifier);
    }
}