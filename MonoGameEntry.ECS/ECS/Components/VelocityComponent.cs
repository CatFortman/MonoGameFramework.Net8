using Microsoft.Xna.Framework;
using MonoGameLibrary.ECS.Interfaces;

namespace MonoGameEntry.ECS.Components;

public struct VelocityComponent : IComponent
{
    public Vector2 Value;
}
