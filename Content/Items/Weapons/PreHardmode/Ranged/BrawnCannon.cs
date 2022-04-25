using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged
{
    public class BrawnCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brawn Cannon");
            Tooltip.SetDefault("Shoots out fire\nUses gel as ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.ranged = true;
            item.width = 44;
            item.height = 16;
            item.useTime = 20;
            item.useAnimation = 20;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shoot = ProjectileID.Flames;
            item.shootSpeed = 5f;
            item.useAmmo = AmmoID.Gel;
            item.scale = 1.15f;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}