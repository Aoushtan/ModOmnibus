using Terraria;
using Terraria.ModLoader;

namespace TestMod.Items
{
	public class TileItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tile Item");
			Tooltip.SetDefault("This will place a tile");
		}
		
		public override void SetDefaults()
		{
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 10;
			item.createTile = mod.TileType("ExampleTile");
			item.autoReuse = true;
		}
	}
}