using NGKS.Data.Config;
using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Config
{
    public class CategoryConfiguration : EntityBaseConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
