// <copyright file="GamePadInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameLibrary.Input;

public class GamePadInfo
{
    private TimeSpan vibrationTimeRemaining = TimeSpan.Zero;

    /// <summary>
    /// Gets the index of the player this gamepad is for.
    /// </summary>
    public PlayerIndex PlayerIndex { get; }

    /// <summary>
    /// Gets the state of input for this gamepad during the previous update cycle.
    /// </summary>
    public GamePadState PreviousState { get; private set; }

    /// <summary>
    /// Gets the state of input for this gamepad during the current update cycle.
    /// </summary>
    public GamePadState CurrentState { get; private set; }

    /// <summary>
    /// Gets a value indicating whether gets a value that indicates if this gamepad is currently connected.
    /// </summary>
    public bool IsConnected => this.CurrentState.IsConnected;

    /// <summary>
    /// Gets the value of the left thumbstick of this gamepad.
    /// </summary>
    public Vector2 LeftThumbStick => this.CurrentState.ThumbSticks.Left;

    /// <summary>
    /// Gets the value of the right thumbstick of this gamepad.
    /// </summary>
    public Vector2 RightThumbStick => this.CurrentState.ThumbSticks.Right;

    /// <summary>
    /// Gets the value of the left trigger of this gamepad.
    /// </summary>
    public float LeftTrigger => this.CurrentState.Triggers.Left;

    /// <summary>
    /// Gets the value of the right trigger of this gamepad.
    /// </summary>
    public float RightTrigger => this.CurrentState.Triggers.Right;

    /// <summary>
    /// Initializes a new instance of the <see cref="GamePadInfo"/> class.
    /// Creates a new GamePadInfo for the gamepad connected at the specified player index.
    /// </summary>
    /// <param name="playerIndex">The index of the player for this gamepad.</param>
    public GamePadInfo(PlayerIndex playerIndex)
    {
        this.PlayerIndex = playerIndex;
        this.PreviousState = default(GamePadState);
        this.CurrentState = GamePad.GetState(playerIndex);
    }

    /// <summary>
    /// Updates the state information for this gamepad input.
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime)
    {
        this.PreviousState = this.CurrentState;
        this.CurrentState = GamePad.GetState(this.PlayerIndex);

        if (this.vibrationTimeRemaining > TimeSpan.Zero)
        {
            this.vibrationTimeRemaining -= gameTime.ElapsedGameTime;

            if (this.vibrationTimeRemaining <= TimeSpan.Zero)
            {
                this.StopVibration();
            }
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified gamepad button is current down.
    /// </summary>
    /// <param name="button">The gamepad button to check.</param>
    /// <returns>true if the specified gamepad button is currently down; otherwise, false.</returns>
    public bool IsButtonDown(Buttons button)
    {
        return this.CurrentState.IsButtonDown(button);
    }

    /// <summary>
    /// Returns a value that indicates whether the specified gamepad button is currently up.
    /// </summary>
    /// <param name="button">The gamepad button to check.</param>
    /// <returns>true if the specified gamepad button is currently up; otherwise, false.</returns>
    public bool IsButtonUp(Buttons button)
    {
        return this.CurrentState.IsButtonUp(button);
    }

    /// <summary>
    /// Returns a value that indicates whether the specified gamepad button was just pressed on the current frame.
    /// </summary>
    /// <param name="button">The gamepad button to check.</param>
    /// <returns>true if the specified gamepad button was just pressed on the current frame; otherwise, false.</returns>
    public bool WasButtonJustPressed(Buttons button)
    {
        return this.CurrentState.IsButtonDown(button) && this.PreviousState.IsButtonUp(button);
    }

    /// <summary>
    /// Returns a value that indicates whether the specified gamepad button was just released on the current frame.
    /// </summary>
    /// <param name="button">The gamepad button to check.</param>
    /// <returns>true if the specified gamepad button was just released on the current frame; otherwise, false.</returns>
    public bool WasButtonJustReleased(Buttons button)
    {
        return this.CurrentState.IsButtonUp(button) && this.PreviousState.IsButtonDown(button);
    }

    /// <summary>
    /// Sets the vibration for all motors of this gamepad.
    /// </summary>
    /// <param name="strength">The strength of the vibration from 0.0f (none) to 1.0f (full).</param>
    /// <param name="time">The amount of time the vibration should occur.</param>
    public void SetVibration(float strength, TimeSpan time)
    {
        this.vibrationTimeRemaining = time;
        GamePad.SetVibration(this.PlayerIndex, strength, strength);
    }

    /// <summary>
    /// Stops the vibration of all motors for this gamepad.
    /// </summary>
    public void StopVibration()
    {
        GamePad.SetVibration(this.PlayerIndex, 0.0f, 0.0f);
    }
}
