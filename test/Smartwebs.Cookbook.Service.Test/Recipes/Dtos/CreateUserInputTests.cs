using System.Threading.Tasks;
using Shouldly;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Cookbook.Service.Test.Dtos;
using Smartwebs.Cookbook.Services.Recipes.Dtos;
using Xunit;

namespace Smartwebs.Cookbook.Service.Test.Recipes.Dtos
{
    public class CreateRecipeInputTests : DtoTestBase<CreateRecipeInput>
    {
        protected override CreateRecipeInput GetDto()
        {
            return new CreateRecipeInput
            {
               Description = "Description"
            };
        }

        [Fact]
        public async Task DescriptionWithNullValueShouldCauseValidationFailure()
        {
            //Arrange
            var createInput = GetDto();
            createInput.Description = null;

            //Act, Assert
            await Validate(createInput)
                .ShouldThrowAsync<ShouldAssertException>();
        }

      
        [Fact]
        public async Task DescriptionWithOverMaxLengthValueShouldCauseValidationFailure()
        {
            //Arrange
            var createInput = GetDto();
            createInput.Description = new string('a', RecipeBase.MaxDescriptionLength + 1);

            //Act, Assert
            await Validate(createInput)
                .ShouldThrowAsync<ShouldAssertException>();
        }
    }
}