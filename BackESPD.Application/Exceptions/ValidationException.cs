using FluentValidation.Results;

namespace BackESPD.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        public ValidationException() : base("One or more errors of validation")
        {
            Errors = new List<string>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var item in failures)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
        public ValidationException(IEnumerable<string> errors) : this()
        {
            Errors.AddRange(errors);
        }
    }
}
