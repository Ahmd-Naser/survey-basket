namespace SurveyBasket.Api.Contracts.Questions;

public class QuestionRequestValidator : AbstractValidator<QuestionRequest>
{
    public QuestionRequestValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .Length(3, 1000);

        RuleFor(x => x.Answers)
            .NotNull();

        RuleFor(x => x.Answers)
            .Must(x => x.Count >= 2)
            .WithMessage("At least two answers are required.")
            .When(x => x.Answers != null);

        RuleFor(x => x.Answers)
            .Must(answers => answers.Distinct().Count() == answers.Count)
            .WithMessage("Answers must be unique.")
            .When(x => x.Answers != null);


    }
}
