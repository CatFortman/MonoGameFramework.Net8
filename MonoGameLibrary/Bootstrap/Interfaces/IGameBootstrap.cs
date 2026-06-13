// <copyright file="IGameBootstrap.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MonoGameLibrary.Scenes;

namespace MonoGameLibrary.Bootstrap.Interfaces;
public interface IGameBootstrap
{
    IScene CreateInitialScene(GameContext context);
}