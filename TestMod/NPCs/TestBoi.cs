using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestMod.NPCs
{
	[AutoloadHead]
	public class TestBoi : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "TestBoi";
			return mod.Properties.Autoload;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 46;
			npc.aiStyle = 7;
			npc.defense = 25;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 0;
			NPCID.Sets.AttackFrameCount[npc.type] = 0;
			NPCID.Sets.DangerDetectRange[npc.type] = 150;
			NPCID.Sets.AttackType[npc.type] = 3;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 10;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			animationType = NPCID.Guide;
		}
		//Spawning conditions
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			//if(NPC.downedBoss1) for example for if EoC is dead
			return true;
		}
		//Other housing conditions
		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			return true; //when a house is available he will take it
		}
		public override string TownNPCName()
		{
			string name = "";
			switch (Main.rand.Next(4))
			{
				case 0:
				name = "Austone";
				break;
				case 1:
				name = "Austonian";
				break;
				case 2:
				name = "Aoushtan";
				break;
				case 3:
				name = "Austin";
				break;
			}
			return name;
		}
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = "Buy Items";
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool openShop)
		{
			if(firstButton)
			{
				openShop = true;
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemID.IronskinPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("Soulless"));
			nextSlot++;
		}
		public override string GetChat()
		{
			string chat = "";
			switch (Main.rand.Next(4))
			{
				case 0:
				chat = "Buy some trash please.";
				break;
				case 1:
				chat = "Hello there.";
				break;
				case 2:
				chat = "IT'S OVER!  I HAVE THE HIGH GROUND!";
				break;
				case 3:
				chat = "Well?  Get on with it!";
				break;
			}
			return chat;
		}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 40;
			knockback = 2f;
		}
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 5;
			randExtraCooldown = 10;
		}
		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
		{
			scale = 1f;
			item = Main.itemTexture[mod.ItemType("Soulless")];
			itemSize = 40;
		}
		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
		{
			itemWidth = 40;
			itemHeight = 40;
		}
	}
}