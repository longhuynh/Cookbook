using System.Threading.Tasks;
using Shouldly;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Cookbook.Service.Test.Dtos;
using Smartwebs.Cookbook.Services.Recipes.Dtos;
using Xunit;

namespace Smartwebs.Cookbook.Service.Test.Recipes.Dtos
{
    public class UpdateRecipeInputTests : DtoTestBase<UpdateRecipeInput>
    {
        protected override UpdateRecipeInput GetDto()
        {
            return new UpdateRecipeInput
            {
                Id = 1,
                Description = "Description"
            };
        }

        [Fact]
        public async Task DescriptionWithNullValueShouldCauseValidationFailure()
        {
            //Arrange
            var updateInput = GetDto();
            updateInput.Description = null;

            //Act, Assert
            await Validate(updateInput).ShouldThrowAsync<ShouldAssertException>();
        }

        [Fact]
        public async Task DescriptionWithEmptyValueShouldCauseValidationFailure()
        {
            //Arrange
            var updateInput = GetDto();
            updateInput.Description = string.Empty;

            //Act, Assert
            await Validate(updateInput).ShouldThrowAsync<ShouldAssertException>();
        }

        [Fact]
        public async Task DescriptionWithOverMaxLengthValueShouldCauseValidationFailure()
        {
            //Arrange
            var updateInput = GetDto();
            updateInput.Description = new string('a', RecipeBase.MaxDescriptionLength + 1);

            //Act, Assert
            await Validate(updateInput)
                .ShouldThrowAsync<ShouldAssertException>();
        }
    }
}