﻿using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Persistence.Context
{
	public class MovieContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-Q80IDIO;initial Catalog=ApiMovieDb;integrated Security=true; TrustServerCertificate=true;");
		}

		public DbSet<Cast> Casts { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Movie> Movies { get; set; }

		public DbSet<Review> Reviews { get; set; }

		public DbSet<Tag> Tags { get; set; }
	}
}
