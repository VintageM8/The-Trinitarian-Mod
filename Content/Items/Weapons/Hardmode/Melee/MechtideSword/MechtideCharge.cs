using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Trinitarian.Common;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.MechtideSword
{
    public class MechtideCharge : ModProjectile
    {
        public enum AIState
        {
            WithoutAutoAiming,
            Expectation, // Not used
            AutoAiming
        }

        public AIState State { get => (AIState)Projectile.ai[0]; set => Projectile.ai[0] = (float)value; }
        public float InitSpeed { get => Projectile.ai[1]; set => Projectile.ai[1] = value; }
        public int Timer { get => (int)Projectile.localAI[0]; set => Projectile.localAI[0] = value; }
        public int TargetIndex { get; set; } = -1;

        public const float TimerMaxValue = 20;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Moon");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;

            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;

            Projectile.timeLeft = 60 * 15;
        }

        public override void AI()
        {
            Timer = Math.Min(++Timer, (int)TimerMaxValue);

            switch (State)
            {
                case AIState.WithoutAutoAiming:
                    {
                        Projectile.velocity.Y = Math.Min(Projectile.velocity.Y + 0.3f, 16);
                    }
                    break;
                case AIState.AutoAiming:
                    {
                        if (TargetIndex != -1)
                        {
                            var npc = Main.npc[TargetIndex];
                            if (npc == null || !npc.active)
                            {
                                TargetIndex = -1;
                                Projectile.netUpdate = true;

                            }
                        }
                        else
                        {

                            var target = NearestNPC(Projectile.Center, 16 * 25, i => i.CanBeChasedBy(Projectile, false) && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, i.position, i.width, i.height));
                            var npc = target;
                            if (npc != null)
                            {
                                TargetIndex = npc.whoAmI;
                                Projectile.netUpdate = true;
                                break;
                            }

                            Projectile.velocity *= 0.96f;
                            Projectile.timeLeft--;
                        }
                    }
                    break;
                default:
                    Projectile.Kill();
                    break;
            }

            Projectile.rotation += Math.Sign(Projectile.velocity.X) * 0.2f;
        }
        //TODO Make this a in a utils class
        private NPC NearestNPC(Vector2 center, int v, Func<NPC, bool> p)
        {
            NPC Nearest = null;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                var npc = Main.npc[i];
                if (npc.active && p(npc))
                {
                    if (Nearest == null)
                    {
                        Nearest = npc;
                    }
                    else
                    {
                        if (Vector2.Distance(center, npc.Center) < Vector2.Distance(center, Nearest.Center))
                        {
                            Nearest = npc;
                        }
                    }
                }
            }
            return Nearest;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }

            Projectile.velocity *= 0.75f;
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);

            OnHit();
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (State == AIState.AutoAiming)
            {
                Projectile.Kill();
                return;
            }

            OnHit();

            /*if (target.life <= 0 && target.lifeMax >= 50 && (Main.rand.NextBool(6) ||  NPC.CountNPCS(ModContent.NPCType<WraithSlayer_Samurai>()) < 4)
            {
                for (int i = 0; i < 20; i++)
                    Dust.NewDust(target.position, target.width, target.height, DustID.Wraith);

                Player player = Main.player[Projectile.owner];
                MethodHelper.SpawnNPC(Projectile.GetSource_FromThis(), (int)target.Center.X, (int)target.Center.Y, ModContent.NPCType<WraithSlayer_Samurai>(), ai3: player.whoAmI);
            }*/
        }

        public void OnHit()
        {
            if (State == AIState.AutoAiming) return;
            ChangeState(AIState.AutoAiming);
        }

        public void ChangeState(AIState state)
        {
            if (state == AIState.AutoAiming)
            {
                Projectile.timeLeft = 60 * 2;
            }

            State = state;
            Projectile.netUpdate = true;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(TargetIndex);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            TargetIndex = reader.ReadInt32();
        }
    }
}