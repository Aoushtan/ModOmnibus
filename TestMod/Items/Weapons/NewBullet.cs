using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items.Weapons
{
	public class NewBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("New Bullet");
			Tooltip.SetDefault("This is a modded bullet.");
		}
		public override void SetDefaults()
		{
			item.damage = 15;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("NewBullet");  //The projectile it shoots
			item.shootSpeed = 17f;
			item.ammo = AmmoID.Bullet; //The ammo class the item is in
		}
		//20% chance to apply wrath to the player when they consume an ammo
		public override void OnConsumeAmmo(Player player)
		{
			if (Main.rand.NextBool(5))
			{
				player.AddBuff(BuffID.Wrath, 300);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddIngredient(mod.ItemType("NewBar"));
			recipe.AddTile(mod.TileType("ModBench"));
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}