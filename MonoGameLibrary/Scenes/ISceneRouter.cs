namespace MonoGameLibrary.Scenes;

/// <summary>
/// Provides scene navigation for scenes that need to trigger a transition to another scene, such as a menu starting the game or a paused game returning to the menu. Implementations resolve the scene identified by the given key and make it the active scene via the <see cref="SceneManager"/>.
/// </summary>
public interface ISceneRouter
{
    /// <summary>
    /// Transitions the game to the scene identified by the specified key. The current scene is exited and unloaded, and the new scene is created, loaded, and entered.
    /// </summary>
    /// <param name="key">The key identifying the scene to transition to.</param>
    void GoTo(SceneKey key);
}
