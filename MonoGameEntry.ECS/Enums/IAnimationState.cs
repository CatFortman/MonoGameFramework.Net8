namespace MonoGameEntry.ECS.Enums;

/// <summary>
/// Represents a generalized animation state abstraction.
/// </summary>
public interface IAnimationState
{
    /// <summary>
    /// Numeric value of the underlying enum.
    /// </summary>
    int Value { get; }

    /// <summary>
    /// Name of the state.
    /// </summary>
    string Name { get; }
}
