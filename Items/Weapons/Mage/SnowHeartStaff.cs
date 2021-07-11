using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Weapons.Mage
{
    public class SnowHeartStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart of the Blizzard");
            Tooltip.SetDefault("Shoots out snowballs");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 70;
            item.magic = true;
            item.mana = 18;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 23, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ProjectileID.SnowBallFriendly;
            item.shootSpeed = 18f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<TrueStarSteel>(), 10);
            recipe.AddIngredient(ItemType<CyroOrb>(), 1);
            recipe.AddIngredient(ItemID.BlizzardStaff, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}