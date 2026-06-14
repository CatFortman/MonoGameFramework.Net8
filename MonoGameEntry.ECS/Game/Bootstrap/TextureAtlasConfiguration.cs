using System.Collections.Generic;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.ECS.Game.Bootstrap;

public class TextureAtlasConfiguration
{
    public Dictionary<PlayerAnimationName, TextureAtlas> PlayerAtlases { get; set; } = new();

    public TextureAtlasConfiguration(GameContext context)
    {
        var playerIdleAtlas = TextureAtlas.FromFile(context.Content, "player-idle-definition.xml");
        var playerWalkingAtlas = TextureAtlas.FromFile(context.Content, "player-walking-definition.xml");
        var playerAttackAtlas = TextureAtlas.FromFile(context.Content, "player-attack-definition.xml");
        var playerJumpAtlas = TextureAtlas.FromFile(context.Content, "player-jump-definition.xml");
        var playerInteractAtlas = TextureAtlas.FromFile(context.Content, "player-interact-definition.xml");
        var playerRunAtlas = TextureAtlas.FromFile(context.Content, "player-run-definition.xml");

        PlayerAtlases.Add(PlayerAnimationName.Idle, playerIdleAtlas);
        PlayerAtlases.Add(PlayerAnimationName.Walk, playerWalkingAtlas);
        PlayerAtlases.Add(PlayerAnimationName.Attack, playerAttackAtlas);
        PlayerAtlases.Add(PlayerAnimationName.Jump, playerJumpAtlas);
        PlayerAtlases.Add(PlayerAnimationName.Interact, playerInteractAtlas);
        PlayerAtlases.Add(PlayerAnimationName.Run, playerRunAtlas);
    }
}
