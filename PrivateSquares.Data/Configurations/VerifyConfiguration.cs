using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSquares.Data.EntityModels;

namespace PrivateSquares.Data.Configurations
{
    public class VerifyConfiguration
    {
        public VerifyConfiguration(EntityTypeBuilder<Verify> entityTypeBuilder)
        {
            Configure(entityTypeBuilder);
        }

        public void Configure(EntityTypeBuilder<Verify> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(200);
        }
    }
}
