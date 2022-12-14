using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.Entities;

namespace WebApp.Data.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable(nameof(Card));
            builder.HasKey(x => x.CardID);
            builder.Property(x =>x.CardNumber).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SerialNumber).IsRequired().HasMaxLength(200);
        }
    }
}
