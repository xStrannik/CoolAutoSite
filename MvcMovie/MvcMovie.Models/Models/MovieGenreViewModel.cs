﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models.DTO;

namespace MvcMovie.Models.Models
{
    public class MovieGenreViewModel
    {
        public List<MovieDTO> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
