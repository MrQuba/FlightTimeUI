using Microsoft.Xna.Framework;
using System.Collections.Generic;
using FlightTimeUI.Player;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace FlightTimeUI.UI
{
    // Most of UI code comes from here: https://github.com/tModLoader/tModLoader/wiki/Advanced-guide-to-custom-UI
    class UI : UIState { }
    public class UISystem : ModSystem
    {
        internal UserInterface Interface;
        internal UI flightTimeUI;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                Interface = new UserInterface();

                flightTimeUI = new UI();
                flightTimeUI.Activate(); 
            }
        }
        private GameTime _lastUpdateUiGameTime;

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (Interface?.CurrentState != null)
            {
                Interface.Update(gameTime);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1 && Main.LocalPlayer.GetModPlayer<FlyPlayer>().flyTimeText != null)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "Flight Time UI",
                    delegate
                    {
                        string text = Main.LocalPlayer.GetModPlayer<FlyPlayer>().flyTimeText;
                        Utils.DrawBorderString(Main.spriteBatch, text, new Vector2(0, 500), Color.White);
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
        public override void Unload()
        {
            flightTimeUI = null;
        }
    }

}