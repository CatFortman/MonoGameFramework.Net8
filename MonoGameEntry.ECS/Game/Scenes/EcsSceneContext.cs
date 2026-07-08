using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoGameLibrary;
using MonoGameLibrary.ECS;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.ECS.Interfaces;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.ECS.Game.Scenes;

public class EcsSceneContext : ICollisionEventScene, IWorldBoundsProvider
{
    public GameContext Game { get; init; }

    private readonly EntityManager _entities;
    private readonly SystemManager _systems;

    private readonly Rectangle _worldBounds;
    private readonly Tilemap _tilemap;
    private readonly SpriteFont _font;
    private Song _theme;


    public EntityManager Entities => _entities;

    public Rectangle WorldBounds => _worldBounds;
    public Tilemap Tilemap => _tilemap;
    public SpriteFont Font => _font;


    private readonly List<(Entity A, Entity B)> _collisionEvents = new();
    public List<(Entity A, Entity B)> CollisionEvents => _collisionEvents;

    public EcsSceneContext(
        GameContext game,
        EntityManager entities,
        SystemManager systems,
        Rectangle worldBounds,
        Tilemap tilemap,
        SpriteFont font,
        Song theme
       )
    {
        Game = game;
        _entities = entities;
        _systems = systems;
        _worldBounds = worldBounds;
        _tilemap = tilemap;
        _font = font;
        _theme = theme;
    }

    public void Load() { }

    public void Update(GameTime gameTime)
    {
        _collisionEvents.Clear();
        _systems.Update(Game, gameTime, this);
    }

    public void Draw(GameTime gameTime)
    {
        Game.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _tilemap.Draw(Game.SpriteBatch);

        _systems.Draw(Game, gameTime, this);

        Game.SpriteBatch.End();
    }

    public void OnEnter()
    {
        if (MediaPlayer.State == MediaState.Paused)
        {
            MediaPlayer.Resume();
        }
        else
        {
            MediaPlayer.Play(_theme);
            MediaPlayer.IsRepeating = true;
        }
    }
    public void OnExit()
    {
        if (MediaPlayer.State == MediaState.Playing)
            MediaPlayer.Pause();
    }
    public void Unload() { }
}