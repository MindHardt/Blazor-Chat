﻿namespace BlazorApp1.Shared.Requests.Chats;

public record AddUserInChatRequest
{
    public required int UserId { get; init; }
    public required int ChatId { get; init; }
}