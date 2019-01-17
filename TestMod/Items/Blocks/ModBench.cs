using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace TestMod.Items.Blocks
{
	public class ModBench : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mod Bench");
			Tooltip.SetDefault("Create mod items with this.");
		}
		
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true; //Places in the direction you are facing (like chairs)
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("ModBench"); //The tile it places
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(mod.ItemType("NewBar"), 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}