using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        // If all the Errors in the list are validation errors then this condition will handle it
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            // This dictionary is specialised to handle valdiation errors such as checking if the dictionary is valid and the ability to add model errors
            // to the dictionary. It will be used to store all the validation errors.
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                // Add an error message to the errors collection for the model-state dictionary
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            // Returns the problem with a 400 status code and also all the validation errors as another property
            return ValidationProblem(modelStateDictionary);
        }

        // If the error is an internal server error, then a default Problem object is returned which has a 500 status code
        if (errors.Any(e => e.Type == ErrorType.Unexpected))
        {
            return Problem();
        }

        // The type of the first error (defined in ServiceErrors) that is thrown will be returned
        var firstError = errors[0];

        // Getting the status code for the error in the below switch case
        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        // This is for a non-validation type error, or where all the errors in the list are not validation errors
        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}