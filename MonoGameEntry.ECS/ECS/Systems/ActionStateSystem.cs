using Microsoft.Xna.Framework;
using MonoGameEntry.ECS.Components;
using MonoGameEntry.Common.Enums;
using MonoGameLibrary;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.ECS.Systems;

public class ActionSystem : IGameSystem
{
    private const float AttackDuration = 0.5f;
    private const float JumpDuration = 0.9f;
    private const float InteractDuration = 0.4f;

    public void Update(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
        float dt =
            (float)gameTime.ElapsedGameTime.TotalSeconds;

        foreach (var entity in scene.Entities.Query<
            ActionStateComponent,
            ActionRequestComponent>())
        {
            ref var action =
                ref scene.Entities.GetRef<ActionStateComponent>(entity.Id);

            ref var request =
                ref scene.Entities.GetRef<ActionRequestComponent>(entity.Id);

            if (action.State == ActionState.None)
            {
                if (request.AttackRequested)
                {
                    action.State = ActionState.Attack;
                    action.RemainingTime = AttackDuration;
                }

                if (request.JumpRequested)
                {
                    action.State = ActionState.Jump;
                    action.RemainingTime = JumpDuration;
                }

                if (request.InteractRequested)
                {
                    action.State = ActionState.Interact;
                    action.RemainingTime = InteractDuration;
                }
            }
            else
            {
                action.RemainingTime -= dt;

                if (action.RemainingTime <= 0)
                {
                    action.State = ActionState.None;
                }
            }

            request.AttackRequested = false;
            request.JumpRequested = false;
            request.InteractRequested = false;
        }
    }

    public void Draw(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
    }
}