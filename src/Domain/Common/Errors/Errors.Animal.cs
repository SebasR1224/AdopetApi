using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Animal
    {
        public static Error AnimalNotFound => Error.NotFound(
            "Animal.NotFound",
            "Animal not found. Please check the ID and try again."
        );
    }
}

