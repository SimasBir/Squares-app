using FluentValidation;
using Squares_server.Dtos;


namespace Squares_server.Validators
{
    public class PointModelDtoValidator : AbstractValidator<PointModelDto>
    {
        public PointModelDtoValidator()
        {
            RuleFor(x => x.xCoord).InclusiveBetween(-5000,5000);
            RuleFor(x => x.yCoord).InclusiveBetween(-5000,5000);
        }
    }
}
