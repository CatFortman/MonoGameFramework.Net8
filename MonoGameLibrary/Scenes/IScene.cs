using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Scenes;

public interface IScene
{
    void Load();

    void Unload();

    void OnEnter();

    void OnExit();

    void Update(GameTime gameTime);

    void Draw(GameTime gameTime);
}