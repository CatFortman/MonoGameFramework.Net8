using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using MonoGameEntry.OOP.Entities.Interfaces;
using MonoGameEntry.OOP.Entities.Abstractions;
using System.Collections.Generic;
using MonoGameEntry.OOP.Enums;

namespace MonoGameEntry.OOP.Entities;

public class Enemy : AnimatedGameObject, IGameObject, ICollidable
{
    public Vector2 Position { get; private set; }
    public Vector2 Velocity { get; private set; }
    public bool DidBounce { get; private set; }

    public Enemy(Dictionary<AnimationKey, AnimatedSprite> animations, Vector2 startPosition)
    {
        Animations = animations;

        CurrentAnimation = EnemyAnimations.FlyDown;
        Sprite = animations[CurrentAnimation];

        Position = startPosition;
        Velocity = GenerateRandomVelocity();
    }

    public Rectangle Bounds =>
        new Rectangle((int)Position.X, (int)Position.Y, (int)Sprite.Width, (int)Sprite.Height);

    public void Update(GameTime gameTime)
    {
        Position += Velocity;
        Sprite.Update(gameTime);
    }

    public void Respawn(Rectangle bounds)
    {
        Position = new Vector2(
            Random.Shared.Next(bounds.Left, bounds.Right - (int)Sprite.Width),
            Random.Shared.Next(bounds.Top, bounds.Bottom - (int)Sprite.Height)
        );

        Velocity = GenerateRandomVelocity();
    }

    private Vector2 GenerateRandomVelocity()
    {
        float angle = (float)(Random.Shared.NextDouble() * Math.PI * 2);
        return new Vector2(MathF.Cos(angle), MathF.Sin(angle)) * 2f;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Position, Effects);
    }

    public void MoveEnemy(Rectangle bounds)
    {
        DidBounce = false;

        Position += Velocity;

        SetAnimation(
           Velocity == Vector2.Zero
               ? EnemyAnimations.FlyDown
               : EnemyAnimations.FlyDown);

        if (Position.X <= bounds.Left || Position.X + Sprite.Width >= bounds.Right)
        {
            Velocity = new Vector2(-Velocity.X, Velocity.Y);
            DidBounce = true;
        }

        if (Position.Y <= bounds.Top || Position.Y + Sprite.Height >= bounds.Bottom)
        {
            Velocity = new Vector2(Velocity.X, -Velocity.Y);
            DidBounce = true;
        }
    }
}