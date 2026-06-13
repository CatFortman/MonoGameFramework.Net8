// <copyright file="ISceneContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Input;

namespace MonoGameLibrary.Scenes;

public interface ISceneContext
{
    GameContext Game { get; }

    GraphicsDevice GraphicsDevice { get; }

    ContentManager Content { get; }

    InputManager Input { get; }
}