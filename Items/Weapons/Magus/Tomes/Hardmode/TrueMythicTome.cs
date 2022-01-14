using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Tome;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Items.Weapons.Magus.Tomes.PreHardmode;

namespace Trinitarian.Items.Weapons.Magus.Tomes.Hardmode
{
    public class  TrueMythicTome : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Mythic Tome");
            Tooltip.SetDefault("Shoots a powerfull homing blast");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 85;
            item.width = 112;
            item.height = 40;
            item.useTime = 18;
            item.useAnimation = 18;
            item.crit = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4f;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<MythicTomeProj>();
            item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 2);
            recipe.AddIngredient(ModContent.ItemType<MythicTome>(), 1);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
