
using System.Collections.Generic;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.ECS.Game.Bootstrap;
public class AnimationSet
{
    public Dictionary<IAnimationState, AnimatedSprite> Animations { get; init; }
}