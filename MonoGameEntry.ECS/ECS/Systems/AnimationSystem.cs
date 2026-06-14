using Microsoft.Xna.Framework;
using MonoGameLibrary;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Scenes;
using MonoGameEntry.ECS.Components;

namespace MonoGameEntry.ECS.Systems;
public class AnimationSystem : IGameSystem
{
    public void Update(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
        foreach (var entity in scene.Entities.Query<SpriteComponent>())
        {
            ref var sprite =
                ref scene.Entities.GetRef<SpriteComponent>(entity.Id);

            sprite.Sprite.Update(gameTime);
        }
    }

    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene)
    {
    }

    
}