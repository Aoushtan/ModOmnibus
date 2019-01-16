using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TestMod.Items.Weapons
{
	public class BigBigGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Big Gun");
			Tooltip.SetDefault("The biggest gun.");
		}
		public override void SetDefaults()
		{
			item.damage = 50;
			item.crit = 2;
			item.noMelee = true;
			item.ranged = true;
			item.width = 42;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 10;
			item.value = 50000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NewBar"), 10);
			recipe.AddTile(mod.TileType("ModBench"));
			recipe.setResult(this);
			recipe.AddRecipe();
		}*/
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .25f;
		}
		//Bullet comes out of muzzle and can't shoot through tiles
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			//This will fire a custom bullet and a grenade at the same time.
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.  
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.GrenadeI, damage, knockBack, player.whoAmI);
			return true;
		}
	}
}