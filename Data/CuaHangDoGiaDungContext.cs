using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CuaHangDoGiaDung.Models;

namespace CuaHangDoGiaDung.Data
{
    public class CuaHangDoGiaDungContext : DbContext
    {
        public CuaHangDoGiaDungContext (DbContextOptions<CuaHangDoGiaDungContext> options)
            : base(options)
        {
        }

        public DbSet<CuaHangDoGiaDung.Models.DoGiaDung> DoGiaDung { get; set; }
    }
}
