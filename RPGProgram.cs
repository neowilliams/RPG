using Microsoft.VisualBasic.FileIO;
using RPG;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RPG
{
    
    class PartyMember
    {
        public string name;
        public int health;
        public int cur_health;
        public float attack;
        public int defense;
        public int magic;
        public int cur_magic;
        public string status = "   fine";
        public bool action = false;
        public string attackText;
        public string critText;

        Random rng;
        public string BasicAttack(Enemy enemy)
        {
            rng = new Random();
            //int ran = rng.Next(90, 111);
            //float myBounds = ran / 100;
            float myBounds = 1;
            int crit = 1;
            if (rng.Next(1, 21) == 20)
            {
                crit = 2;
            }
            float multiplier = attack / enemy.defense;
            float healthchange = myBounds * attack * crit * multiplier;
            healthchange = Convert.ToInt32(healthchange);
            enemy.cur_health -= Convert.ToInt32(healthchange);
            if (crit == 1)
            {
                return name + attackText + enemy.name + ". " + enemy.name + " took " + healthchange + " points of damage!";
            }
            else
            {
                return name + attackText + enemy.name + ". " + enemy.name + " took " + healthchange + " points of damage! " + name + critText;
            }
        }
    }


    class Enemy
    {
        public string name;
        public int health;
        public int cur_health;
        public int attack;
        public int defense;
        public int magic = 0;
        public int cur_magic;
        public string window;
        public string attackText;
        public string critText;
        public string BasicAttack(PartyMember hero)
        {
            Random rng = new Random();
            float bounds = rng.Next(90, 111);
            int crit = 1;
            if (rng.Next(1, 21) == 20)
            {
                crit = 2;
            }
            float healthchange = bounds * attack * crit * (attack / hero.defense) / 100;
            healthchange = Convert.ToInt32(healthchange);
            hero.cur_health -= Convert.ToInt32(healthchange);
            if (crit == 1)
            {
                return name + attackText + hero.name + ". " + hero.name + " took " + healthchange + " points of damage!";
            }
            else
            {
                return name + attackText + hero.name + ". " + hero.name + " took " + healthchange + " points of damage! " + name + critText;
            }
        }
    }

    internal class RPG_temp
    {
        static void Main(string[] args)
        {

            PartyMember Knight = new PartyMember();
            Knight.name = "KNIGHT";
            Knight.health = 100;
            Knight.cur_health = Knight.health;
            Knight.attack = 35;
            Knight.defense = 50;
            Knight.magic = 13;
            Knight.cur_magic = Knight.magic;
            Knight.attackText = " swung his sword and heroicly slashed at ";
            Knight.critText = " is chuffed to see that he has Critical Hit!";

            PartyMember Mage = new PartyMember();
            Mage.name = "MAGE";
            Mage.health = 70;
            Mage.cur_health = Mage.health;
            Mage.attack = 30;
            Mage.defense = 50;
            Mage.magic = 100;
            Mage.cur_magic = Mage.magic;
            Mage.attackText = " sent a small magic pulse toward ";
            Mage.critText = " cheers proudly because she managed to Critical Hit!";

            PartyMember Bard = new PartyMember();
            Bard.name = "BARD";
            Bard.health = 100;
            Bard.cur_health = Bard.health;
            Bard.attack = 40;
            Bard.defense = 100;
            Bard.magic = 100;
            Bard.cur_magic = Bard.magic;
            Bard.attackText = " fired his crossbow at ";
            Bard.critText = " smoulders smugly at his Critical Hit!";

            PartyMember[] partyArray = [Knight, Mage, Bard];
            PartyMember[] currentParty = [Knight, Mage];

            Enemy Dummy = new Enemy();
            Dummy.name = "TRAINING DUMMY";
            Dummy.health = 70;
            Dummy.cur_health = Dummy.health;
            Dummy.attack = 35;
            Dummy.defense = 50;
            Dummy.attackText = " swung his wooden fist and weakly punched ";
            Dummy.critText = " somehow managed to crit?";
            Dummy.window =
@" _------------------------------------------------------------_
/                        TRAINING DUMMY                        \
|                                __                            |
|                              /   `\                          |
|                             | X  X |                         |
|                              \====/                          |
|                   ,=-,    _ _---==-_                         |
|                   \_ /7  / / ,-  |\;\=--_                    |
|                     ` \ / | ( o )   ;|`--_--__               |
|                      \ \ /\  `-    ;/     `--_/              |
|                       \_/  ;===_-=_-                         |
|                           '/\MAM|\                           |
|                             /'/A`                            |
|                            / /                               |
|                           / /                                |
|                       v WV VvW v                             |
|______________________________________________________________|";


            Enemy RoyalUnderling = new Enemy();
            RoyalUnderling.name = "ROYAL UNDERLING";
            RoyalUnderling.health = 120;
            RoyalUnderling.cur_health = RoyalUnderling.health;
            RoyalUnderling.attack = 30;
            RoyalUnderling.defense = 30;
            RoyalUnderling.magic = 0;
            RoyalUnderling.window =
@" _------------------------------------------------------------_
/                        ROYAL UNDERLING                       \
|                            _~~~,                             |
|                            d 6 p                             |
|                            \^ /                              |
|                         _=%###X##=_                          |
|                        %@@@@###@@@@|                         |
|                       |@| |@@@@@||@|                         |
|                       |@\ |@@@@@| o@|                        |
|                        m' /H[]HH\  7;>                       |
|                          //  /\ |\ <\\                       |
|                         |_| | _| |\  \\                      |
|                            |-| |_|`   \\                     |
|                            | | | |     \|                    |
|                           (_/  ( \      `                    |
|                                 \_)                          |
|______________________________________________________________|";

            Enemy Squij = new Enemy();
            Squij.name = "SQUIJ";
            Squij.health = 600;
            Squij.attack = 50;
            Squij.defense = 50;
            Squij.magic = 0;
            Squij.window =
@" _------------------------------------------------------------_
/                        SQUIJ SQUADRON                        \
|                                                              |
|                                                              |
|                            _.-==¬-._                         |
|                          ;'      [] \                        |
|                         /  O     c   )                       |
|                        (  _--o==--__  |                      |
|                         \(__________)/                       |
|        _.-==¬-._                                             |
|      ;'      [] \                            _.-==¬-._       |
|     /  O     c   )                         ;'      [] \      |
|    (  _--o==--__  |                       /  O     c   )     |
|     \(__________)/                       (  _--o==--__  |    |
|                                           \(__________)/     |
|                                                              |
|______________________________________________________________|";

            Enemy FDBeast = new Enemy();
            FDBeast.name = "FOUL DRAGONIAN BEAST";
            FDBeast.health = 600;
            FDBeast.cur_health = FDBeast.health;
            FDBeast.attack = 300;
            FDBeast.defense = 300;
            FDBeast.magic = 0;
            FDBeast.cur_magic = FDBeast.magic;
            FDBeast.window =
@" _------------------------------------------------------------_
/                     FOUL DRAGONIAN BEAST                     \
|                  ______                                      |
|                 /   <0> `-_                                  |
|                |oO      )  ^~A_A                             |
|             Y   w^vWV^w7    ^  ^` ^  A                       |
|              \_J   ` -~_       C=7|\) `A~A__                 |
|                          -~_     vvv    ^  A`7               |
|                            \ |       \      /                |
|                           / /  @ @    |  _-'                 |
|                          /@ |  @o     |-'                    |
|                          | o \ o @   /                       |
|                         _]  / \ @   /                        |
|                        <=  |   }   /                         |
|                         <_/  <{    |                         |
|                               <=<_/                          |
|______________________________________________________________|";

            Random rng = new Random();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string[] WelcomeScreen = [
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                  ~ The RIGHTEOUS And BRAVE ~                 |
|             ____   _    _  ______   _____  _______           |
|            / __ \ | |  | ||  ____| / ____||__   __|          |
|           | |  | || |  | || |__   | (___     | |             |
|           | |  | || |  | ||  __|   \___ \    | |             |
|           | |__| || |__| || |____  ____) |   | |             |
|            \___\_\ \____/ |______||_____/    |_|             |
|                                                              |
|            --=--=--=--=--=-- FOR --=--=--=--=--=--           |
|           _____ ____  ____ _____ ____   ___  __  __          |
|          |  ___|  _ \| ___| ____|  _ \ / _ \|  \/  |         |
|          | |_  | |_) |  _||  _| | | | | | | | |\/| |         |
|          |  _| |  _ <| |__| |___| |_| | |_| | |  | |         |
|          |_|   |_| \_\____|_____|____/ \___/|_|  |_|         |
|                                                              |
|                                                              |
|                          o Play      <                       |
|                                                              |
|                          o Credits                           |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                  ~ The RIGHTEOUS And BRAVE ~                 |
|             ____   _    _  ______   _____  _______           |
|            / __ \ | |  | ||  ____| / ____||__   __|          |
|           | |  | || |  | || |__   | (___     | |             |
|           | |  | || |  | ||  __|   \___ \    | |             |
|           | |__| || |__| || |____  ____) |   | |             |
|            \___\_\ \____/ |______||_____/    |_|             |
|                                                              |
|            --=--=--=--=--=-- FOR --=--=--=--=--=--           |
|           _____ ____  ____ _____ ____   ___  __  __          |
|          |  ___|  _ \| ___| ____|  _ \ / _ \|  \/  |         |
|          | |_  | |_) |  _||  _| | | | | | | | |\/| |         |
|          |  _| |  _ <| |__| |___| |_| | |_| | |  | |         |
|          |_|   |_| \_\____|_____|____/ \___/|_|  |_|         |
|                                                              |
|                                                              |
|                          o Play                              |
|                                                              |
|                          o Credits   <                       |
\                                                              /
 '------------------------------------------------------------' "];

            string[] introSeq = [
@" _------------------------------------------------------------_ 
/     ___                                                      \
|    / _ \                                                     |
|   | | | |                                                    |
|   | |_| |                                                    |
|    \___/  NCE  apon a time, there was a great kingdom,       |
|                                                              |
|      ruled over by a benevolent queen. Her subjects were     |
|                                                              |
|      happy, content with their monarchy, and they lived      |
|                                                              |
|      out their lives in peace. It was a great time.          |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/     ___                                                      \
|    / _ \                                                     |
|   | | | |                                                    |
|   | |_| |                                                    |
|    \___/  NCE  apon a time, there was a great kingdom,       |
|                                                              |
|      ruled over by a benevolent queen. Her subjects were     |
|                                                              |
|      happy, content with their monarchy, and they lived      |
|                                                              |
|      out their lives in peace. It was a great time.          |
|                                                              |
|                                                              |
|      Then, one day, a revered warrior attacked the           |
|                                                              |
|      kingdom with his army. They stormed the castle and      |
|                                                              |
|      mercilessly killed the gentle and beloved queen.        |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|      The cruel warrior took the throne for himself,          |
|                                                              |
|      unrightfully claiming the position as his own. He       |
|                                                              |
|      began to turn the kingdom into a capital of war,        |
|                                                              |
|      training an unyeilding army. He changed the laws of     |
|                                                              |
|      the kingdom to fit his mad mindset.                     |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|      He outlawed unregistered combat training, for he        |
|                                                              |
|      feared being overthrown.                                |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|      He outlawed unregistered combat training, for he        |
|                                                              |
|      feared being overthrown.                                |
|                                                              |
|                                                              |
|      He outlawed the study of magic, for he did not          |
|                                                              |
|      understand it.                                          |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|      He outlawed unregistered combat training, for he        |
|                                                              |
|      feared being overthrown.                                |
|                                                              |
|                                                              |
|      He outlawed the study of magic, for he did not          |
|                                                              |
|      understand it.                                          |
|                                                              |
|                                                              |
|      He outlawed the playing of music, for he was a          |
|                                                              |
|      monster.                                                |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|      Years went by, decades passed in this new, hopeless     |
|                                                              |
|      reign. Generations began, growing up only to know       |
|                                                              |
|      this tyrant's rule. Oppressed from birth, their         |
|                                                              |
|      lives were miserable.                                   |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|      Years went by, decades passed in this new, hopeless     |
|                                                              |
|      reign. Generations began, growing up only to know       |
|                                                              |
|      this tyrant's rule. Oppressed from birth, their         |
|                                                              |
|      lives were miserable.                                   |
|                                                              |
|                                                              |
|      The tyrant king is growing older now, but his           |
|                                                              |
|      dominion is just as harsh as when he first began.       |
|                                                              |
|      However, a young boy and his plans may soon change      |
|                                                              |
|      that...                                                 |
|                                                              |
|                                                              |
|   Press space to continue                  Press s to skip   |
\                                                              /
 '------------------------------------------------------------' ",];


            string[] areaIntro = [
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                         -  Fersham  -                        |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                         -  Fersham  -                        |
|                                                              |
|                    The village of the poor                   |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                         -  Fersham  -                        |
|                                                              |
|                    The village of the poor                   |
|                                                              |
|                    )                                         |
|                   (                                          |
|                     )                  o 8% 8Bo              |
|                     i_,              8B 8%8B 88 o            |
|                     | |             o %8 B 8%B %B            |
|                   _-+-+-==--=--_    %8B B \B 8% %            |
|                 _-              -_  8 %B | / | \B            |
|                /    _____--_ __   \  B- |\ \/ |/             |
|               /_--'/          \ `-_\    \ |- /               |
|                 |/  _,-    f-¬  \|       /- /                |
|                 |   HH|    |.|   |       () \                |
|            _Wv_w| _/¬=- __ L_|\ /|_wWv__/ _o |wV_            |
|                                                              |
|                                                              |
|                                                              |
\                                                              /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                         -  Fersham  -                        |
|                                                              |
|                    The village of the poor                   |
|                                                              |
|                    )                                         |
|                   (                                          |
|                     )                  o 8% 8Bo              |
|                     i_,              8B 8%8B 88 o            |
|                     | |             o %8 B 8%B %B            |
|                   _-+-+-==--=--_    %8B B \B 8% %            |
|                 _-              -_  8 %B | / | \B            |
|                /    _____--_ __   \  B- |\ \/ |/             |
|               /_--'/          \ `-_\    \ |- /               |
|                 |/  _,-    f-¬  \|       /- /                |
|                 |   HH|    |.|   |       () \                |
|            _Wv_w| _/¬=- __ L_|\ /|_wWv__/ _o |wV_            |
|                                                              |
|                                                              |
|                    Press enter to continue                   |
\                                                              /
 '------------------------------------------------------------' "];

            string artspace =

@" _------------------------------------------------------------_
/                        SQUIJ SQUADRON                        \
|                                                              |
|                                                              |
|                            _.-==¬-._                         |
|                          ;'      [] \                        |
|                         /  O     c   )                       |
|                        (  _--o==--__  |                      |
|                         \(__________)/                       |
|        _.-==¬-._                                             |
|      ;'      [] \                            _.-==¬-._       |
|     /  O     c   )                         ;'      [] \      |
|    (  _--o==--__  |                       /  O     c   )     |
|     \(__________)/                       (  _--o==--__  |    |
|                                           \(__________)/     |
|                                                              |
|______________________________________________________________|
|       knight       |        mage        |        bard        |
|       _----_       |  HP............73  |  HP............47  |
|     ,'      ',     |  MP............96  |  MP............12  |
|   8 | ()  () | 8   |  CS........burned  |  CS..........fine  |
|    \ '| db |' /    |      Has taken     |    Has not taken   |
\   8 = \BBBB/ = 8   |     their turn     |   their turn yet   /
 '------------------------------------------------------------' ";

            string TextToConvert = ("Who will KNIGHT go and find firs");
            int ResolutionWidth = (62);
            float RemainingWidth = ResolutionWidth - TextToConvert.Length;
            float OtherSide = RemainingWidth;
            for (int i = 0; i < (RemainingWidth / 2); i++)
            {
                Console.Write(" ");
                OtherSide--;
            }
            Console.Write(TextToConvert);
            for (int i = 0; i < (OtherSide); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("#");

            //welcome screen menu
            int menuSelect = 1;
            Console.Clear();
            Console.WriteLine(WelcomeScreen[menuSelect]);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key.ToString() == "DownArrow")
                    {
                        menuSelect += 1;
                        if (menuSelect >= 3)
                        {
                            menuSelect = 1;
                        }
                    }
                    else if (keyInfo.Key.ToString() == "UpArrow")
                    {
                        menuSelect -= 1;
                        if (menuSelect <= 0)
                        {
                            menuSelect = 2;
                        }
                    }
                    else if (keyInfo.Key.ToString() == "Spacebar")
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(WelcomeScreen[menuSelect]);
                }
            }

            if (menuSelect == 2)
            {
                //credits screen
            }


            //game start
            //intro sequence
            for (int i = 0; i < introSeq.Length; i++)
            {
                Console.Clear();
                Console.WriteLine(introSeq[i]);
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                        if (keyInfo.Key.ToString() == "Spacebar")
                        {
                            break;
                        }
                        else if (keyInfo.Key.ToString() == "S")  //skips intro
                        {
                            i = introSeq.Length;
                            break;
                        }
                    }
                }
            }
            // area intro
            for (int i = 0; i < areaIntro.Length; i++)
            {
                Console.Clear();
                Console.WriteLine(areaIntro[i]);
                Thread.Sleep(1000);
            }
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key.ToString() == "Enter")
                    {
                        break;
                    }
                }
            }
            storyWindow(0, "A boy sits on a tree stump in the woods. He is a young fighter, a KNIGHT, if you will. He sharpens his sword, ready for training.", 0);
            storyWindow(0, "His name is... Um... Oh, what was his name again? I can't remember. You'll have to give me a name.", 2);
            do
            {
                Knight.name = textInfo.ToUpper(Console.ReadLine().Trim());
                if (Knight.name.Length <= 14 && Knight.name.Length >= 1)
                {
                    storyWindow(0, $"{Knight.name}? Hmm... Yes, that's what it was! His name is {Knight.name}.", 0);
                    break;
                }
                else if (Knight.name.Equals(""))
                {
                    Knight.name = "KNIGHT";
                    storyWindow(0, "Oh. You didn't tell me a name. I guess we'll just have to call him KNIGHT.", 0);
                    break;
                }
                else
                {
                    storyWindow(0, "No, no, no. That definitely wasn't it. If I recall correctly, his name is less than 15 letters. Try again.", 2);
                }
            }
            while (true);
            storyWindow(0, $"{Knight.name} is secretly out here in the woods to hone his swordfighting skills. You see, {Knight.name} has a plan. He has always hated the Tyrant King and wants to take him down.", 0);
            storyWindow(0, "His plan? A daring, heroic (and foolish) journey to the King's castle to slay him and put an end to his tyranny.", 0);
            storyWindow(0, $"{Knight.name} must be ready for combat before departing. He goes to attack a training dummy, his usual 'sparring partner'. It has been enchanted to attack back to better mimic real fights.", 0);

            Console.Clear();
            Console.WriteLine(Dummy.window);
            outputTextBox("Welcome to combat.", 1);


            if (doCombat(Dummy, partyArray, currentParty))
            {

            }


            storyWindow(1, $"Okay, {Knight.name} is ready. But he can't pull off his plan on his own. He needs to go recruit his friends to help him. ", 0);

            int choice1 = 1;
            choice1 = storyChoice($"Who will {Knight.name} go and see first?", "MAGE", "BARD");

            if (choice1 == 1)
            {
                storyWindow(2, $"{Knight.name} will go and see MAGE first.", 0);
                storyWindow(3, $"{Knight.name} leaves the woods with his sword in hand, heading to the village library. This is where he suspects he will find a girl by the name of...", 0);
                storyWindow(3, "I've forgotten her name also. You'll have to help me out here again.", 2);
                do
                {
                    Mage.name = textInfo.ToUpper(Console.ReadLine().Trim());
                    if (Mage.name.Length <= 14 && Mage.name.Length >= 1)
                    {
                        storyWindow(0, $"{Mage.name}? Hmm... Yes, that's what it was! Her name is {Mage.name}.", 0);
                        break;
                    }
                    else if (Mage.name.Equals(""))
                    {
                        Mage.name = "MAGE";
                        storyWindow(0, "Oh. You didn't tell me a name. I guess we'll just have to call her MAGE.", 0);
                        break;
                    }
                    else
                    {
                        storyWindow(0, "No, no, no. That definitely wasn't it. If I recall correctly, her name is less than 15 letters. Try again.", 2);
                    }
                }
                while (true);
                storyWindow(3, $"{Knight.name} walks into the library. It is a grand, old building that seems to be falling into disrepair a little. Old books lay scattered in piles, and in cobwebs gather in the gloomy nooks.", 0);
                storyWindow(3, $"From near the entrance, {Knight.name} hears a commotion. The sounds are coming from the aisles of the bookshelves. {Knight.name} slowly peers round to investigate.", 0);
                storyWindow(3, $"{Mage.name}, a girl similar in age to {Knight.name}, is holding a book close. Two armed guards stand policing her, trying to pry the book out of her hands as best they can without injuring her.", 0);
                storyDialogue("Just give us the book!", RoyalUnderling.name, 3);
                storyDialogue("No! It's mine! Please, I need it.", Mage.name, 2);
                storyWindow(3, $"{Knight.name} decides he should do something! He turns the corner to walk towards the guards.", 0);

                int choice2 = 1;
                choice2 = storyChoice($" How should {Knight.name} help {Mage.name}? ", "Approach slowly and talk to the guards", "Run in an attack the guards with his sword");

                if (choice2 == 1)
                {
                    storyDialogue("What's going on over here?", Knight.name, 0);
                    storyDialogue($"{Knight.name}, they're trying to take this book away from me! I don't know why!", Mage.name, 1);
                    storyDialogue("Don't play dumb with us! We know that that book is for learning magic, which is illegal as declared by our King.", RoyalUnderling.name, 3);
                    storyDialogue("We're going to confiscate it and arrest you.", RoyalUnderling.name, 3);
                    storyDialogue("Is there anyway that could be avoided?", Knight.name, 0);
                    storyDialogue("Are you fighting back at us? Defending your friend here? You're going to regret that.", RoyalUnderling.name, 3);
                }
                else if (choice2 == 2)
                {
                    storyWindow(3, $"{Knight.name} runs in, drawing his sword and slashing at the nearest guard. Shocked, the guard looks back at {Knight.name} and unsheathes his sword, ready to fight.", 0);
                    RoyalUnderling.cur_health -= 20;
                    storyDialogue("You're going to regret that.", RoyalUnderling.name, 3);
                }

                storyWindow(3, $"The other guard tries to arrest {Mage.name}.", 0);
                storyDialogue($"Go on {Knight.name}! You can win this!", Mage.name + " (while struggling)", 1);
                combatWindow(RoyalUnderling);
                outputTextBox("Royal Underling:                                        You are nothing but an inpertinent urchin.", 1);


                doCombat(RoyalUnderling, partyArray, currentParty);


                storyWindow(3, "The other guard runs away sheepishly after seeing his co-worker vanquished.", 0);
                storyDialogue($"Thank you {Knight.name}! I was worried I was going to lose my book. And get arrested. That too.", Mage.name, 1);
                storyDialogue($"My pleasure. So what's the deal with this book then?", Knight.name, 0);
                storyDialogue($"It's my book of spells. I was just looking over them before we leave. I need to be ready for anything.", Mage.name, 1);
                storyDialogue($"Are you ready for anything?", Knight.name, 0);
                storyDialogue($"Maybe not anything... but yes, I am!", Mage.name, 1);
                storyWindow(3, $"{Mage.name} joined the party!", 0);
                currentParty[1] = Mage;
                storyDialogue($"Excellent. Let's go and find BARD now, and then that'll be our party complete.", Knight.name, 0);





            }
            else if (choice1 == 2)
            {
                storyWindow(2, $"{Knight.name} will go and see BARD first.", 0);

            }
        }






        public static bool doCombat(Enemy enemy, PartyMember[] partyArray, PartyMember[] currentParty)
        {
            //combat start
            bool inCombat = true;
            bool heroTurn = true;
            bool heroesWin = false;

            string[] combatPHover = [
             @"|" + menuSpacing(partyArray[0].name, false) + menuSpacing(partyArray[1].name, false) + menuSpacing(partyArray[2].name, false)
            ,@"|" + menuSpacing(partyArray[0].name, true) + menuSpacing(partyArray[1].name, false) + menuSpacing(partyArray[2].name, false)
            ,@"|" + menuSpacing(partyArray[0].name, false) + menuSpacing(partyArray[1].name, true) + menuSpacing(partyArray[2].name, false)
            ,@"|" + menuSpacing(partyArray[0].name, false) + menuSpacing(partyArray[1].name, false) + menuSpacing(partyArray[2].name, true) ];

            if (currentParty.Length == 1)
            {
                combatPHover[0] = @"|" + menuSpacing(partyArray[0].name, false) + "                                         |";
                combatPHover[1] = @"|" + menuSpacing(partyArray[0].name, true) + "                                         |";
            }
            else if (currentParty.Length == 2 && currentParty[1] == partyArray[1])
            {
                combatPHover[0] = @"|" + menuSpacing(partyArray[0].name, false) + menuSpacing(partyArray[1].name, false) + "                     |";
                combatPHover[1] = @"|" + menuSpacing(partyArray[0].name, true) + menuSpacing(partyArray[1].name, false) + "                    |";
                combatPHover[2] = @"|" + menuSpacing(partyArray[0].name, false) + menuSpacing(partyArray[1].name, true) + "                    |";
            }
            else if (currentParty.Length == 2 && currentParty[1] == partyArray[2])
            {
                combatPHover[0] = @"|" + menuSpacing(partyArray[0].name, false) + "                                         |";
                combatPHover[1] = @"|" + menuSpacing(partyArray[0].name, true) + "                                         |";
            }

            string[] combatMoSelect = [
willdoSpacing(" What will " + partyArray[0].name + " do? "),
willdoSpacing(" What will " + partyArray[1].name + " do? "),
willdoSpacing(" What will " + partyArray[2].name + " do? "),];

            string[] combatMHover = [
@"| /  o Basic Attack       <                                  \ |
| |  o Special Attack                                        | |
| |  o Item                                                  | |
| |  o Run                                                   | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@"| /  o Basic Attack                                          \ |
| |  o Special Attack     <                                  | |
| |  o Item                                                  | |
| |  o Run                                                   | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@"| /  o Basic Attack                                          \ |
| |  o Special Attack                                        | |
| |  o Item               <                                  | |
| |  o Run                                                   | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@"| /  o Basic Attack                                          \ |
| |  o Special Attack                                        | |
| |  o Item                                                  | |
| |  o Run                <                                  | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' "
];
            string[,] combatSpHover = {{//knight special options
@" _------------------------------------------------------------_
/                              ||                              \
|                              ||                              |
|                              ||                              |
|    for the kingdom           ||        royal respite         |
|                              ||                              |
|              here            ||                              |
|                              ||                              |
|______________________________][______________________________|
|                              ||                              |
|                              ||                              |
|                              ||                              |
|         option 3             ||       option 4               |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|",
@" _------------------------------------------------------------_
/                              ||                              \
|                              ||                              |
|                              ||                              |
|    for the kingdom           ||        royal respite         |
|                              ||                              |
|                              ||           here               |
|                              ||                              |
|______________________________][______________________________|
|                              ||                              |
|                              ||                              |
|                              ||                              |
|         option 3             ||       option 4               |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|",
@" _------------------------------------------------------------_
/                              ||                              \
|                              ||                              |
|                              ||                              |
|    for the kingdom           ||        royal respite         |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|
|                              ||                              |
|                              ||                              |
|                              ||                              |
|         option 3             ||       option 4               |
|                              ||                              |
|            her               ||                              |
|                              ||                              |
|______________________________][______________________________|",
@" _------------------------------------------------------------_
/                              ||                              \
|                              ||                              |
|                              ||                              |
|    for the kingdom           ||        royal respite         |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|
|                              ||                              |
|                              ||                              |
|                              ||                              |
|         option 3             ||       option 4               |
|                              ||                              |
|                              ||           here               |
|                              ||                              |
|______________________________][______________________________|"},
            };

            int partySelect = 1;
            int moveSelect = 1;

            for (int i = 0; i < currentParty.Length; i++)
            {
                currentParty[i].action = true;
            }

            do
            {
                if (heroTurn == true)
                {
                    //party member selection system
                    while (true)
                    {
                        partySelect = 1;
                        combatWindow(enemy);
                        Console.WriteLine(combatPHover[1]);
                        combatParty(partyArray, currentParty);
                        while (true)
                        {
                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                                if (keyInfo.Key.ToString() == "RightArrow")
                                {
                                    partySelect += 1;
                                    if (partySelect >= currentParty.Length + 1)
                                    {
                                        partySelect = 1;
                                    }
                                }
                                else if (keyInfo.Key.ToString() == "LeftArrow")
                                {
                                    partySelect -= 1;
                                    if (partySelect <= 0)
                                    {
                                        partySelect = currentParty.Length;
                                    }
                                }
                                else if (keyInfo.Key.ToString() == "Spacebar")
                                {
                                    if (partyArray[partySelect - 1].action == true)
                                        break;
                                }

                                combatWindow(enemy);
                                Console.WriteLine(combatPHover[partySelect]);
                                combatParty(partyArray, currentParty);
                            }
                        }

                        //move selection system
                        moveSelect = 1;
                        bool backPressed = false;
                        combatWindow(enemy);
                        Console.WriteLine(combatMoSelect[partySelect - 1]);
                        Console.WriteLine(combatMHover[1]);
                        while (true)
                        {
                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                                if (keyInfo.Key.ToString() == "DownArrow")
                                {
                                    moveSelect += 1;
                                    if (moveSelect >= 5)
                                    {
                                        moveSelect = 1;
                                    }
                                }
                                else if (keyInfo.Key.ToString() == "UpArrow")
                                {
                                    moveSelect -= 1;
                                    if (moveSelect <= 0)
                                    {
                                        moveSelect = 4;
                                    }
                                }
                                else if (keyInfo.Key.ToString() == "Spacebar")
                                {
                                    break;
                                }
                                else if (keyInfo.Key.ToString() == "B")
                                {
                                    backPressed = true;
                                    break;
                                }

                                combatWindow(enemy);
                                Console.WriteLine(combatMoSelect[partySelect - 1]);
                                Console.WriteLine(combatMHover[moveSelect]);
                            }
                        }
                        if (backPressed == false)
                        {
                            break;
                        }
                    }

                    switch (moveSelect)
                    {
                        case 1:
                            combatWindow(enemy);
                            outputTextBox(partyArray[partySelect - 1].BasicAttack(enemy), 0);
                            break;

                        case 2:
                            int spSelect = 1;
                            Console.Clear();
                            Console.WriteLine(combatSpHover[partySelect - 1, spSelect]);
                            Console.WriteLine(combatPHover[0]);
                            combatParty(partyArray, currentParty);
                            while (true)
                            {
                                if (Console.KeyAvailable)
                                {
                                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                                    if (keyInfo.Key.ToString() == "DownArrow")
                                    {
                                        spSelect += 2;
                                        if (spSelect == 5)
                                        {
                                            spSelect = 1;
                                        }
                                        if (spSelect == 6)
                                        {
                                            spSelect = 2;
                                        }
                                    }
                                    else if (keyInfo.Key.ToString() == "UpArrow")
                                    {
                                        spSelect -= 2;
                                        if (spSelect == -1)
                                        {
                                            spSelect = 3;
                                        }
                                        if (spSelect == 0)
                                        {
                                            spSelect = 4;
                                        }
                                    }
                                    if (keyInfo.Key.ToString() == "RightArrow")
                                    {
                                        spSelect += 1;
                                        if (spSelect == 3)
                                        {
                                            spSelect = 1;
                                        }
                                        if (spSelect == 5)
                                        {
                                            spSelect = 3;
                                        }
                                    }
                                    else if (keyInfo.Key.ToString() == "LeftArrow")
                                    {
                                        spSelect -= 1;
                                        if (spSelect == 2)
                                        {
                                            spSelect = 4;
                                        }
                                        if (spSelect == 0)
                                        {
                                            spSelect = 2;
                                        }
                                    }
                                    else if (keyInfo.Key.ToString() == "Spacebar")
                                    {
                                        break;
                                    }

                                    Console.Clear();
                                    Console.WriteLine(combatSpHover[partySelect - 1, spSelect]);
                                    Console.WriteLine(combatPHover[0]);
                                    combatParty(partyArray, currentParty);
                                }
                            }

                            //special attack selection system
                            switch (spSelect)
                            {
                                case 1:



                                    break;

                            }
                            break;

                        case 4:
                            combatWindow(enemy);
                            outputTextBox("You can't run from the TRAINING DUMMY!", 0);
                            break;
                    }

                    partyArray[partySelect - 1].action = false;

                    if (partyArray[0].action == false && partyArray[1].action == false && partyArray[2].action == false)
                    {
                        heroTurn = false;
                    }

                }
                else
                {
                    //enemy turn
                    Random rng = new Random();
                    int enemyPick = rng.Next(0, currentParty.Length);
                    combatWindow(enemy);
                    outputTextBox(enemy.BasicAttack(currentParty[enemyPick]), 0);
                    heroTurn = true;
                    for (int i = 0; i < currentParty.Length; i++)
                    {
                        currentParty[i].action = true;
                    }
                }
                if (enemy.cur_health <= 0)
                {
                    inCombat = false;
                    heroesWin = true;
                }
            }
            while (inCombat == true);
            return heroesWin;
        }

        public static void combatParty(PartyMember[] party, PartyMember[] current)
        {
            if (current.Length == 1)
            {
                Console.WriteLine(
                StatSpacing("|  HP.......", party[0].cur_health) + StatSpacing("/", party[0].health) + "  |                                         |\n" +
StatSpacing("|  SP.......", party[0].cur_magic) + StatSpacing("/", party[0].magic) + "  |                                         |\n" +
"|  CS......." + party[0].status + "  |                                         |\n" +
@"|                    |                                         |
\" + ActionSpacing(party[0].action) + @"|                                         /
 '------------------------------------------------------------' ");
            }

            else if (current.Length == 2 && current[1] == party[1])
            {
                Console.WriteLine(
StatSpacing("|  HP.......", party[0].cur_health) + StatSpacing("/", party[0].health) +
StatSpacing("  |  HP.......", party[1].cur_health) + StatSpacing("/", party[1].health) + "  |                    |\n" +
StatSpacing("|  SP.......", party[0].cur_magic) + StatSpacing("/", party[0].magic) +
StatSpacing("  |  MP.......", party[1].cur_magic) + StatSpacing("/", party[1].magic) + "  |                    |\n" +
"|  CS......." + party[0].status + "  |  CS......." + party[1].status + "  |                    |\n" +
@"|                    |                    |                    |
\" + ActionSpacing(party[0].action) + "|" + ActionSpacing(party[1].action) + @"|                    /
 '------------------------------------------------------------' ");
            }
            else if (current.Length == 2 && current[1] == party[2])
            {
                Console.WriteLine(
StatSpacing("|  HP.......", party[0].cur_health) + StatSpacing("/", party[0].health) +
StatSpacing("  |  HP.......", party[1].cur_health) + StatSpacing("/", party[1].health) + "  |                    |\n" +
StatSpacing("|  SP.......", party[0].cur_magic) + StatSpacing("/", party[0].magic) +
StatSpacing("  |  MP.......", party[1].cur_magic) + StatSpacing("/", party[1].magic) + "  |                    |\n" +
"|  CS......." + party[0].status + "  |  CS......." + party[1].status + "  |                    |\n" +
@"|                    |                    |                    |
\" + ActionSpacing(party[0].action) + "|" + ActionSpacing(party[1].action) + @"|                    /
 '------------------------------------------------------------' ");
            }

            else
            {
                Console.WriteLine(
StatSpacing("|  HP.......", party[0].cur_health) + StatSpacing("/", party[0].health) +
StatSpacing("  |  HP.......", party[1].cur_health) + StatSpacing("/", party[1].health) +
StatSpacing("  |  HP.......", party[2].cur_health) + StatSpacing("/", party[2].health) + "  |\n" +
StatSpacing("|  SP.......", party[0].cur_magic) + StatSpacing("/", party[0].magic) +
StatSpacing("  |  MP.......", party[1].cur_magic) + StatSpacing("/", party[1].magic) +
StatSpacing("  |  MP.......", party[2].cur_magic) + StatSpacing("/", party[2].magic) + "  |\n" +
"|  CS......." + party[0].status + "  |  CS......." + party[1].status + "  |  CS......." + party[2].status + "  |\n" +
@"|                    |                    |                    |
\" + ActionSpacing(party[0].action) + "|" + ActionSpacing(party[1].action) + "|" + ActionSpacing(party[2].action) + @"/
 '------------------------------------------------------------' ");
            }
        }

        public static string StatSpacing(string text, int stat)
        {
            if (stat <= 9)
            {
                return text + "  " + stat;
            }
            else if (stat <= 99)
            {
                return text + " " + stat;
            }
            else if (stat <= 999)
            {
                return text + "" + stat;
            }
            else
            {
                return text + "nan";
            }
        }

        public static string ActionSpacing(bool action)
        {
            if (action == true)
            {
                return "     - Ready! -     ";
            }
            else
            {
                return "   - Turn taken -   ";
            }
        }

        public static void combatWindow(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine(enemy.window);
        }




        public static void outputTextBox(string text, int boxType)
        {
            string combatTextBoxBorder = " | |\n| | ";
            string combatTextBoxTop = "| .----------------------------------------------------------. |\n| | ";
            string combatTextBoxBot = "";
            if (boxType == 0)
            {
                combatTextBoxBot = @" | |
\ '--------------------------[Space]-------------------------' /
 '------------------------------------------------------------' ";
            }
            else if (boxType == 1)
            {
                combatTextBoxBot = @" | |
\ '--------------------------[Enter]-------------------------' /
 '------------------------------------------------------------' ";
            }
            else if (boxType == 2)
            {
                combatTextBoxBot = @" | |
\ '----------------------[Type + Enter]----------------------' /
 '------------------------------------------------------------' ";
            }

            text = text.PadRight(224);
            StringBuilder textoutput = new StringBuilder(combatTextBoxTop);
            textoutput.Append(text.Substring(0, 56));
            textoutput.Append(combatTextBoxBorder);
            textoutput.Append(text.Substring(56, 56));
            textoutput.Append(combatTextBoxBorder);
            textoutput.Append(text.Substring(112, 56));
            textoutput.Append(combatTextBoxBorder);
            textoutput.Append(text.Substring(168, 56));
            textoutput.Append(combatTextBoxBot);
            Console.WriteLine(textoutput);

            if (boxType == 0)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                        if (keyInfo.Key.ToString() == "Spacebar")
                        {
                            break;
                        }
                    }
                }
            }
            else if (boxType == 1)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                        if (keyInfo.Key.ToString() == "Enter")
                        {
                            break;
                        }
                    }
                }
            }
        }


        public static void storyWindow(int page, string text, int boxType)
        {
            string[] storyPages = [
@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|",
@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|",
@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|",
@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|"
            ];


            Console.Clear();
            Console.WriteLine(storyPages[page]);
            outputTextBox(text, boxType);
        }



        public static void storyDialogue(string text, string name, int speaker)
        {
            string[,] speakWindow = {{
@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                       knight                 |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|"},
{@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                     _--========-_            |
|                                    /- _ -__- _ \  \          |
|                                   |-         -=_(  )         |
|                                   (=-.   u5=-_  \ \ \        |
|                                    )0>)   <07`   `=  (       |
|                                       /   `      /6)  |      |
|                                   |  `-         | ' \  )     |
|                                      _:_       / )   (  \    |
|                                  (  \`-    _-   |  (  \ (    |
|                                 ,/ / l_.-       |)       \   |
|                                / _)__-=|    _-   =-_\ (  )   |
|                              _-=}{}{}{  -_   _ -  {}{=-_ `   |
|                            =- _-}}{}{}}_  `Q'   _}}{}{-_ -   |
|______________________________________________________________|", ""},{
@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                       bard                   |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|" },{
@" _------------------------------------------------------------_
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                            angry lookin guard                |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|"}
            };

            Console.Clear();
            Console.WriteLine(speakWindow[speaker]);
            StringBuilder fLine = new StringBuilder(name + ":");
            for (int i = 1; i < 56 - name.Length; i++)
            {
                fLine.Append(" ");
            }
            outputTextBox(Convert.ToString(fLine) + text, 0);
        }


        public static int storyChoice(string question, string choice1, string choice2)
        {
            string[] choiceScreen = ["",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|
" + willdoSpacing($" {question} ") + @"
| /                                                          \ |
" + choiceSpacing(choice1, true) + @"| |
" + choiceSpacing(choice2, false) + @"| |
| |                                                          | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@" _------------------------------------------------------------_ 
/                                                              \
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|                                                              |
|______________________________________________________________|
" + willdoSpacing($" {question} ") + @"
| /                                                          \ |
" + choiceSpacing(choice1, false) + @"| |
" + choiceSpacing(choice2, true) + @"| |
| |                                                          | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' "];
            int menuSelect = 1;
            Console.Clear();
            Console.WriteLine(choiceScreen[menuSelect]);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key.ToString() == "DownArrow")
                    {
                        menuSelect += 1;
                        if (menuSelect >= 3)
                        {
                            menuSelect = 1;
                        }
                    }
                    else if (keyInfo.Key.ToString() == "UpArrow")
                    {
                        menuSelect -= 1;
                        if (menuSelect <= 0)
                        {
                            menuSelect = 2;
                        }
                    }
                    else if (keyInfo.Key.ToString() == "Spacebar")
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(choiceScreen[menuSelect]);
                }
            }
            return menuSelect;
        }


        public static string willdoSpacing(string question)
        {
            StringBuilder text = new StringBuilder("|  _");
            float dashNum = 56 - (question.Length);
            if (dashNum % 2 == 0)
            {
                for (int i = 1; i <= dashNum / 2; i++)
                {
                    text.Append("-");
                }
            }
            else if (dashNum % 2 != 0)
            {
                for (int i = 1; i <= (dashNum / 2) + 0.5; i++)
                {
                    text.Append("-");
                }
            }
            text.Append(question);
            for (int i = 1; i <= dashNum / 2; i++)
            {
                text.Append("-");
            }
            text.Append("_  |");

            return text.ToString();
        }

        public static string choiceSpacing(string choice, bool arrow)
        {
            StringBuilder text = new StringBuilder("| | o " + choice);
            if (arrow)
            {
                text.Append("  <");
                for (int i = 1; i <= 52 - choice.Length; i++)
                {
                    text.Append(" ");
                }
            }
            else if (!arrow)
            {
                for (int i = 1; i <= 55 - choice.Length; i++)
                {
                    text.Append(" ");
                }
            }
            return text.ToString();
        }


        public static string menuSpacing(string name, bool arrows)
        {
            StringBuilder text = new StringBuilder("");
            float spaceNum = 20 - name.Length;
            if (!arrows)
            {
                if (spaceNum % 2 == 0)
                {
                    for (int i = 1; i <= spaceNum / 2; i++)
                    {
                        text.Append(" ");
                    }
                }
                else if (spaceNum % 2 != 0)
                {
                    for (int i = 1; i <= (spaceNum / 2) + 0.5; i++)
                    {
                        text.Append(" ");
                    }
                }
                text.Append(name);
                for (int i = 1; i <= spaceNum / 2; i++)
                {
                    text.Append(" ");
                }
                text.Append("|");
            }
            if (arrows)
            {
                spaceNum -= 4;
                if (spaceNum % 2 == 0)
                {
                    for (int i = 1; i <= spaceNum / 2; i++)
                    {
                        text.Append(" ");
                    }
                }
                else if (spaceNum % 2 != 0)
                {
                    for (int i = 1; i <= (spaceNum / 2) + 0.5; i++)
                    {
                        text.Append(" ");
                    }
                }
                text.Append("> " + name + " <");
                for (int i = 1; i <= spaceNum / 2; i++)
                {
                    text.Append(" ");
                }
                text.Append("|");
            }
            return text.ToString();
        }
    }
}
