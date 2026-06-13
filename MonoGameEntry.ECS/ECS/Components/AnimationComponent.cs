using System.Collections.Generic;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.ECS.Components;

public class AnimationComponent
{
    public Dictionary<IAnimationState, AnimatedSprite> Animations { get; init; }

    public IAnimationState CurrentAnimation { get; set; }
}