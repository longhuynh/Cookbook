using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Cookbook.Services.Recipes;
using Smartwebs.Cookbook.Services.Recipes.Dtos;
using Smartwebs.Cookbook.Services.Recipes.MapperProfiles;
using Smartwebs.Domain.Repositories;
using Xunit;

namespace Smartwebs.Cookbook.Service.Test.Recipes
{
    public class RecipeServiceTests
    {
        public RecipeServiceTests()
        {
            Mapper.Reset();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new RecipeMapperProfile());
            });
        }


        [Fact]
        public async Task GetAllResturnExpected()
        {
            // Arrange      
            var testData = new List<Recipe>
            {
                new Recipe {Id = 1, Description = "Description 1"},
                new Recipe {Id = 2, Description = "Description 2"},
                new Recipe {Id = 3, Description = "Description 3"},
                new Recipe {Id = 4, Description = "Description 4"}
            };

            var recipeRepository = A.Fake<IRepository<Recipe, long>>();
            A.CallTo(() => recipeRepository.GetAllList()).Returns(testData);

            var recipeVersionRepository = A.Fake<IRepository<RecipeVersion, long>>();

            var service = new RecipeService(recipeRepository, recipeVersionRepository);

            // Act
            var resultDto = await service.GetAll();

            // Assert
            Assert.Equal(4, resultDto.Items.Count);
            Assert.Equal(1, resultDto.Items.First().Id);
        }

        [Fact]
        public void GetResturnExpected()
        {
            // Arrange      
            var createdDateTestData = new DateTime(2017, 7, 3);
            var recipeData = new Recipe { Id = 1, Description = "Description 1"};

            var recipeRepository = A.Fake<IRepository<Recipe, long>>();
            A.CallTo(() => recipeRepository.Get(A<long>.Ignored)).Returns(recipeData);

            var recipeVersionRepository = A.Fake<IRepository<RecipeVersion, long>>();

            var service = new RecipeService(recipeRepository, recipeVersionRepository);

            // Act
            var resultDto = service.Get(1);

            // Assert
            Assert.Equal(1, resultDto.Id);
        }

        [Fact]
        public void CreateRecipeTest()
        {
            // Arrange        
            var recipeData = new Recipe { Id = 1, Description = "Description 1" };
            var recipeVersionData = new RecipeVersion { Id = 1, RecipeId = null, Description = "Description 1" };

            int callCount = 0;

            var recipeRepository = A.Fake<IRepository<Recipe, long>>();
            A.CallTo(() => recipeRepository.InsertAsync(A<Recipe>.Ignored)).Returns(recipeData);
            A.CallTo(() => recipeRepository.SaveChangeAsync()).Invokes(c => callCount++);

            var recipeVersionRepository = A.Fake<IRepository<RecipeVersion, long>>();
            A.CallTo(() => recipeVersionRepository.InsertAsync(A<RecipeVersion>.Ignored)).Returns(recipeVersionData);
            A.CallTo(() => recipeVersionRepository.SaveChangeAsync()).Invokes(c => callCount++);

            var service = new RecipeService(recipeRepository, recipeVersionRepository);

            // Act
           var recipeDto = service.Create(new CreateRecipeInput()).Result;

            // Assert
            Assert.Equal(recipeData.Description, recipeDto.Description);
            Assert.Equal(2, callCount);
        }

    }
}
