using BEPUphysics.Collidables;
using BEPUphysics.Collidables.MobileCollidables;
using BEPUphysics.Entities.Prefabs;
using BEPUphysics.MathExtensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BEPUphysics.Entities;
using BEPUphysics;
using BEPUphysics.DataStructures;
using BEPUphysics.NarrowPhaseSystems.Pairs;
using Imaginecup2013.Setup;
using Imaginecup2013.Physics;
using Imaginecup2013.Input;
using Imaginecup2013.Rendering;


namespace Imaginecup2013 
{

    public class Leoni : Microsoft.Xna.Framework.Game 
    {
        /* Constants / Basic Information */
        public const string version = "0.0.1";
        public int screenSizeWidth = 800;
        public int screenSizeHeight = 600;

        /* Global Variables */
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Space space;
        public Camera Camera;

        /* Effects */
        public Effect mainEffect;
        public Effect postEffect;

        /* Input */
        public KeyboardState KeyboardState;
        public MouseState MouseState;

        public Sphere cameraBox;

        /* Update classes */
        UpdatePhysics updatePhysics;
        UpdateInput updateInput;
        SetupGraphics setupGraphics;
        SaveScene saveScene;
        DrawGraphics drawGraphics;

        /* Render Targets and Maps*/
        public RenderTarget2D baseTarget;
        public Texture2D baseMap;


        public Leoni()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenSizeWidth;
            graphics.PreferredBackBufferHeight = screenSizeHeight;
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            //Setup render targets
            baseTarget = new RenderTarget2D(graphics.GraphicsDevice, 1024, 1024, true, graphics.GraphicsDevice.DisplayMode.Format, DepthFormat.Depth24);

            //Setup the camera.
            Camera = new Camera(this, new Vector3(0, 3, 10), 5);
            
            //New physics updater
            updatePhysics = new UpdatePhysics();

            //New Input updater
            updateInput = new UpdateInput();

            //Setup Graphics 
            setupGraphics = new SetupGraphics();
            saveScene = new SaveScene();
            drawGraphics = new DrawGraphics();

            //New World
            space = new Space();

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            //Used to draw textures
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Effects
            mainEffect = Content.Load<Effect>("Effects\\MainEffect");

            //Load and initilize the world
            InitializeWorld initWorld = new InitializeWorld(this);            
        }      

      
        protected override void UnloadContent(){}

       
        protected override void Update(GameTime gameTime)
        {
            //Handle input
            updateInput.update(this);

            //Update physics engine
            updatePhysics.update(this, gameTime);   
  
            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            //Draw basic scene
            setupGraphics.draw(this, baseTarget);
            
            //Trigger all drawing data
            base.Draw(gameTime);//Look at EntityModel and StaticModel for code

            //Save scene to map
            baseMap = saveScene.save(this, baseTarget);

            //Draw to screen
            drawGraphics.draw(this, baseMap);            
        }
    }
}
