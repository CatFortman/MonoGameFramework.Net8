"""Generates architecture.excalidraw for MonoGameFramework.Net8."""
import json
import random

random.seed(42)
elements = []


def rnd():
    return random.randint(1, 2**31 - 1)


def base(el_type, x, y, w, h, **kw):
    el = {
        "id": f"el{len(elements)}",
        "type": el_type,
        "x": x,
        "y": y,
        "width": w,
        "height": h,
        "angle": 0,
        "strokeColor": "#1e1e1e",
        "backgroundColor": "transparent",
        "fillStyle": "solid",
        "strokeWidth": 1,
        "strokeStyle": "solid",
        "roughness": 1,
        "opacity": 100,
        "groupIds": [],
        "frameId": None,
        "roundness": None,
        "seed": rnd(),
        "version": 1,
        "versionNonce": rnd(),
        "isDeleted": False,
        "boundElements": None,
        "updated": 1751932800000,
        "link": None,
        "locked": False,
    }
    el.update(kw)
    elements.append(el)
    return el


def rect(x, y, w, h, bg="transparent", stroke="#1e1e1e", dashed=False):
    return base(
        "rectangle", x, y, w, h,
        backgroundColor=bg, strokeColor=stroke,
        strokeStyle="dashed" if dashed else "solid",
        roundness={"type": 3},
    )


def text(x, y, s, size=16, color="#1e1e1e", align="left", w=None):
    lines = s.split("\n")
    height = round(size * 1.25 * len(lines))
    width = w if w else round(max(len(line) for line in lines) * size * 0.6)
    return base(
        "text", x, y, width, height,
        strokeColor=color, text=s, fontSize=size, fontFamily=1,
        textAlign=align, verticalAlign="top", baseline=size,
        containerId=None, originalText=s, lineHeight=1.25,
    )


def label(x, y, w, s, size=16, color="#1e1e1e"):
    """Centered text across width w."""
    return text(x, y, s, size=size, color=color, align="center", w=w)


def arrow(x1, y1, x2, y2, color="#1e1e1e", dashed=False):
    return base(
        "arrow", x1, y1, x2 - x1, y2 - y1,
        strokeColor=color,
        strokeStyle="dashed" if dashed else "solid",
        points=[[0, 0], [x2 - x1, y2 - y1]],
        startBinding=None, endBinding=None,
        startArrowhead=None, endArrowhead="arrow",
        lastCommittedPoint=None,
        roundness={"type": 2},
    )


# ---------------- Title ----------------
label(40, 10, 1560, "MonoGameFramework.Net8 — Architecture", size=28)
label(40, 50, 1560,
      "Two runnable game templates (OOP and ECS) over a shared engine library",
      size=16, color="#666666")

# ---------------- Entry layer containers ----------------
OOP_X, ECS_X, TOP_Y, CW, CH = 40, 820, 100, 740, 470

rect(OOP_X, TOP_Y, CW, CH, bg="#fff3d6", stroke="#e8a33d")
label(OOP_X, TOP_Y + 10, CW, "MonoGameEntry.OOP", size=20, color="#8a5a00")
label(OOP_X, TOP_Y + 38, CW, "scene-based object-oriented template",
      size=13, color="#8a5a00")

rect(ECS_X, TOP_Y, CW, CH, bg="#e0f2fe", stroke="#3d8fe8")
label(ECS_X, TOP_Y + 10, CW, "MonoGameEntry.ECS", size=20, color="#0b4f8a")
label(ECS_X, TOP_Y + 38, CW, "data-driven entity-component-system template",
      size=13, color="#0b4f8a")


def box(x, y, w, h, title, body=None, bg="#ffffff", stroke="#1e1e1e"):
    rect(x, y, w, h, bg=bg, stroke=stroke)
    label(x, y + 8, w, title, size=14)
    if body:
        label(x, y + 30, w, body, size=11, color="#555555")


# ---- OOP internals ----
box(OOP_X + 20, TOP_Y + 70, 200, 55, "Program → Game1 : Core",
    "entry point")
box(OOP_X + 260, TOP_Y + 70, 210, 55, "OopBootstrap",
    "IGameBootstrap")
box(OOP_X + 510, TOP_Y + 70, 210, 55, "SceneCompositionRoot\n+ SceneFactory")
arrow(OOP_X + 220, TOP_Y + 97, OOP_X + 258, TOP_Y + 97)
arrow(OOP_X + 470, TOP_Y + 97, OOP_X + 508, TOP_Y + 97)

box(OOP_X + 510, TOP_Y + 170, 210, 70, "GameScene : IScene",
    "manual game loop:\nupdate entities, collide, draw")
arrow(OOP_X + 615, TOP_Y + 127, OOP_X + 615, TOP_Y + 168)

box(OOP_X + 260, TOP_Y + 170, 210, 70, "GameSceneContext",
    "player, enemy, services,\ntilemap, bounds, audio")
arrow(OOP_X + 508, TOP_Y + 205, OOP_X + 472, TOP_Y + 205)

box(OOP_X + 20, TOP_Y + 280, 340, 80, "Entities",
    "Player, Enemy, PlayerInput\nAnimatedGameObject / IGameObject / ICollidable")
box(OOP_X + 380, TOP_Y + 280, 340, 80, "Services",
    "CollisionService, AudioService,\nGameInteractionService")
arrow(OOP_X + 310, TOP_Y + 242, OOP_X + 230, TOP_Y + 278)
arrow(OOP_X + 420, TOP_Y + 242, OOP_X + 520, TOP_Y + 278)

box(OOP_X + 20, TOP_Y + 385, 700, 60, "Content pipeline (.mgcb)",
    "sprite atlases (XML definitions), tilemap, fonts, SFX + music",
    bg="#fdf7ec")

# ---- ECS internals ----
box(ECS_X + 20, TOP_Y + 70, 200, 55, "Program → Game1 : Core",
    "entry point")
box(ECS_X + 260, TOP_Y + 70, 210, 55, "EcsBootstrap",
    "IGameBootstrap")
box(ECS_X + 510, TOP_Y + 70, 210, 55, "SceneCompositionRoot\n+ SceneFactory")
arrow(ECS_X + 220, TOP_Y + 97, ECS_X + 258, TOP_Y + 97)
arrow(ECS_X + 470, TOP_Y + 97, ECS_X + 508, TOP_Y + 97)

box(ECS_X + 260, TOP_Y + 170, 460, 70,
    "EcsSceneContext : ICollisionEventScene, IWorldBoundsProvider",
    "owns EntityManager + SystemManager; collision event queue")
arrow(ECS_X + 615, TOP_Y + 127, ECS_X + 615, TOP_Y + 168)

box(ECS_X + 20, TOP_Y + 280, 240, 90, "Components (data)",
    "Position, Velocity, Sprite, Bounds,\nAnimation, ActionState, Direction,\nBounce, Sounds, Player/Enemy tags")
box(ECS_X + 290, TOP_Y + 280, 430, 90, "Systems (behavior) — ordered pipeline",
    "Input → Action → Movement → WorldBounds →\nDirection → Bounce → Collision → Game(events) →\nAnimState → AnimSelect → Animation → Render")
arrow(ECS_X + 380, TOP_Y + 242, ECS_X + 200, TOP_Y + 278)
arrow(ECS_X + 540, TOP_Y + 242, ECS_X + 560, TOP_Y + 278)

box(ECS_X + 20, TOP_Y + 385, 700, 60, "Content pipeline (.mgcb)",
    "sprite atlases (XML definitions), tilemap, fonts, SFX + music",
    bg="#eef7fd")

# ---------------- Shared game content layer ----------------
COM_Y = 620
rect(40, COM_Y, 1520, 85, bg="#fdeef5", stroke="#d44a86")
label(40, COM_Y + 10, 1520, "MonoGameEntry.Common — shared game content",
      size=18, color="#8a1c52")
label(40, COM_Y + 38, 1520,
      "AnimationKey, PlayerAnimations, EnemyAnimations, ActionState, PlayerAnimationName,\n"
      "AnimationSet, PlayerAnimationFactory, TextureAtlasConfiguration  "
      "(Direction stays per-template: ECS is 8-way, OOP is 4-way)",
      size=12, color="#8a1c52")

# ---------------- Library layer ----------------
LIB_Y = 745
rect(40, LIB_Y, 1520, 300, bg="#e8f5e9", stroke="#3d9e4f")
label(40, LIB_Y + 10, 1520, "MonoGameLibrary — engine core (shared, architecture-agnostic)",
      size=20, color="#1b5e20")

box(70, LIB_Y + 55, 280, 105, "Core : Game",
    "game lifecycle; owns Graphics,\nSpriteBatch, Content, Input,\nGameContext, SceneManager",
    bg="#ffffff")
box(380, LIB_Y + 55, 250, 105, "GameContext",
    "GraphicsDevice, SpriteBatch,\nContent, Input, CurrentScene\n(passed to scenes/systems)",
    bg="#ffffff")
box(660, LIB_Y + 55, 400, 105, "Scenes",
    "SceneManager (Load/Enter/Exit/Unload)\nIScene, IEcsScene, ICollisionEventScene,\nISceneContext, ISceneFactory, SceneRegistry",
    bg="#ffffff")
box(1090, LIB_Y + 55, 400, 105, "ECS foundation",
    "EntityManager, Entity, ComponentStore<T>,\nSystemManager, IGameSystem,\nIComponent, IWorldBoundsProvider",
    bg="#ffffff")

box(70, LIB_Y + 180, 470, 95, "Graphics",
    "Sprite, AnimatedSprite, Animation,\nTextureAtlas, TextureRegion, SpriteSheetDefinition,\nTilemap, Tileset",
    bg="#ffffff")
box(570, LIB_Y + 180, 350, 95, "Input",
    "InputManager\nKeyboardInfo, MouseInfo,\nGamePadInfo",
    bg="#ffffff")
box(950, LIB_Y + 180, 250, 95, "Models",
    "Circle\n(collision primitive)",
    bg="#ffffff")
box(1230, LIB_Y + 180, 260, 95, "Bootstrap",
    "IGameBootstrap\n(entry-point seam for\ntemplates)",
    bg="#ffffff")

# entry layers -> common -> library
arrow(410, TOP_Y + CH, 410, COM_Y - 2, color="#666666")
arrow(1190, TOP_Y + CH, 1190, COM_Y - 2, color="#666666")
label(300, TOP_Y + CH + 12, 220, "references", size=12, color="#666666")
label(1080, TOP_Y + CH + 12, 220, "references", size=12, color="#666666")
arrow(800, COM_Y + 85, 800, LIB_Y - 2, color="#666666")

# ---------------- Platform layer ----------------
PLAT_Y = 1095
rect(40, PLAT_Y, 745, 70, bg="#f3e8fd", stroke="#8d5bd4")
label(40, PLAT_Y + 12, 745, "MonoGame 3.8 (DesktopGL)", size=18, color="#4a2d78")
label(40, PLAT_Y + 40, 745, "Game, GraphicsDevice, SpriteBatch, ContentManager, MediaPlayer",
      size=12, color="#4a2d78")

rect(815, PLAT_Y, 745, 70, bg="#f3e8fd", stroke="#8d5bd4")
label(815, PLAT_Y + 12, 745, ".NET 8", size=18, color="#4a2d78")
label(815, PLAT_Y + 40, 745, "runtime + SDK; StyleCop analyzers enforced on the library",
      size=12, color="#4a2d78")

arrow(800, LIB_Y + 300, 800, PLAT_Y - 2, color="#666666")

doc = {
    "type": "excalidraw",
    "version": 2,
    "source": "https://excalidraw.com",
    "elements": elements,
    "appState": {"gridSize": None, "viewBackgroundColor": "#ffffff"},
    "files": {},
}

with open("docs/architecture.excalidraw", "w", encoding="utf-8") as f:
    json.dump(doc, f, indent=2)

print(f"Wrote docs/architecture.excalidraw with {len(elements)} elements")
