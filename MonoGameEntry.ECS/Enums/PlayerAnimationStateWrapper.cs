namespace MonoGameEntry.ECS.Enums;

/// <summary>
/// Wrapper around <see cref="PlayerAnimationState"/> that implements <see cref="IAnimationState"/>.
/// Provides implicit conversions to make adoption easy.
/// </summary>
public readonly struct PlayerAnimationStateWrapper : IAnimationState
{
    public PlayerAnimationState State { get; }

    public int Value => (int)State;

    public string Name => State.ToString();

    public PlayerAnimationStateWrapper(PlayerAnimationState state) => State = state;

    public override string ToString() => Name;

    public static implicit operator PlayerAnimationState(PlayerAnimationStateWrapper w) => w.State;

    public static implicit operator PlayerAnimationStateWrapper(PlayerAnimationState s) => new PlayerAnimationStateWrapper(s);
}
