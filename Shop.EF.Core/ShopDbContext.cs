using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shop.EF.Core
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext()
        {
        }
    }

    public class TestTable
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}
