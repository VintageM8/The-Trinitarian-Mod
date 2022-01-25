using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Elf.Weapon
{
    public class BlossomedBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blossomed Bow");
            Tooltip.SetDefault("Does random stuff with your arrow");
        }

        public override void SetDefaults()
        {
            item.damage = 13;
            item.ranged = true;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.knockBack = 5;
            item.value = 231426;
            item.rare = 7;
            item.UseSound = SoundID.Item5;
            item.width = 32;
            item.height = 74;
            item.shoot = 40;
            item.useAmmo = 40;
            item.shootSpeed = 4;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return false;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(7);
            for (int i = 0; i < numberProjectiles; i++)
            {
                TrinitarianPlayer modPlayer = player.GetModPlayer<TrinitarianPlayer>();
                Vector2 trueSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                float scale = Main.rand.NextFloat(1, 2);
                trueSpeed = trueSpeed * scale;
                bool yes = true;
                float anotherSpeedVariable = trueSpeed.Length();
                int currentDmg = (int)(item.damage * player.rangedDamage);
                float currentKnockBack = item.knockBack * knockBack;
                modPlayer.PickRandomAmmo(item, ref type, ref anotherSpeedVariable, ref yes, ref currentDmg, ref currentKnockBack, Main.rand.Next(2) == 0);
                Projectile.NewProjectile(position.X + Main.rand.Next(-12, 12), position.Y + Main.rand.Next(-12, 12), trueSpeed.X, trueSpeed.Y, type, currentDmg, currentKnockBack, player.whoAmI);
            }
            return false;
        }
    }
}