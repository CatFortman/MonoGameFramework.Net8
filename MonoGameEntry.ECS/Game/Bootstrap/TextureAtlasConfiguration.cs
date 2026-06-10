using System.Collections.Generic;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.ECS.Game.Bootstrap;

public class TextureAtlasConfiguration
{
    public Dictionary<AnimationName, TextureAtlas> PlayerAtlases { get; set; } = new();

    public TextureAtlasConfiguration(GameContext context)
    {
        var playerIdleAtlas = TextureAtlas.FromFile(context.Content, "player-idle-definition.xml");
        var playerWalkingAtlas = TextureAtlas.FromFile(context.Content, "player-walking-definition.xml");
        var playerAttackAtlas = TextureAtlas.FromFile(context.Content, "player-attack-definition.xml");
        var playerJumpAtlas = TextureAtlas.FromFile(context.Content, "player-jump-definition.xml");
        var playerInteractAtlas = TextureAtlas.FromFile(context.Content, "player-interact-definition.xml");
        var playerRunAtlas = TextureAtlas.FromFile(context.Content, "player-run-definition.xml");

        PlayerAtlases.Add(AnimationName.Idle, playerIdleAtlas);
        PlayerAtlases.Add(AnimationName.Walk, playerWalkingAtlas);
        PlayerAtlases.Add(AnimationName.Attack, playerAttackAtlas);
        PlayerAtlases.Add(AnimationName.Jump, playerJumpAtlas);
        PlayerAtlases.Add(AnimationName.Interact, playerInteractAtlas);
        PlayerAtlases.Add(AnimationName.Run, playerRunAtlas);
    }
}
