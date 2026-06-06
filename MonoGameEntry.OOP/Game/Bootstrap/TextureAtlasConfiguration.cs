using System.Collections.Generic;
using MonoGameEntry.OOP.Enums;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.OOP.Game.Bootstrap;

public class TextureAtlasConfiguration
{
    public Dictionary<ActionState, TextureAtlas> PlayerAtlases { get; set; } = new();

    public TextureAtlasConfiguration(GameContext context)
    {
        var playerIdleAtlas = TextureAtlas.FromFile(context.Content, "player-idle-definition.xml");
        var playerWalkingAtlas = TextureAtlas.FromFile(context.Content, "player-walking-definition.xml");
        var playerAttackAtlas = TextureAtlas.FromFile(context.Content, "player-attack-definition.xml");
        PlayerAtlases.Add(ActionState.Idle, playerIdleAtlas);
        PlayerAtlases.Add(ActionState.Walking, playerWalkingAtlas);
        PlayerAtlases.Add(ActionState.Attack, playerAttackAtlas);
    }
}
