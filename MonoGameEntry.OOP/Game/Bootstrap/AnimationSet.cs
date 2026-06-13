
using System.Collections.Generic;
using MonoGameEntry.OOP.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.OOP.Game.Bootstrap;
public class AnimationSet
{
    public Dictionary<PlayerAnimationState, AnimatedSprite> Animations { get; init; }
}