using MonoGameEntry.Common.Enums;

namespace MonoGameEntry.ECS.Components;

public struct ActionStateComponent
{
    public ActionState State { get; set; }
    public float RemainingTime { get; set; }

}