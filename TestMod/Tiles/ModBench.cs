using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ObjectData;

namespace TestMod.Tiles
{
	public class ModBench : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true; //Player can stand on it or whatever
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true; //Counts as table for NPC move in
			Main.tileLavaDeath[Type] = true; //dies in lava
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1); //How large the tile is
			TileObjectData.newTile.CoordinateHeights = new[] { 18 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable); //counts as table
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Mod Bench"); //Translatable name for map
			AddMapEntry(new Color(200, 200, 200), name); //how it looks on map
			dustType = mod.DustType("Sparkle"); //custom dust type
			disableSmartCursor = true; //thanks
			adjTiles = new int[] { TileID.WorkBenches };
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		//If you break the item under the table, it will break and create the item for the bench
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("ModBench"));
		}
	}
}