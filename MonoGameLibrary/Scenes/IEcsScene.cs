// <copyright file="IEcsScene.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.ECS;

namespace MonoGameLibrary.Scenes;

public interface IEcsScene : IScene
{
    EntityManager Entities { get; }

    SpriteFont Font { get; }
}