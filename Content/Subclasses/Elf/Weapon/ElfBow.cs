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
            Item.UseSound = SoundID.Item67;
            Item.crit = 4;
            Item.damage = 18;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 60;
            Item.height = 32;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Green;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ElfBolt>();
            Item.shootSpeed = 15f;
            Item.useAmmo = AmmoID.Arrow;
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