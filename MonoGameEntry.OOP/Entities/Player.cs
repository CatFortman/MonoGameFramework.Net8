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
    Dictionary<PlayerAnimationState, AnimatedSprite> animations,
    Vector2 startPosition)
    {
        Animations = animations;

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

    private PlayerAnimationState GetAttackAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimationState.AttackUp,
            Direction.Left => PlayerAnimationState.AttackRight,
            Direction.Right => PlayerAnimationState.AttackRight,
            _ => PlayerAnimationState.AttackDown
        };
    }

    private PlayerAnimationState GetJumpAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimationState.JumpUp,
            Direction.Left => PlayerAnimationState.JumpRight,
            Direction.Right => PlayerAnimationState.JumpRight,
            _ => PlayerAnimationState.JumpDown
        };
    }

    private PlayerAnimationState GetInteractAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimationState.InteractUp,
            Direction.Left => PlayerAnimationState.InteractRight,
            Direction.Right => PlayerAnimationState.InteractRight,
            _ => PlayerAnimationState.InteractDown
        };
    }

    private PlayerAnimationState GetRunAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimationState.RunUp,
            Direction.Left => PlayerAnimationState.RunRight,
            Direction.Right => PlayerAnimationState.RunRight,
            _ => PlayerAnimationState.RunDown
        };
    }

    private PlayerAnimationState GetWalkAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimationState.WalkUp,
            Direction.Left => PlayerAnimationState.WalkRight,
            Direction.Right => PlayerAnimationState.WalkRight,
            _ => PlayerAnimationState.WalkDown
        };
    }

    private PlayerAnimationState GetIdleAnimation()
    {
        return _facing switch
        {
            Direction.Up => PlayerAnimationState.IdleUp,
            Direction.Left => PlayerAnimationState.IdleRight,
            Direction.Right => PlayerAnimationState.IdleRight,
            _ => PlayerAnimationState.IdleDown
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