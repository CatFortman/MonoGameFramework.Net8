using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using MonoGameEntry.OOP.Entities;
using MonoGameEntry.OOP.Entities.Interfaces;
using System.Collections.Generic;
using MonoGameEntry.OOP.Enums;
using MonoGameEntry.OOP.Entities.Abstractions;
using System;

public class Player : AnimatedGameObject, IGameObject, ICollidable
{
    public Vector2 _position;
    private Direction _facing = Direction.Down;
    private readonly float _speed = 2f;
    private readonly float _sprintMultiplier = 1.5f;

    public Player(
    Dictionary<AnimationState, AnimatedSprite> animations,
    Vector2 startPosition)
    {
        Animations = animations;

        CurrentAnimation = AnimationState.IdleDown;
        Sprite = animations[CurrentAnimation];

        _position = startPosition;
    }
    public Rectangle Bounds =>
        new Rectangle(
            (int)_position.X,
            (int)_position.Y,
            (int)Sprite.Width,
            (int)Sprite.Height
        );

    public void Update(GameTime gameTime)
    {
        Sprite.Update(gameTime);
    }

    public void MovePlayer(PlayerInput input, Rectangle bounds)
    {
        float speed = _speed;

        if (input.Sprint)
            speed *= _sprintMultiplier;

        _position += input.Movement * speed;

        UpdateFacing(input.Movement);

        if (input.Attack)
        {
            SetAnimation(GetAttackAnimation());
        }
        else if (input.Movement != Vector2.Zero)
        {
            SetAnimation(GetWalkAnimation());
        }
        else
        {
            SetAnimation(GetIdleAnimation());
        }
        
        ClampToBounds(bounds);
    }

    private AnimationState GetAttackAnimation()
    {
        return _facing switch
        {
            Direction.Up => AnimationState.AttackUp,
            Direction.Right => AnimationState.AttackRight,
            _ => AnimationState.AttackDown
        };
    }

    private AnimationState GetWalkAnimation()
    {
        return _facing switch
        {
            Direction.Up => AnimationState.WalkUp,
            Direction.Right => AnimationState.WalkRight,
            _ => AnimationState.WalkDown
        };
    }

    private AnimationState GetIdleAnimation()
    {
        return _facing switch
        {
            Direction.Up => AnimationState.IdleUp,
            Direction.Right => AnimationState.IdleRight,
            _ => AnimationState.IdleDown
        };
    }

    private void UpdateFacing(Vector2 movement)
    {
        if (movement.X > 0)
            _facing = Direction.Right;
        else if (movement.X < 0)
            _facing = Direction.Left;
        else if (movement.Y > 0)
            _facing = Direction.Down;
        else if (movement.Y < 0)
            _facing = Direction.Up;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, _position);
    }

    private void ClampToBounds(Rectangle bounds)
    {
        _position = new Vector2(
            MathHelper.Clamp(_position.X, bounds.Left, bounds.Right - Sprite.Width),
            MathHelper.Clamp(_position.Y, bounds.Top, bounds.Bottom - Sprite.Height)
        );
    }
}