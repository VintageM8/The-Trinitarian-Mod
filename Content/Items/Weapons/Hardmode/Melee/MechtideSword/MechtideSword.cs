using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Microsoft.Xna.Framework;
using Trinitarian.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.MechtideSword
{
    public class MechtideSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Sword");
            Tooltip.SetDefault("Each enemy slain builds your charge. Right click to release.");
        }

        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee;
            Item.width = 84;
            Item.height = 90;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 8;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        /*public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            var modPlayer = player.GetModPlayer<TrinitarianPlayer>();

            if (target.life <= 0 && !target.SpawnedFromStatue)
            {
                modPlayer.MechtideCharge++;
                CombatText.NewText(target.getRect(), new Color(38, 126, 126), modPlayer.MechtideCharge, true, false);
            }
        }*/

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			if (Main.rand.NextBool(3)) {
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<MechtideDust>());
			}
		}

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<Mechtide>(), 50)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}