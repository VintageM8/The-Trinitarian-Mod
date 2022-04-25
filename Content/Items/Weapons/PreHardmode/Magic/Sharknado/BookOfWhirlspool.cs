using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.PreHardmode.Magic.Sharknado;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic.Sharknado
{
    public class BookOfWhirlspool : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Sharknado is a great movie :).");
            DisplayName.SetDefault("Book of Whirlspool");
        }
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 18;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item13;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Waternado>();
            Item.shootSpeed = 10f;
            Item.noMelee = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position += new Vector2(0, -18);
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<StarSteel>(), 8)
                .AddIngredient(ModContent.ItemType<OceanBar>(), 12)
                .AddIngredient(ItemID.ShadowScale, 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
