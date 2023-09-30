using FluentValidation;
using YaqeenInfrastructure;
using YaqeenServices.DTOs;

namespace YaqeenServices.Validations
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithErrorCode(ErrorCodes.UserErrorCodes.FirstNameMissing);
        }
    }
}
