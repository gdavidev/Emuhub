using Emuhub.Exceptions.Exceptions.ValidationError;
using Newtonsoft.Json.Linq;

namespace Emuhub.Application.Serialization
{
    public static class ValidationErrorSerializer
    {
        public static JObject ToResponse(List<ValidationErrorItem> errors)
        {
            var errorsObject = new JObject();
            errors.ForEach(item =>
            {
                errorsObject.Add(new JProperty(item.PropertyName, item.Message));
            });

            var response = new JObject()
            {
                new JProperty("Errors", errorsObject)
            };

            return response;
        }
    }
}
