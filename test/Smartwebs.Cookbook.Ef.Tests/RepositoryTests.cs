using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Domain.Repositories;
using Xunit;

namespace Smartwebs.Cookbook.Tests
{
    public class RepositoryTests
    {
        private readonly IRepository<Recipe, long> _recipeRepository;

        public RepositoryTests()
        {
            _recipeRepository = A.Fake<IRepository<Recipe, long>>();
        }

        [Fact]
        public void ShouldGetAllInitialRecipes()
        {
            // Create test data
            var createdDateTestData = new DateTime(2017, 7, 3);

            var testData = new List<Recipe>
            {
                new Recipe {Id = 1, Description = "Description 1", CreatedDate = createdDateTestData},
                new Recipe {Id = 2, Description = "Description 2"},
                new Recipe {Id = 3, Description = "Description 3"},
                new Recipe {Id = 4, Description = "Description 4"}
            };

            A.CallTo(() => _recipeRepository.GetAll()).Returns(testData.AsQueryable());

            // Act
            var recipes = _recipeRepository.GetAll();

            // Assert
            Assert.Equal(4, recipes.Count());
            Assert.Equal(1, recipes.First().Id);

            Assert.Equal("Description 1", recipes.First().Description);
            Assert.Equal(createdDateTestData, recipes.First().CreatedDate);
            Assert.Null(recipes.First().ModifiedDate);
        }

        [Fact]
        public void ShouldGetAllListInitialRecipes()
        {
            var testData = new List<Recipe>
            {
                new Recipe {Id = 1, Description = "Description 1"},
                new Recipe {Id = 2, Description = "Description 2"}
            };

            A.CallTo(() => _recipeRepository.GetAllList()).Returns(testData);

            // Act
            var recipes = _recipeRepository.GetAllList();

            // Assert
            Assert.Equal(2, recipes.Count);
        }

        [Fact]
        public void ShouldInsertRecipe()
        {
            // Create test data
            var createdDateTestData = new DateTime(2017, 7, 3);
            var testData = new Recipe {Id = 1, Description = "Description 1", CreatedDate = createdDateTestData};

            A.CallTo(() => _recipeRepository.InsertAsync(A<Recipe>.Ignored)).Returns(testData);
          

            // Act
            var recipe = _recipeRepository.InsertAsync(new Recipe()).Result;

            // Assert
            Assert.Equal(recipe.Id, testData.Id);
        }

        [Fact]
        public void ShouldUpdateRecipe()
        {
            // Create test data
            var testData = new Recipe { Id = 1, Description = "Description 1"};

            A.CallTo(() => _recipeRepository.UpdateAsync(A<Recipe>._)).Returns(testData);

            // Act
            var recipe = _recipeRepository.UpdateAsync(new Recipe()).Result;

            // Assert
            Assert.Equal(recipe.Description, testData.Description);
        }
    }
}