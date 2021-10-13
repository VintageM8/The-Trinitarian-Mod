using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


//This class can be used to make easy homing projectiles.
//It allows you to easily change how "homing" the projectile is supposed to be by changing the DetectionRadius or the MaxTurningAngle or give other behaviour by adjusting MaxVelocity and target.
namespace Trinitarian.Projectiles
{
    public abstract class HomingProjectile : ModProjectile
    {
        //How much the projectile can turn every tick. Units in Radians (Multiples of Pi)
        protected double MaxTurningAngle;
        //The wanted target of the projectile currently only NPC are valid targets.
        protected NPC target;
        //Maximum Velocity the projectile can reach.
        protected float MaxVelocity;
        //If the projectile should Point in the direction of it's speed
        protected bool Orient;
        //How big the radius for detecting targets should be. Only neccessary if the homing method assigns a target.
        protected float DetectionRadius;

        //This method does basic homing targeting with constant speed. The target must be assigned manually.
        public void Homing()
        {
            double temp = Math.Atan2(target.Center.Y - projectile.Center.Y, target.Center.X - projectile.Center.X);
            double TurningAngle;
            //float ProjSpeed = projectile.velocity.Length();


            if (projectile.velocity != Vector2.Zero && Orient == true)
            {
                projectile.rotation = projectile.velocity.ToRotation();
            }
            TurningAngle = temp - projectile.velocity.ToRotation();
            if (TurningAngle > Math.PI)
            {
                TurningAngle = TurningAngle - 2 * Math.PI;
            }
            else if (TurningAngle < -Math.PI)
            {
                TurningAngle = TurningAngle + 2 * Math.PI;
            }
            if (TurningAngle > MaxTurningAngle)
            {
                projectile.velocity = projectile.velocity.RotatedBy(MaxTurningAngle);
            }
            else if (TurningAngle < -MaxTurningAngle) 
            {
                projectile.velocity = projectile.velocity.RotatedBy(-MaxTurningAngle);
            }
            else
            {       
                projectile.velocity = projectile.velocity.RotatedBy(TurningAngle);
            }
            if (projectile.velocity.LengthSquared() > MaxVelocity * MaxVelocity)
            {
                if (projectile.velocity != Vector2.Zero)
                {
                    projectile.velocity.Normalize();
                }
                projectile.velocity *= MaxVelocity;
            }
        }
        //Automatically assigns the target to be the closes non friendly enemy 
        public void HomingClosest()
        {
            float tempdist = projectile.DistanceSQ(Main.npc[0].Center);
            target = Main.npc[0];
            for (int i = 1; i < Main.npc.Length; i++)
            {
                if (!Main.npc[i].friendly && Main.npc[i].active && projectile.DistanceSQ(Main.npc[i].Center) < tempdist)
                {
                    tempdist = projectile.DistanceSQ(Main.npc[i].Center);
                    target = Main.npc[i];
                }
            }
            if (tempdist < DetectionRadius * DetectionRadius && !target.friendly)
            {
                Homing();
            }
            if (projectile.velocity.LengthSquared() > MaxVelocity * MaxVelocity)
            {
                if (projectile.velocity != Vector2.Zero)
                {
                    projectile.velocity.Normalize();
                }
                projectile.velocity *= MaxVelocity;
            }
        }
    }
}
