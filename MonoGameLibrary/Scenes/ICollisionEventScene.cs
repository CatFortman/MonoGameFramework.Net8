// <copyright file="ICollisionEventScene.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using MonoGameLibrary.ECS;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.ECS.Scenes;

public interface ICollisionEventScene : IEcsScene
{
    List<(Entity A, Entity B)> CollisionEvents { get; }
}