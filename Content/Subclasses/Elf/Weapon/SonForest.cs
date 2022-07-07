using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Elf;
using System;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class SonForest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Son of the Forest");
            Tooltip.SetDefault("Shoots blast powered by the Forest\nBlast turns into tiny braches that scratch your foe\nIf in the Forest, you get medium improvements to all stats.");
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 28;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = 35;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ElfBlast>();
            Item.shootSpeed = 10f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 5);
        }
    }
}