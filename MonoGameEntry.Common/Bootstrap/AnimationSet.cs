using System.Collections.Generic;
using MonoGameEntry.Common.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.Common.Bootstrap;

public class AnimationSet
{
    public Dictionary<AnimationKey, AnimatedSprite> Animations { get; init; }
}
