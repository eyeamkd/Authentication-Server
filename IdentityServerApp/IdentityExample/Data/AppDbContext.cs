using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Data
{
    // IdentityDbContext contains all the Database tables that are related to Authentication 
    public class AppDbContext : IdentityDbContext //this means that AppDbContext is inherited from the class DbContext  
    {   
        //Database configuration done here
        public AppDbContext( DbContextOptions<AppDbContext> dbContextOptions ) : base(dbContextOptions)        
        {
            //base is the constructor that is defined in the internal Db Context and we are here  
            //inheriting that constructor by passing in our Db options  




        }
    }
}
