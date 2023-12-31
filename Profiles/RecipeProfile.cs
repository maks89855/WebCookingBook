﻿using AutoMapper;
using WebCookingBook.API.DTOModels;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<CreateRecipeDTO, Recipe>();
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<RecipeDTO, Recipe>();
            CreateMap<UpdateRecipeDTO, Recipe>();
            CreateMap<Recipe, UpdateRecipeDTO>();
        }
    }
}
