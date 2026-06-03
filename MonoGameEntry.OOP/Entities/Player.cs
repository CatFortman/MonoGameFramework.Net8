using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using MonoGameEntry.OOP.Entities;
using MonoGameEntry.OOP.Entities.Interfaces;
using System.Collections.Generic;
using MonoGameEntry.OOP.Enums;
using MonoGameEntry.OOP.Entities.Abstractions;

public class Player : AnimatedGameObject, IGameObject, ICollidable
{
    public Vector2 _position;

    private readonly float _speed = 2f;
    private readonly float _sprintMultiplier = 1.5f;

    public Player(
    Dictionary<AnimationState, AnimatedSprite> animations,
    Vector2 startPosition)
    {
        Animations = animations;

        CurrentAnimation = AnimationState.Idle;
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

        SetAnimation(
            input.Movement == Vector2.Zero
                ? AnimationState.Idle
                : AnimationState.Walk);

        ClampToBounds(bounds);
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