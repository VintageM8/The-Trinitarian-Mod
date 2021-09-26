using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Trinitarian
{
	public class TrinitarianPlayer : ModPlayer
	{
		public int TitleID;
		public bool FocusBoss;
	    public bool ShowText;

		public int ScreenShake;
        public bool canFocus = true;
        // private float amount = 0;

        //fuck me
        /* Related to non-functional boss code below
         * Vector2 screenPositionStore;
        private Vector2 focusTo;
        private float towardsLength;
        private bool holdPosition;
        private int holdCounter = 0;
        private int holdCameraLength;
        private float returnLength; */

         public bool drowning = false;
        public override void ResetEffects()
        {
            drowning = false;
        }
        public override void UpdateDead()
        {
            drowning = false;
        }
        public override void UpdateLifeRegen()
        {
            if (drowning)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 8; //change this number to how fast you want the debuff to damage the players. Every 2 is 1 hp lost per second
            }
        }

         public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
         {
            if (drowning)
            {
                int messageType = Main.rand.Next(4); //the number of different types of death messages you want to have
                if (messageType == 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 0
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " forgot to breathe.");
                }
                else if (messageType == 1 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 1
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " is sleeping with the fish.");
                }
                else if (messageType == 2 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 2 etc
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " drowned.");
                }
                else if (messageType == 3 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " is shark food.");
                }
            }
            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
         }

		public override void ModifyScreenPosition()
        {
            /* if (FocusBoss)
            {
                if (canFocus)
                {
                    if (!Main.gamePaused)
                    {
                        screenPositionStore = new Vector2(MathHelper.Lerp(player.Center.X - Main.screenWidth / 2, focusTo.X - Main.screenWidth / 2, amount), MathHelper.Lerp(player.Center.Y - Main.screenHeight / 2, focusTo.Y - Main.screenHeight / 2, amount));
                    }

                    Main.screenPosition = screenPositionStore;
                    amount += 1 / towardsLength;
                    if (amount >= 1f)
                    {
                        holdPosition = true;
                        canFocus = false;
                        amount = 0;
                    }
                }
                else
                {
                    if (holdPosition)
                    {
                        Main.screenPosition = screenPositionStore;
                        holdCounter++;

                        if (holdCounter == holdCameraLength)
                        {
                            holdCounter = 0;
                            holdPosition = false;
                        }
                    }
                    else
                    {
                        if (!Main.gamePaused)
                        {
                            screenPositionStore = new Vector2(MathHelper.SmoothStep(focusTo.X - Main.screenWidth / 2, player.Center.X - Main.screenWidth / 2, amount), MathHelper.SmoothStep(focusTo.Y - Main.screenHeight / 2, player.Center.Y - Main.screenHeight / 2, amount));
                        }
                        Main.screenPosition = screenPositionStore;

                        amount += 1 / returnLength;

                        if (amount >= 1f)
                        {
                            amount = 0;
                            FocusBoss = false;
                            canFocus = true;
                            ShowText = false;
                        }
                    }
                }
            } */

            if (!Main.gamePaused)
            {
                if (ScreenShake > 0)
                {
                    Main.screenPosition += new Vector2(Main.rand.Next(-10, 10), Main.rand.Next(-10, 10));
                    ScreenShake--;
                }
            }


        }
    }
}