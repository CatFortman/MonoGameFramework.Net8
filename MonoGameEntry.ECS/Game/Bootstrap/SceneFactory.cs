using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoGameLibrary;
using MonoGameLibrary.ECS;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Scenes;
using MonoGameEntry.ECS.Components;
using MonoGameEntry.ECS.Game.Scenes;
using MonoGameEntry.ECS.Systems;
using MonoGameEntry.ECS.Enums;
using MonoGameEntry.Common.Bootstrap;
using MonoGameEntry.Common.Enums;
using MonoGameEntry.Common.Scenes;

namespace MonoGameEntry.ECS.Game.Bootstrap;

public class SceneFactory : ISceneFactory
{
    public IScene CreateMenuScene(GameContext context, ISceneRouter router)
    {
        return new MenuScene(
            context,
            router,
            new SceneKey(SceneType.World),
            "MonoGameEntry.ECS"
        );
    }

    public IScene CreateGameScene(GameContext context, ISceneRouter router)
    {
        var entities = new EntityManager();
        var systems = new SystemManager();

        var tilemap = Tilemap.FromFile(context.Content, "tilemap-definition.xml");
        tilemap.Scale = new Vector2(4f, 4f);

        var theme = context.Content.Load<Song>("Audio/theme");

        var screenBounds = context.GraphicsDevice.PresentationParameters.Bounds;

        var worldBounds = new Rectangle(
            (int)tilemap.TileWidth,
            (int)tilemap.TileHeight,
            screenBounds.Width - (int)tilemap.TileWidth * 2,
            screenBounds.Height - (int)tilemap.TileHeight * 2
        );

        var font = context.Content.Load<SpriteFont>("Fonts/default");

        RegisterSystems(systems);

        CreatePlayer(entities, context, tilemap);
        CreateEnemy(entities, context, worldBounds);

        var pause = new ScenePause(context, router, new SceneKey(SceneType.Menu));

        return new EcsSceneContext(
            context,
            entities,
            systems,
            worldBounds,
            tilemap,
            font,
            theme,
            pause
        );
    }

    private void RegisterSystems(SystemManager systems)
    {
        systems.Add(new InputSystem());
        systems.Add(new ActionSystem());
        systems.Add(new MovementSystem());
        systems.Add(new WorldBoundsSystem());
        systems.Add(new DirectionSystem());
        systems.Add(new BounceSystem());
        systems.Add(new CollisionSystem());
        systems.Add(new GameSystem());
        systems.Add(new AnimationStateSystem());
        systems.Add(new AnimationSelectionSystem());
        systems.Add(new AnimationSystem());
        systems.Add(new RenderSystem());
    }

    private void CreatePlayer(EntityManager entities, GameContext context, Tilemap tilemap)
    {
        var player = entities.CreateEntity();

        player.Add(new DirectionComponent
        {
            State = Direction.Up
        });

        player.Add(new AnimationStateComponent
        {
            State = PlayerAnimations.IdleUp
        });

        var config = new TextureAtlasConfiguration(context);

        var animationSet = PlayerAnimationFactory.Create(config);

        player.Add(new AnimationComponent
        {
            Animations = animationSet.Animations,
            CurrentAnimation = PlayerAnimations.IdleUp
        });

        player.Add(new ActionRequestComponent());

        player.Add(new ActionStateComponent { State = ActionState.None });

        var collectSound = context.Content.Load<SoundEffect>("Audio/collect");
        player.Add(new CollectSoundComponent { Sound = collectSound });

        player.Add(new PositionComponent
        {
            Value = new Vector2(
                tilemap.Columns / 2 * tilemap.TileWidth,
                tilemap.Rows / 2 * tilemap.TileHeight
            )
        });

        player.Add(new RunComponent { Enabled = false });
        player.Add(new VelocityComponent { Value = Vector2.Zero });
        player.Add(new SpriteComponent { Sprite = animationSet.Animations[PlayerAnimations.IdleUp] });
        player.Add(new BoundsComponent { Width = animationSet.Animations[PlayerAnimations.IdleUp].Width, Height = animationSet.Animations[PlayerAnimations.IdleUp].Height });
        player.Add(new SpriteEffectsComponent { Effects = SpriteEffects.None });

        player.Add(new PlayerTag());
    }

    private void CreateEnemy(EntityManager entities, GameContext context, Rectangle worldBounds)
    {
        var atlas = TextureAtlas.FromFile(context.Content, "enemy-fly-definition.xml");

        var enemy = entities.CreateEntity();

        var enemyFlyDown = atlas.CreateAnimatedSprite("EnemyFlyDown");
        enemyFlyDown.Scale = new Vector2(4f, 4f);

        enemy.Add(new DirectionComponent
        {
            State = Direction.Down
        });

        enemy.Add(new AnimationStateComponent
        {
            State = EnemyAnimations.FlyDown
        });

        enemy.Add(new AnimationComponent
        {
            Animations = new()
            {
                [EnemyAnimations.FlyDown] = enemyFlyDown
            },
            CurrentAnimation = EnemyAnimations.FlyDown
        });

        enemy.Add(new PositionComponent
        {
            Value = new Vector2(worldBounds.Left, worldBounds.Top)
        });

        enemy.Add(new VelocityComponent
        {
            Value = RandomDirection() * 3f
        });

        var bounceSound = context.Content.Load<SoundEffect>("Audio/bounce");
        enemy.Add(new BounceSoundComponent { Sound = bounceSound });

        enemy.Add(new SpriteComponent { Sprite = enemyFlyDown });
        enemy.Add(new BoundsComponent { Width = enemyFlyDown.Width, Height = enemyFlyDown.Height });
        enemy.Add(new SpriteEffectsComponent { Effects = SpriteEffects.None });
        enemy.Add(new BounceComponent());

        enemy.Add(new EnemyTag());
    }

    private Vector2 RandomDirection()
    {
        float angle = (float)(Random.Shared.NextDouble() * Math.PI * 2);

        return new Vector2(
            MathF.Cos(angle),
            MathF.Sin(angle)
        );
    }
}
