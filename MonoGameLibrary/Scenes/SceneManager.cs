namespace MonoGameLibrary.Scenes;

using Microsoft.Xna.Framework;

public class SceneManager
{
    private IScene current;
    private readonly GameContext context;

    public IScene CurrentScene => this.current;

    public SceneManager(GameContext context)
    {
        this.context = context;
    }

    public void ChangeScene(IScene scene)
    {
        this.current?.OnExit();
        this.current?.Unload();

        this.current = scene;

        this.current.Load();
        this.current.OnEnter();
    }

    public void Update(GameTime gameTime)
    {
        this.current?.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        this.current?.Draw(gameTime);
    }
}