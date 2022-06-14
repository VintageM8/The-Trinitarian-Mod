using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
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
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = 5;
            Item.knockBack = 5;
            Item.value = 231426;
            Item.rare = 7;
            Item.UseSound = SoundID.Item5;
            Item.width = 32;
            Item.height = 74;
            Item.shoot = 40;
            Item.useAmmo = 40;
            Item.shootSpeed = 4;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 2 + Main.rand.Next(7);
            for (int i = 0; i < numberProjectiles; i++)
            {
                TrinitarianPlayer modPlayer = player.GetModPlayer<TrinitarianPlayer>();
                Vector2 trueSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                float scale = Main.rand.NextFloat(1, 2);
                trueSpeed = trueSpeed * scale;
                bool yes = true;
                float anotherSpeedVariable = trueSpeed.Length();
                int currentDmg = (int)(Item.damage * player.GetDamage(DamageClass.Ranged)).Multiplicative;
                float currentKnockBack = Item.knockBack * knockback;
                modPlayer.PickRandomAmmo(Item, ref type, ref anotherSpeedVariable, ref yes, ref currentDmg, ref currentKnockBack, Main.rand.Next(2) == 0);
                Projectile.NewProjectile(source, position.X + Main.rand.Next(-12, 12), position.Y + Main.rand.Next(-12, 12), trueSpeed.X, trueSpeed.Y, type, currentDmg, currentKnockBack, player.whoAmI);
            }
            return false;
        }
    }
}