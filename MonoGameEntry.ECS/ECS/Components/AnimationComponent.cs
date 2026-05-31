using System.Collections.Generic;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.ECS.Components;

public class AnimationComponent
{
    public Dictionary<AnimationState, AnimatedSprite> Animations { get; init; }

    public AnimationState CurrentAnimation { get; set; }
}