using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameEntry.Common.Scenes;

public static class SceneText
{
    public static void DrawCentered(
        SpriteBatch spriteBatch,
        SpriteFont font,
        string text,
        Vector2 position,
        float scale,
        Color color)
    {
        var size = font.MeasureString(text);

        spriteBatch.DrawString(
            font,
            text,
            position,
            color,
            0f,
            size / 2f,
            scale,
            SpriteEffects.None,
            0f
        );
    }
}
