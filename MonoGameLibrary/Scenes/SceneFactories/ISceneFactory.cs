// <copyright file="ISceneFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MonoGameLibrary.Scenes
{
    public interface ISceneFactory
    {
        IScene CreateGameScene(GameContext context);
    }
}