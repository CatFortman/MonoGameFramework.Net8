// <copyright file="SceneKey.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MonoGameLibrary.Scenes;

/// <summary>
/// A struct that can be used as a key for identifying scenes. It can wrap any object, such as an enum value or a string.
/// </summary>
public readonly struct SceneKey
{
    public object Value { get; }

    public SceneKey(object value)
    {
        this.Value = value;
    }

    /// <inheritdoc/>
    public override string ToString() => this.Value?.ToString();
}