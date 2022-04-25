using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Weapon.Mage;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic
{
    public class EarthRupture : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth's Rupture");
            Tooltip.SetDefault("Shoots a boulder");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 48;
            item.magic = true;
            item.mana = 18;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Boulder>();
            item.shootSpeed = 12f;
        }
        public override Vector2? HoldoutOrigin()
        {
            return new Vector2(15, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 200);
            recipe.AddIngredient(ItemID.StoneBlock, 130);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}