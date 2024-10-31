﻿using CompeiaSiparis.Data.Repository.IRepository;
using CompeiaSiparis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeiaSiparis.Data.Repository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private ApplicationDbContext _context;
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
