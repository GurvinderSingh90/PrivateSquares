using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSquares.Data.EntityModels;

namespace PrivateSquares.Data.Configurations
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            Configure(entityTypeBuilder);
        }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.ID);
        }
    }
}
