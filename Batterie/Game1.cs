using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

using System;
using System.IO.Ports;
using System.Threading;

namespace Batterie
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Definie les trucs pour monogame
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<SoundEffect> soundEffects;
        bool[] state = new bool[4];
        

        //Variable pour la police text
        private SpriteFont font;
        string message1;
        //Declare port serie arduino
        static SerialPort arduino;

        public Game1()
        {
            for (int i = 0; i < 4; i++)
            {
                state[i] = true;
            }
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            soundEffects = new List<SoundEffect>();
            arduino = new SerialPort();
            arduino.BaudRate = 115200;

            arduino.DataReceived += Arduino_DataReceived;


        }
        void open_arduino(string port = "COM7")
        {
            arduino.PortName = port;
            try
            {
                arduino.Open();
                message1 = "liaison reussi";
            }
            catch
            {
                message1 = "liaison_echoue";
            }
        }
        
        protected override void Initialize()
        {
           base.Initialize();
        }
        
        protected override void LoadContent()
        {
            //Attribue la police au font le dossier content
            font = Content.Load<SpriteFont>("font");
            message1 = "non conecte";

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //On Declare tous les sons 
            soundEffects.Add(Content.Load<SoundEffect>("bass_drum"));
            soundEffects.Add(Content.Load<SoundEffect>("caisse_claire"));
            soundEffects.Add(Content.Load<SoundEffect>("closed_hithat"));
            soundEffects.Add(Content.Load<SoundEffect>("crash"));

            open_arduino();

            
        }      
        protected override void UnloadContent()
        {
            
        }

      
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && state[0])
            {
                soundEffects[0].CreateInstance().Play();
                state[0] = false;
            }
                
            else if (Keyboard.GetState().IsKeyUp(Keys.Space))
                state[0] = true;


            if (Keyboard.GetState().IsKeyDown(Keys.Z) && state[1])
            {
                soundEffects[1].CreateInstance().Play();
                state[1] = false;
            }
                
            else if (Keyboard.GetState().IsKeyUp(Keys.Z))
                state[1] = true;


            if (Keyboard.GetState().IsKeyDown(Keys.E) && state[2])
            {
                soundEffects[2].CreateInstance().Play();
                state[2] = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.E))
                state[2] = true;


            if (Keyboard.GetState().IsKeyDown(Keys.R) && state[3])
            {
                soundEffects[3].CreateInstance().Play();
                state[3] = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.R))
                state[3] = true;

            base.Update(gameTime);
            
        }

        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            message1 = arduino.ReadLine();
            var volume = Convert.ToInt16(message1);
            play(soundEffects[0], volume);
            //throw new NotImplementedException();
        }

        void play(SoundEffect son, float volume)
        {
            var instance = son.CreateInstance();
            //instance.Volume = volume / 1024;
            instance.Play();

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, message1, new Vector2(100, 100), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
