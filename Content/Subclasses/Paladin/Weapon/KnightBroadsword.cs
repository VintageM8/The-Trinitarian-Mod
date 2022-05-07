using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
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
            //Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/SwordSwoosh");
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int dir = currentAttack;
            currentAttack = -currentAttack;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0, dir);
            return false;
        }
    }
}
