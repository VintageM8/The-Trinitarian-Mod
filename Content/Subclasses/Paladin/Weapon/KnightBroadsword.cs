using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Utilities;
using System;
using Trinitarian.Content.Projectiles.Subclass.Paladin;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class KnightBroadsword : ModItem
    {
        public int currentAttack = 1;
        public override string Texture => "Trinitarian/Content/Subclasses/Paladin/Weapon/KnightBroadsword";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knight's Broadsword");
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 60;
            Item.damage = 16;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 1f;
            Item.rare = ItemRarityID.Yellow;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<KnightBroadswordProj>();
            Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/SwordSwoosh");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int dir = currentAttack;
            currentAttack = -currentAttack;
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0, dir);
            return false;
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < Math.Min(10, player.GetModPlayer<HolyCombo>().combo / 3); ++i)
            {
                Projectile.NewProjectile(player.Center, new Vector2(Main.rand.NextFloat(4, 7) * player.direction, Main.rand.NextFloat(-8, -5)), ModContent.ProjectileType<HolyBomb>(), item.damage, item.knockBack, player.whoAmI);
            }
            return true;
        }
    }
}
