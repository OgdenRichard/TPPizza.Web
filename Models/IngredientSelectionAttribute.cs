using System.ComponentModel.DataAnnotations;

namespace TPPizza.Web.Models
{
    public class IngredientSelectionAttribute : ValidationAttribute
    {
        private readonly int _minSelection;
        private readonly int _maxSelection;

        public IngredientSelectionAttribute(int minSelection, int maxSelection)
        {
            _minSelection = minSelection;
            _maxSelection = maxSelection;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as List<string>;
            if (list != null)
            {
                if (list.Count < _minSelection || list.Count > _maxSelection)
                {
                    return new ValidationResult(ErrorMessage ?? $"Please select between {_minSelection} and {_maxSelection} ingredients.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
