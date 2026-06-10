namespace MonoGameEntry.ECS.Components;

public class ActionRequestComponent
{
    public bool AttackRequested { get; set; }

    public bool JumpRequested { get; set; }

    public bool InteractRequested { get; set; }

    public bool SprintRequested { get; set; }
}