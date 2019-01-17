using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TestMod.Tiles
{
	public class NewOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true; //Makes this item into an ore for spelunker potions and such
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 410; //This is the metal detector value
			Main.tileShine2[Type] = true; //Modifies the draw color
			Main.tileShine[Type] = 975; //how often the tiny dust appears.  Larger is less often
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("New Ore");
			AddMapEntry(new Color(152, 171, 198), name);
			dustType = 84;
			drop = mod.ItemType("NewOre");
			soundType = 21;
			soundStyle = 1;
			minPick = 50;
			mineResist = 3f;
		}
	}
}