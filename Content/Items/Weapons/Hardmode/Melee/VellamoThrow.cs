using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee
{
    public class VellamoThrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vellamo's Throw");
            Tooltip.SetDefault("Summons an array of ocean shards\nLegend says this was once wielded by a finnish goddess");
        }
        public override void SetDefaults()
        {
            Item.channel = true;
            Item.crit = 8;
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 36;
            Item.height = 48;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.knockBack = 12;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("VellamoThrowProjectile").Type;
            Item.shootSpeed = 2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.HallowedBar, 15)
                .AddIngredient(ModContent.ItemType<OceanBar>(), 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}