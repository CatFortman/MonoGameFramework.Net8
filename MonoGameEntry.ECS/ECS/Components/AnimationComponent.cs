using System.Collections.Generic;
using MonoGameEntry.Common.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.ECS.Components;

public class AnimationComponent
{
    public Dictionary<AnimationKey, AnimatedSprite> Animations { get; init; } = new();

    public AnimationKey CurrentAnimation { get; set; }
}