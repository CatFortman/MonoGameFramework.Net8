using Microsoft.Xna.Framework;
using MonoGameLibrary.ECS.Interfaces;

namespace MonoGameEntry.ECS.Components;

public struct PositionComponent : IComponent
{
    public Vector2 Value;
}

