using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics;

public class TextureAtlas
{
    private Dictionary<string, TextureRegion> _regions;

    // Stores animations added to this atlas.
    private Dictionary<string, Animation> _animations;

    /// <summary>
    /// Gets or Sets the source texture represented by this texture atlas.
    /// </summary>
    public Texture2D Texture { get; set; }

    /// <summary>
    /// Creates a new texture atlas.
    /// </summary>
    public TextureAtlas()
    {
        _regions = new Dictionary<string, TextureRegion>();
        _animations = new Dictionary<string, Animation>();
    }

    /// <summary>
    /// Creates a new texture atlas instance using the given texture.
    /// </summary>
    /// <param name="texture">The source texture represented by the texture atlas.</param>
    public TextureAtlas(Texture2D texture)
    {
        Texture = texture;
        _regions = new Dictionary<string, TextureRegion>();
        _animations = new Dictionary<string, Animation>();
    }

    /// <summary>
    /// Creates a new region and adds it to this texture atlas.
    /// </summary>
    /// <param name="name">The name to give the texture region.</param>
    /// <param name="x">The top-left x-coordinate position of the region boundary relative to the top-left corner of the source texture boundary.</param>
    /// <param name="y">The top-left y-coordinate position of the region boundary relative to the top-left corner of the source texture boundary.</param>
    /// <param name="width">The width, in pixels, of the region.</param>
    /// <param name="height">The height, in pixels, of the region.</param>
    public void AddRegion(string name, int x, int y, int width, int height)
    {
        TextureRegion region = new TextureRegion(Texture, x, y, width, height);
        _regions.Add(name, region);
    }

    /// <summary>
    /// Gets the region from this texture atlas with the specified name.
    /// </summary>
    /// <param name="name">The name of the region to retrieve.</param>
    /// <returns>The TextureRegion with the specified name.</returns>
    public TextureRegion GetRegion(string name)
    {
        return _regions[name];
    }

    /// <summary>
    /// Removes the region from this texture atlas with the specified name.
    /// </summary>
    /// <param name="name">The name of the region to remove.</param>
    /// <returns></returns>
    public bool RemoveRegion(string name)
    {
        return _regions.Remove(name);
    }

    /// <summary>
    /// Removes all regions from this texture atlas.
    /// </summary>
    public void Clear()
    {
        _regions.Clear();
    }

    /// <summary>
    /// Adds the given animation to this texture atlas with the specified name.
    /// </summary>
    /// <param name="animationName">The name of the animation to add.</param>
    /// <param name="animation">The animation to add.</param>
    public void AddAnimation(string animationName, Animation animation)
    {
        _animations.Add(animationName, animation);
    }

    /// <summary>
    /// Gets the animation from this texture atlas with the specified name.
    /// </summary>
    /// <param name="animationName">The name of the animation to retrieve.</param>
    /// <returns>The animation with the specified name.</returns>
    public Animation GetAnimation(string animationName)
    {
        return _animations[animationName];
    }

    /// <summary>
    /// Removes the animation with the specified name from this texture atlas.
    /// </summary>
    /// <param name="animationName">The name of the animation to remove.</param>
    /// <returns>true if the animation is removed successfully; otherwise, false.</returns>
    public bool RemoveAnimation(string animationName)
    {
        return _animations.Remove(animationName);
    }

    /// <summary>
    /// Creates a new texture atlas based a texture atlas xml configuration file.
    /// </summary>
    /// <param name="content">The content manager used to load the texture for the atlas.</param>
    /// <param name="fileName">The path to the xml file, relative to the content root directory..</param>
    /// <returns>The texture atlas created by this method.</returns>
    public static TextureAtlas FromFile(ContentManager content, string fileName)
    {
        TextureAtlas atlas = new TextureAtlas();

        string filePath = Path.Combine(content.RootDirectory, fileName);

        using (Stream stream = TitleContainer.OpenStream(filePath))
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                XDocument doc = XDocument.Load(reader);
                XElement root = doc.Root;

                // The <Texture> element contains the content path for the Texture2D to load.
                // So we will retrieve that value then use the content manager to load the texture.
                string texturePath = root.Element("Texture").Value;
                atlas.Texture = content.Load<Texture2D>(texturePath);

                SpriteSheetDefinition sheet = null;

                var spriteSheetElement =
                    root.Element("SpriteSheet");

                if (spriteSheetElement != null)
                {
                    int frameWidth =
                        int.Parse(
                            spriteSheetElement.Attribute("frameWidth").Value);

                    int frameHeight =
                        int.Parse(
                            spriteSheetElement.Attribute("frameHeight").Value);

                    sheet = GenerateRegions(
                        atlas,
                        frameWidth,
                        frameHeight);
                }


                // The <Regions> element contains a list of <Region> elements which define the texture regions for this atlas.
                // Backwards compatibility: if the <Animations> element row attribute is not present, we will check for the presence of <Region> elements.
                var regions = root.Element("Regions")?.Elements("Region");

                if (regions != null)
                {
                    foreach (var region in regions)
                    {
                        string name = region.Attribute("name")?.Value;
                        int x = int.Parse(region.Attribute("x")?.Value ?? "0");
                        int y = int.Parse(region.Attribute("y")?.Value ?? "0");
                        int width = int.Parse(region.Attribute("width")?.Value ?? "0");
                        int height = int.Parse(region.Attribute("height")?.Value ?? "0");

                        if (!string.IsNullOrEmpty(name))
                        {
                            atlas.AddRegion(name, x, y, width, height);
                        }
                    }
                }

                var animationElements = root.Element("Animations").Elements("Animation");

                // The <Animations> element contains a list of <Animation> elements which define the animations for this atlas. 
                // Each <Animation> element must have a "name" attribute and a "row" attribute which specifies the row of the sprite sheet that contains the frames for the animation. 
                // The "frames" attribute specifies the number of frames in the animation.
                // The "delay" attribute specifies the delay between frames in milliseconds.
                foreach (var animationElement in animationElements)
                {
                    string name =
                        animationElement.Attribute("name")?.Value;

                    int row =
                        int.Parse(
                            animationElement.Attribute("row")?.Value ?? "0");

                    int frameCount =
                        int.Parse(
                            animationElement.Attribute("frames")?.Value ?? "1");

                    float delayMs =
                        float.Parse(
                            animationElement.Attribute("delay")?.Value ?? "200");

                    var frames = new List<TextureRegion>();
                    int startFrame =
                        int.Parse(
                            animationElement.Attribute("startFrame")?.Value ?? "0");

                    for (int i = 0; i < frameCount; i++)
                    {
                        frames.Add(
                            atlas.GetRegion(
                                $"cell-{row}-{startFrame + i}"));
                    }

                    var animation = new Animation(
                        frames,
                        TimeSpan.FromMilliseconds(delayMs));

                    atlas.AddAnimation(name, animation);
                }

                return atlas;
            }
        }
    }

    /// <summary>
    /// Creates a new sprite using the region from this texture atlas with the specified name.
    /// </summary>
    /// <param name="regionName">The name of the region to create the sprite with.</param>
    /// <returns>A new Sprite using the texture region with the specified name.</returns>
    public Sprite CreateSprite(string regionName)
    {
        TextureRegion region = GetRegion(regionName);
        return new Sprite(region);
    }

    /// <summary>
    /// Creates a new animated sprite using the animation from this texture atlas with the specified name.
    /// </summary>
    /// <param name="animationName">The name of the animation to use.</param>
    /// <returns>A new AnimatedSprite using the animation with the specified name.</returns>
    public AnimatedSprite CreateAnimatedSprite(string animationName)
    {
        Animation animation = GetAnimation(animationName);
        return new AnimatedSprite(animation);
    }

    /// <summary>
    /// Generates texture regions for a sprite sheet and adds them to the given texture atlas.  
    /// The regions are named in the format "cell-{row}-{col}".
    /// </summary>
    /// <param name="atlas"></param>
    /// <param name="frameWidth"></param>
    /// <param name="frameHeight"></param>
    private static SpriteSheetDefinition GenerateRegions(
    TextureAtlas atlas,
    int frameWidth,
    int frameHeight)
    {
        int columns =
            atlas.Texture.Width / frameWidth;

        int rows =
            atlas.Texture.Height / frameHeight;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                atlas.AddRegion(
                    $"cell-{row}-{col}",
                    col * frameWidth,
                    row * frameHeight,
                    frameWidth,
                    frameHeight);
            }
        }

        return new SpriteSheetDefinition
        {
            FrameWidth = frameWidth,
            FrameHeight = frameHeight,
            Columns = columns,
            Rows = rows
        };
    }

}
