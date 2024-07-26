using Terraria.ModLoader;

namespace FlightTimeUI.Player
{
    class FlyPlayer : ModPlayer
    {
        private float flyTime;
        private float flyTimeMax;
        public string flyTimeText;
        public override void PostUpdate()
        {
            if (Player.equippedWings != null && !Player.mount.Active)
            {
                flyTime = Player.wingTime;
                flyTimeMax = Player.wingTimeMax;
                flyTimeText = flyTime.ToString() + '\n' + "--" + '\n' + flyTimeMax;
            }
            else flyTimeText = null;
        }
    }
}