﻿using CookingBook.Domain.Entities;
using CookingBook.Domain.ValueObjects;
using CookingBook.Shared.Abstractions.Domain;

namespace CookingBook.Domain.Events;

public record StepAdded(Recipe Recipe, Step Step) : IDomainEvent;
