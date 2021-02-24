using Terraria.ModLoader;
using Terraria;
using ReLogic.Graphics;
using System;

namespace RandomFontMod
{
	public class RandomFontMod : Mod
	{
        private DynamicSpriteFont[] combatBackup;
        private DynamicSpriteFont deathBackup;
        private DynamicSpriteFont itemBackup;
        private DynamicSpriteFont mouseBackup;

        public override void Load()
        {
            if (Main.dedServ)
            {
                return;
            }

            LoadFonts();

        }

        

        public override void Unload()
        {
            if (Main.dedServ)
            {
                return;
            }


            UnloadFonts();
        }

        private void LoadFonts()
        {
            combatBackup = Main.fontCombatText;
            deathBackup = Main.fontDeathText;
            itemBackup = Main.fontItemStack;
            mouseBackup = Main.fontMouseText;

            Main.fontItemStack = GetFont("Fonts/StackFont");
            Main.fontMouseText = GetFont("Fonts/MouseFont");
            Main.fontDeathText = GetFont("Fonts/ExampleFont");
            Main.fontCombatText = new[] 
            {
                GetFont("Fonts/DamageFont"),
                GetFont("Fonts/CritFont")
            };

        }


        private void UnloadFonts()
        {
            Main.fontCombatText = combatBackup;
            Main.fontDeathText = deathBackup;
            Main.fontItemStack = itemBackup;
            Main.fontMouseText = mouseBackup;

            combatBackup = null;
            deathBackup = null;
            itemBackup = null;
            mouseBackup = null;

        }
    }
}