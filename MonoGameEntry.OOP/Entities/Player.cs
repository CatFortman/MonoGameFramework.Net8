using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using MonoGameEntry.OOP.Entities;
using MonoGameEntry.OOP.Entities.Interfaces;
using System.Collections.Generic;
using MonoGameEntry.OOP.Enums;
using MonoGameEntry.Common.Enums;
using MonoGameEntry.OOP.Entities.Abstractions;

public class Player : AnimatedGameObject, IGameObject, ICollidable
{

    private const float AttackDuration = 0.5f;
    private const float JumpDuration = 0.9f;
    private const float InteractDuration = 0.4f;
    public Vector2 _position;
    private Direction _facing = Direction.Down;
    private readonly float _speed = 2f;
    private readonly float _runSpeedMultiplier = 1.5f;
    private ActionState _actionState;
    private float _actionDuration;

    public Player(
    Dictionary<AnimationKey, AnimatedSprite> animations,
    Vector2 startPosition)
    {
        Animations = animations;

        CurrentAnimation = PlayerAnimations.IdleUp;
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
        UpdateActionDuration(gameTime);
    }

    public void MovePlayer(PlayerInput input, Rectangle bounds)
    {
        float speed = _speed;

        if (input.Run)
            speed *= _runSpeedMultiplier;

        _position += input.Movement * speed;

        UpdateFacing(input.Movement);

        if (_facing == Direction.Left)
        {
            Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            Effects = SpriteEffects.None;
        }

        SetPlayerAnimation(input);

        SetActionState(input);

        ClampToBounds(bounds);
    }

    private void UpdateActionDuration(GameTime gameTime)
    {
        if (_actionState != ActionState.None)
        {
            _actionDuration -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_actionDuration <= 0)
            {
                _actionState = ActionState.None;
            }
        }
    }

    private void SetPlayerAnimation(PlayerInput input)
    {
        if (input.Attack)
        {
            SetAnimation(GetAttackAnimation());
        }
        else if (input.Jump)
        {
            SetAnimation(GetJumpAnimation());
        }
        else if (input.Interact)
        {
            SetAnimation(GetInteractAnimation());
        }
        else if (input.Movement != Vector2.Zero)
        {
            if (input.Run)
            {
                SetAnimation(GetRunAnimation());
            }
            else
            {
                SetAnimation(GetWalkAnimation());
            }
        }
        else
        {
            SetAnimation(GetIdleAnimation());
        }
    }

    private void SetActionState(PlayerInput input)
    {
        if(_actionState != ActionState.None)
            return;

        if (input.Attack)
        {
            _actionState = ActionState.Attack;
            _actionDuration = AttackDuration;
        }
        else if (input.Jump)
        {
            _actionState = ActionState.Jump;
            _actionDuration = JumpDuration;
        }
        else if (input.Interact)
        {
            _actionState = ActionState.Interact;
            _actionDuration = InteractDuration;
        }
    }

    private AnimationKey GetAttackAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimations.AttackUp,
            Direction.Left => PlayerAnimations.AttackRight,
            Direction.Right => PlayerAnimations.AttackRight,
            _ => PlayerAnimations.AttackDown
        };
    }

    private AnimationKey GetJumpAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimations.JumpUp,
            Direction.Left => PlayerAnimations.JumpRight,
            Direction.Right => PlayerAnimations.JumpRight,
            _ => PlayerAnimations.JumpDown
        };
    }

    private AnimationKey GetInteractAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimations.InteractUp,
            Direction.Left => PlayerAnimations.InteractRight,
            Direction.Right => PlayerAnimations.InteractRight,
            _ => PlayerAnimations.InteractDown
        };
    }

    private AnimationKey GetRunAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimations.RunUp,
            Direction.Left => PlayerAnimations.RunRight,
            Direction.Right => PlayerAnimations.RunRight,
            _ => PlayerAnimations.RunDown
        };
    }

    private AnimationKey GetWalkAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimations.WalkUp,
            Direction.Left => PlayerAnimations.WalkRight,
            Direction.Right => PlayerAnimations.WalkRight,
            _ => PlayerAnimations.WalkDown
        };
    }

    private AnimationKey GetIdleAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimations.IdleUp,
            Direction.Left => PlayerAnimations.IdleRight,
            Direction.Right => PlayerAnimations.IdleRight,
            _ => PlayerAnimations.IdleDown
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
        Sprite.Draw(spriteBatch, _position, Effects);
    }

    private void ClampToBounds(Rectangle bounds)
    {
        _position = new Vector2(
            MathHelper.Clamp(_position.X, bounds.Left, bounds.Right - Sprite.Width),
            MathHelper.Clamp(_position.Y, bounds.Top, bounds.Bottom - Sprite.Height)
        );
    }
}