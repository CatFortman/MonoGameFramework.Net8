using Microsoft.Xna.Framework.Audio;
using MonoGameLibrary.ECS.Interfaces;

namespace MonoGameEntry.ECS.Components;

public class CollectSoundComponent : IComponent
{
    public SoundEffect Sound { get; set; }
}