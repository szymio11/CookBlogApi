﻿using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record CreateCategory(string FullName) : ICommand;
