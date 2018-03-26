using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSquares.Data.EntityModels;

namespace PrivateSquares.Data.Configurations
{
    public class UserRoleConfiguration
    {
        public UserRoleConfiguration(EntityTypeBuilder<UserRole> entityTypeBuilder)
        {
            Configure(entityTypeBuilder);
        }

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.ID);
        }
    }
}
