using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using YaqeenDAL.Model;
using YaqeenDAL.Repositories;
using YaqeenInfrastructure;
using YaqeenServices.DTOs;

namespace YaqeenServices.Servcies
{
    internal class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserServices> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<UserCreateDto> _validator;

        public UserServices(IUserRepository userRepository, ILogger<UserServices> logger, IMapper mapper, IValidator<UserCreateDto> validator)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<SingleResult<bool>> CreateUser(UserCreateDto userCreateDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(userCreateDto);
                if (!validationResult.IsValid)
                {
                    return new SingleResult<bool>(validationResult);
                }

                var user = _mapper.Map<User>(userCreateDto);
                return (await _userRepository.CreateAsync(user))?
                    new SingleResult<bool>(true) : new SingleResult<bool>(ErrorCodes.UserErrorCodes.FailedToStoreUserToDb);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error_{nameof(CreateUser)}");
                return new SingleResult<bool>(ErrorCodes.UserErrorCodes.FailedToStoreUserLogicError);
            }
        }
    }
}