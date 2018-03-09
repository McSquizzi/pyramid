using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PyramidStore.Core.Interfaces;
using PyramidStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidStore.DL
{
    public class PyramidStoreContext: IdentityDbContext<User>, IPyramidStoreContext
    {
        public PyramidStoreContext(DbContextOptions<PyramidStoreContext> options)
            :base(options)
        {
            var t = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
                
        }
        
    }
}
