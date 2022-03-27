using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Subclass.Elf;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class ElfBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elf's Bow");
            Tooltip.SetDefault("Shoots an bolt that sticks in enimies, after some time it will explode\nAn Elf will give their life to protect the forest, we expect you to do the same.");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item67;
            item.crit = 4;
            item.damage = 18;
            item.ranged = true;
            item.width = 60;
            item.height = 32;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Green;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ElfBolt>();
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<ElfBolt>(), damage, knockBack, player.whoAmI);
			return false;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}