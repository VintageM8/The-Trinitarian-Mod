using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Trinitarian.Content.Buffs.Damage;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.Localization;
using Trinitarian.Content.Buffs;

namespace Trinitarian.Common.Players
{
    public class TrinitarianBuffPlayer : ModPlayer
    {
        //Buffs
        public bool nosferatu = false;
        public bool WizardBuff = false;
        public bool holyWrath;
        public bool mirrorBuff;
        public bool NecroHeal = false;

        public override void ResetEffects()
        {
            //Buffs
            nosferatu = false;
            mirrorBuff = false;
            WizardBuff = false;
            holyWrath = false;
            NecroHeal = false;
        }

        public override void UpdateLifeRegen()
        {
            if (nosferatu)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 16; //change this number to how fast you want the debuff to damage the players. Every 2 is 1 hp lost per second
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (nosferatu)
            {
                int messageType = Main.rand.Next(4); //the number of different types of death messages you want to have
                if (messageType == 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 0
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " will could not overpower the dark.");
                }
                else if (messageType == 1 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 1
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " has lost all light in their soul.");
                }
                else if (messageType == 2 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 2 etc
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " life has deteriorated.");
                }
                else if (messageType == 3 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " is in the hands of death.");
                }
            }
            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (mirrorBuff)
            {
                damage /= 2;
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (WizardBuff)
            {
                SoundEngine.PlaySound(SoundID.Item74);
                int projectiles = 9;
                for (int i = 0; i < projectiles; i++)
                {
                    Projectile.NewProjectile(Player.GetSource_OnHurt(null), Player.Center, new Vector2(7).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<Boulder>(), 19, 2, Player.whoAmI);
                }
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (item.DamageType == DamageClass.Melee)
            {
                if (holyWrath)
                {
                    target.AddBuff(ModContent.BuffType<HolySmite>(), 600);
                }
            }
        }

        public override void OnHitAnything(float x, float y, Entity victim)
        {
            if (NecroHeal && Main.rand.Next(4) == 0)
            {
                int newLife = Main.rand.Next(2, 6);
                Player.statLife += newLife;
                Player.HealEffect(newLife);
                NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, Player.whoAmI, newLife);
            }
        }
    }
}