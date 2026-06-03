using Microsoft.Xna.Framework;
using MonoGameLibrary;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Scenes;
using MonoGameEntry.ECS.Components;
using MonoGameEntry.ECS.Enums;

namespace MonoGameEntry.ECS.Systems;

public class AnimationSelectionSystem : IGameSystem
{
    public void Update(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
        foreach (var entity in scene.Entities.Query<
            SpriteComponent,
            AnimationComponent,
            AnimationStateComponent>())
        {
            ref var sprite =
                ref scene.Entities.GetRef<SpriteComponent>(entity.Id);

            ref var animations =
                ref scene.Entities.GetRef<AnimationComponent>(entity.Id);

            ref var animationState =
                ref scene.Entities.GetRef<AnimationStateComponent>(entity.Id);

            AnimationState desiredAnimation = animationState.State;

            if (animations.CurrentAnimation != desiredAnimation)
            {
                if (!animations.Animations.TryGetValue(desiredAnimation, out var animation))
                {
                    continue;
                }
                animations.CurrentAnimation = desiredAnimation;

                sprite.Sprite = animation;
            }
        }
    }


    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene)
    {
    }
}