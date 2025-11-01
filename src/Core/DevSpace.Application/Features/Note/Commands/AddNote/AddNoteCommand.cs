using DevSpace.Application.Common.Models.Results;
using DevSpace.SharedKernel.Extensions;
using System.Text.Json.Serialization;
using FluentValidation;
using Mediator;

namespace DevSpace.Application.Features.Note.Commands.AddNote;

public record AddNoteCommand(
    string Title,
    string Text,
    IEnumerable<string> Tags
) : IRequest<OperationResult<bool>>, IValidatableModel<AddNoteCommand>
{
    [JsonIgnore]
    public int OwnerId { get; set; }

    public IValidator<AddNoteCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddNoteCommand> validator)
    {
        validator.RuleFor(c => c.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(200);

        validator.RuleFor(c => c.Text)
            .NotEmpty()
            .NotNull();

        validator.RuleForEach(x => x.Tags)
            .NotEmpty()
            .MaximumLength(50);

        return validator;
    }
}
