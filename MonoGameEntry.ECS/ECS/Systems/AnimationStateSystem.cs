using Microsoft.Xna.Framework;
using MonoGameEntry.ECS.Components;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.ECS.Systems;

public class AnimationStateSystem : IGameSystem
{
    public void Update(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
        foreach (var entity in scene.Entities
            .Query<VelocityComponent, AnimationComponent, AnimationStateComponent>())
        {
            ref var velocity =
                ref scene.Entities.GetRef<VelocityComponent>(entity.Id);

            ref var state =
                ref scene.Entities.GetRef<AnimationStateComponent>(entity.Id);

            state.State =
                velocity.Value.LengthSquared() > 0
                    ? AnimationState.Walk
                    : AnimationState.Idle;
        }
    }

    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene)
    {
    }
}