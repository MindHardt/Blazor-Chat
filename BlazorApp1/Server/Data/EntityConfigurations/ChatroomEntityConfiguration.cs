﻿using BlazorApp1.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp1.Server.Data.EntityConfigurations;

public class ChatroomEntityConfiguration : IEntityTypeConfiguration<Chatroom>
{
    public void Configure(EntityTypeBuilder<Chatroom> builder)
    {
        builder.HasKey(chatroom => chatroom.Id);

        builder.HasMany(chat => chat.Messages)
            .WithOne(message => message.Chat)
            .HasForeignKey(message => message.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(chat => chat.Users)
            .WithMany(user => user.Chatrooms)
            .UsingEntity(e => e.ToTable("UserChats"));
    }
}