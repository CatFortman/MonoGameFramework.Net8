using Microsoft.Xna.Framework;

namespace MonoGameEntry.ECS.Interfaces;

public interface IWorldBoundsProvider
{
    Rectangle WorldBounds { get; }
}