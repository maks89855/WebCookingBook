﻿using System.ComponentModel.DataAnnotations.Schema;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
    public class CreateStepDTO
    {
        public int NumberStep { get; set; }
        public string Discription { get; set; }
    }
}
