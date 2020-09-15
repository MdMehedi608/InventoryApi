using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PizzamiaCore.Helpers
{
    internal class ValidationResultModel
    {
        private ModelStateDictionary modelState;

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }
    }
}