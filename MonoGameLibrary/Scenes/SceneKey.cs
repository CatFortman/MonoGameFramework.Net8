namespace MonoGameLibrary.Scenes;

/// <summary>
/// A struct that can be used as a key for identifying scenes. It can wrap any object, such as an enum value or a string.
/// </summary>
public readonly struct SceneKey
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SceneKey"/> struct with the specified value. The value can be any object that uniquely identifies a scene, such as an enum value or a string. The <see cref="ToString"/> method will return the string representation of this value, which can be used for debugging or logging purposes.
    /// </summary>
    /// <param name="value">The value to initialize the scene key with.</param>
    public SceneKey(object value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the value of the scene key. This can be any object that uniquely identifies a scene, such as an enum value or a string. The <see cref="ToString"/> method will return the string representation of this value, which can be used for debugging or logging purposes.
    /// </summary>
    public object Value { get; }

    /// <inheritdoc/>
    public override string ToString() => this.Value?.ToString();
}