﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCookingBook.DbContexts;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.Service
{
    public class ApplicationRepository: IApplicationRepository

    {
        private readonly ApplicationContext _context;

        public ApplicationRepository(ApplicationContext context) 
        {
            this._context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
        }

		public async Task AddIngredientAsync(int recipeID, Ingredient Ingredient)
		{
			var recipe = await _context.Recipes.FirstOrDefaultAsync(c=>c.Id == recipeID);
            if(recipe != null)
            {
                recipe.Ingredients.Add(Ingredient);
            }
		}

		public async Task AddRecipeAsync(int categoryId, Recipe recipe)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);      
            if(category != null)
            {
				category.Recipes.Add(recipe);
			}           
        }

        public void DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
        }

		public void DeleteIngredientAsync(Ingredient Ingredient)
		{
			throw new NotImplementedException();
		}

		public void DeleteRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }

        public async Task<bool> ExistsCategoryAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c=>c.Id == categoryId);
        }

		public Task<bool> ExistsIngredienteAsync(int IngredientId)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> ExistsRecipeAsync(int recipeId)
        {
            return await _context.Recipes.AnyAsync(c=> c.Id == recipeId);
        }

		public async Task<IEnumerable<Category>> GetCategoriesAsync(string searchCategory)
        {
            if (string.IsNullOrWhiteSpace(searchCategory))
            {
                return await GetCategoriesAsync();
            }
            searchCategory = searchCategory.Trim();
            return await _context.Categories.Where(c => c.NameCategory == searchCategory).ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c=>c.Id == categoryId).FirstOrDefaultAsync();
        }

		public async Task<Ingredient> GetIngredientAsync(int IngredientId)
		{
            return await _context.Ingredients.Where(c => c.Id == IngredientId).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
		{
            return await _context.Ingredients.ToListAsync();
		}

		public async Task<IEnumerable<Ingredient>> GetIngredientsAsync(int recipeId)
		{
            return await _context.Ingredients.Where(c => c.RecipeId == recipeId).ToListAsync();
		}

		public Task<IEnumerable<Ingredient>> GetIngredientsAsync(int recipeId, string searchIngredient)
		{
			throw new NotImplementedException();
		}

		public async Task<Recipe> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.Where(f =>f.Id == recipeId).FirstOrDefaultAsync();
        }
		public async Task<IEnumerable<Recipe>> GetRecipesAsync()
		{
            return await _context.Recipes.ToListAsync();
		}
        public async Task<IEnumerable<Recipe>> GetRecipesAsync(string seacrhRecipe)
        {
            if (string.IsNullOrWhiteSpace(seacrhRecipe)) return await GetRecipesAsync();
            seacrhRecipe = seacrhRecipe.Trim();
            return await _context.Recipes.Where(c => c.Name.Contains(seacrhRecipe)).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCategoryAsync(Category category)
        {
            
        }

		public void UpdateIngredientAsync(Ingredient Ingredient)
		{
			
		}

		public void UpdateRecipeAsync(Recipe recipe)
        {
            
        }
    }
}
