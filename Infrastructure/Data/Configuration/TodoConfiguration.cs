using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todos");
        builder.Property(T => T.Title).IsRequired();
        builder.HasKey(T => T.Id);
    }
}