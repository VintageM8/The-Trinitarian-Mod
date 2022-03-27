using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged.VikingBow;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.VikingBow
{
    public class VikingBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ulvkil Bow");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 250;
            item.useAnimation = 25;
            item.useTime = 25;
            item.width = 30;
            item.height = 60;
            item.shoot = AmmoID.Arrow;
            item.shootSpeed = 8f;
            item.knockBack = 10f;
            item.ranged = true;
            item.value = Item.sellPrice(gold: 48);
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<BowAxe>(), damage, knockBack, player.whoAmI);
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<UlvkilSoul>(), 4);
            recipe.AddIngredient(ItemType<StormEnergy>(), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}