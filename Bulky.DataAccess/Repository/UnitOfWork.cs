﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }


		public void Save()
		{
			try
			{
				_db.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR during SaveChanges: " + ex.Message);
				throw;
			}
		}

	}
}
