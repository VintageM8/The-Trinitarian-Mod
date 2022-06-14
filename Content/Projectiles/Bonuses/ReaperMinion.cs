using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Buffs.Bonuses;
using Trinitarian.Content.Projectiles.Bonuses;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Bonuses
{
    public class ReaperMinion : ModProjectile
    {
        private int randDelay;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Reaper");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 30;
            //projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.minion = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 2;
            Projectile.ignoreWater = true;
        }



        public override void AI()
        {

            /*if (++projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }*/

            //Making player variable "p" set as the projectile's owner
            Player player = Main.player[Projectile.owner];

            //Factors for calculations
            double deg = (double)Projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 72; //Distance away from the player

            /*Position the player projectiled on where the player is, the Sin/Cos of the angle times the /
			/distance for the desired distance away from the player minus the projectile's width   /
			/and height divided by two so the center of the projectile is at the right place.     */
            Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
            Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;

            //Increase the counter/angle in degrees by 2.5 point, you can change the rate here too, but the orbit may look choppy depending on the value
            Projectile.ai[1] += 2.5f;

            if (player.HasBuff(ModContent.BuffType<ReaperSetBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            // Starting search distance
            float distanceFromTarget = 2000f; // range of 700f
            Vector2 targetCenter = Projectile.position;
            NPC targetNPC = null;
            bool foundTarget = false;

            if (!foundTarget)
            {
                // This code is required either way, used for finding a target
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center); // distance between the npc and minion
                        bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between; // targetcenter = npc center
                        bool inRange = between < distanceFromTarget; // if the distance between npc and minion is less than 700
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                        // Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
                        // The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
                        bool closeThroughWall = between < 2000f;
                        if (((closest && inRange) || !foundTarget) && ((lineOfSight) || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            targetNPC = npc;
                            foundTarget = true;
                        }
                    }
                }
            }

            if (foundTarget)
            {
                if ((targetCenter - Projectile.Center).X > 0f)
                {
                    Projectile.spriteDirection = Projectile.direction = -1;
                }
                else if ((targetCenter - Projectile.Center).X < 0f)
                {
                    Projectile.spriteDirection = Projectile.direction = 1;
                }

                Vector2 delta = targetCenter - Projectile.Center;
                float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                if (magnitude > 0)
                {
                    delta *= 5f / magnitude;
                }
                else
                {
                    delta = new Vector2(0f, 5f);
                }

                if (Projectile.ai[0] == 1)
                {
                    randDelay = Main.rand.Next(150, 225);
                    Projectile.netUpdate = true;
                }

                bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, targetNPC.position, targetNPC.width, targetNPC.height);

               if (Projectile.ai[0] % randDelay == 0 && lineOfSight) // prevent from instantly shooting when spawned
                {
                    SoundEngine.PlaySound(SoundID.NPCHit19, Projectile.position);
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, delta * 2, ModContent.ProjectileType<ReaperProjectile>(), Projectile.damage, 0f, Projectile.owner);
                        Projectile.netUpdate = true;
                    }
                }
                Projectile.ai[0]++;
            }
        }

        public override bool? CanCutTiles()
        {
            return false;
        }
    }
}
