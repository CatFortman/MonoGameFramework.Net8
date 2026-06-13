namespace MonoGameEntry.ECS.Enums;

/// <summary>
/// Wrapper around <see cref="EnemyAnimationState"/> that implements <see cref="IAnimationState"/>.
/// Provides implicit conversions to make adoption easy.
/// </summary>
public readonly struct EnemyAnimationStateWrapper : IAnimationState
{
    public EnemyAnimationState State { get; }

    public int Value => (int)State;

    public string Name => State.ToString();

    public EnemyAnimationStateWrapper(EnemyAnimationState state) => State = state;

    public override string ToString() => Name;

    public static implicit operator EnemyAnimationState(EnemyAnimationStateWrapper w) => w.State;

    public static implicit operator EnemyAnimationStateWrapper(EnemyAnimationState s) => new EnemyAnimationStateWrapper(s);
}
