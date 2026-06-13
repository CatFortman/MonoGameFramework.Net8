// <copyright file="IWorldBoundsProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;

namespace MonoGameEntry.ECS.Interfaces;

public interface IWorldBoundsProvider
{
    Rectangle WorldBounds { get; }
}