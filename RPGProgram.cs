using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.FileIO;
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
        public bool action = true;
        public string attackText;
        public string critText;
        public string BasicAttack(Enemy enemy)
        {
            Random rng = new Random();
            float bounds = rng.Next(90, 111);
            int crit = 1;
            if (rng.Next(1, 21) == 20)
            {
                crit = 2;
            }
            float healthchange = (bounds * attack * crit * (attack / enemy.defense)) / 100;
            healthchange = Convert.ToInt32(healthchange);
            enemy.cur_health -= Convert.ToInt32(healthchange);
            if (crit == 1)
            {
                return attackText + enemy.name + ". " + enemy.name + " took " + healthchange + " points of damage!";
            }
            else
            {
                return attackText + enemy.name + ". " + enemy.name + " took " + healthchange + " points of damage!" + critText;
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
        public int magic;
        public int cur_magic;
        public string window;
    }

    internal class RPG_temp
    {
        static void Main(string[] args)
        {

            PartyMember Knight = new PartyMember();
            Knight.name = "KNIGHT";
            Knight.health = 100;
            Knight.cur_health = Knight.health;
            Knight.attack = 100;
            Knight.defense = 100;
            Knight.magic = 13;
            Knight.cur_magic = Knight.magic;
            Knight.attackText = Knight.name + " swung his sword and heroicly slashed at ";
            Knight.critText = Knight.name + " is chuffed to see that he has Critical Hit!";

            PartyMember Mage = new PartyMember();
            Mage.name = "MAGE";
            Mage.health = 100; 
            Mage.cur_health = Mage.health;
            Mage.attack = 100;
            Mage.defense = 100;
            Mage.magic = 100;
            Mage.cur_magic = Mage.magic;
            Mage.attackText = Mage.name + " sent a small magic pulse toward ";
            Mage.critText = Mage.name + " cheers proudly because she managed to Critical Hit!";

            PartyMember Bard = new PartyMember();
            Bard.name = "BARD";
            Bard.health = 100;
            Bard.cur_health = Bard.health;
            Bard.attack = 100;
            Bard.defense = 100;
            Bard.magic = 100;
            Bard.cur_magic = Bard.magic;
            Bard.attackText = Bard.name + " fired his crossbow at ";
            Bard.critText = Bard.name + " smoulders smugly at his Critical Hit!";

            PartyMember[] partyArray = [Knight, Mage, Bard];
            PartyMember[] currentParty = [];


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

            Enemy RoyalUnderling = new Enemy();
            RoyalUnderling.name = "ROYAL UNDERLING";
            RoyalUnderling.health = 600;
            RoyalUnderling.attack = 300;
            RoyalUnderling.defense = 300;
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

            Random rng = new Random();

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
|                          o Play                              |
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

            int menuSelect = 1;

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
|      However, a young man and his plans may soon change      |
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
|                  ( The village of the poor )                 |
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
|                  ( The village of the poor )                 |
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
|                  ( The village of the poor )                 |
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

            string[] combatPHover = {
             @"|       KNIGHT       |        MAGE        |        BARD        |"
            ,@"|   >   KNIGHT   <   |        MAGE        |        BARD        |"
            ,@"|       KNIGHT       |   >    MAGE    <   |        BARD        |"
            ,@"|       KNIGHT       |        MAGE        |   >    BARD    <   |"};
            int partySelect = 1;


            string[] combatMoSelect = {
@"| /                   What will KNIGHT do?                   \ |",
@"| /                    What will MAGE do?                    \ |",
@"| /                    What will BARD do?                    \ |",
};

            string[] combatMHover = {
@"| |  o Basic Attack                                          | |
| |  o Special Attack                                        | |
| |  o Item                                                  | |
| |  o Run                                                   | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@"| |  o Basic Attack       <                                  | |
| |  o Special Attack                                        | |
| |  o Item                                                  | |
| |  o Run                                                   | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@"| |  o Basic Attack                                          | |
| |  o Special Attack     <                                  | |
| |  o Item                                                  | |
| |  o Run                                                   | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@"| |  o Basic Attack                                          | |
| |  o Special Attack                                        | |
| |  o Item               <                                  | |
| |  o Run                                                   | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' ",
@"| |  o Basic Attack                                          | |
| |  o Special Attack                                        | |
| |  o Item                                                  | |
| |  o Run                <                                  | |
\ \__________________________________________________________/ /
 '------------------------------------------------------------' "
};
            int moveSelect = 1;

            string[,] combatSpHover = {{//knight special options
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
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|"
,@" _------------------------------------------------------------_
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
|______________________________][______________________________|"
,@" _------------------------------------------------------------_
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
|______________________________][______________________________|"
,@" _------------------------------------------------------------_
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
|______________________________][______________________________|"
,@" _------------------------------------------------------------_
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
            int spSelect = 1;


            string TextToConvert = ("The village of the poor");
            int ResolutionWidth = (62);
            float RemainingWidth = ResolutionWidth - TextToConvert.Length;
            int TextLength = (TextToConvert.Length);
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





            //combat start
            bool inCombat = true;
            bool heroTurn = true;

            do
            {
                if (heroTurn == true)
                {
                    //party member selection system
                    while (true)
                    {
                        partySelect = 1;
                        combatWindow();
                        Console.WriteLine(combatPHover[1]);
                        combatParty(partyArray);
                        while (true)
                        {
                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                                if (keyInfo.Key.ToString() == "RightArrow")
                                {
                                    partySelect += 1;
                                    if (partySelect >= 4)
                                    {
                                        partySelect = 1;
                                    }
                                }
                                else if (keyInfo.Key.ToString() == "LeftArrow")
                                {
                                    partySelect -= 1;
                                    if (partySelect <= 0)
                                    {
                                        partySelect = 3;
                                    }
                                }
                                else if (keyInfo.Key.ToString() == "Spacebar")
                                {
                                    if (partyArray[partySelect - 1].action == true)
                                        break;
                                }

                                combatWindow();
                                Console.WriteLine(combatPHover[partySelect]);
                                combatParty(partyArray);
                            }
                        }

                        //move selection system
                        moveSelect = 1;
                        bool backPressed = false;
                        combatWindow();
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

                                combatWindow();
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
                            outputTextBox(partyArray[partySelect-1].BasicAttack(FDBeast));
                            break;

                        case 2:
                            spSelect = 1;
                            Console.Clear();
                            Console.WriteLine(combatSpHover[partySelect - 1, spSelect]);
                            Console.WriteLine(combatPHover[0]);
                            combatParty(partyArray);
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
                                    combatParty(partyArray);
                                }
                            }

                            //special attack selection system
                            switch (spSelect)
                            {
                                case 1:



                                    break;

                            }
                            break;
                    }

                    partyArray[partySelect-1].action = false;

                    if (Knight.action == false && Mage.action == false && Bard.action == false)
                    {
                        heroTurn = false;
                    }

                }
                else
                {
                    //enemy turn
                    heroTurn = true;
                    Knight.action = true;
                    Mage.action = true;
                    Bard.action = true;
                }




            }
            while (inCombat == true);


        }

        public static void combatWindow()
        {
            Console.Clear();
            Console.WriteLine(
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
|______________________________________________________________|");
        }


        public static void combatParty(PartyMember[] partyArray)
        {
            Console.WriteLine(
StatSpacing("|  HP.......", partyArray[0].cur_health) + StatSpacing("/", partyArray[0].health) +
StatSpacing("  |  HP.......", partyArray[1].cur_health) + StatSpacing("/", partyArray[1].health) +
StatSpacing("  |  HP.......", partyArray[2].cur_health) + StatSpacing("/", partyArray[2].health) + "  |\n" +
StatSpacing("|  SP.......", partyArray[0].cur_magic) + StatSpacing("/", partyArray[0].magic) +
StatSpacing("  |  MP.......", partyArray[1].cur_magic) + StatSpacing("/", partyArray[1].magic) +
StatSpacing("  |  MP.......", partyArray[2].cur_magic) + StatSpacing("/", partyArray[2].magic) + "  |\n" +
"|  CS......." + partyArray[0].status + "  |  CS......." + partyArray[1].status + "  |  CS......." + partyArray[2].status + "  |\n" +
@"|                    |                    |                    |
\" + ActionSpacing(partyArray[0].action) + "|" + ActionSpacing(partyArray[1].action) + "|" + ActionSpacing(partyArray[2].action) + @"/
 '------------------------------------------------------------' ");

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
                return text + "big";
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


        public static void outputTextBox(string text)
        {
            const string combatTextBoxBorder = " | |\n| | ";
            const string combatTextBoxTop = "| .----------------------------------------------------------. |\n| | ";
            const string combatTextBoxBot = @" | |
\ '---------------------------[__]---------------------------' /
 '------------------------------------------------------------' ";

            text = text.PadRight(224);
            StringBuilder textoutput = new StringBuilder(combatTextBoxTop);
            combatWindow();
            textoutput.Append(text.Substring(0, 56));
            textoutput.Append(combatTextBoxBorder);
            textoutput.Append(text.Substring(56, 56));
            textoutput.Append(combatTextBoxBorder);
            textoutput.Append(text.Substring(112, 56));
            textoutput.Append(combatTextBoxBorder);
            textoutput.Append(text.Substring(168, 56));
            textoutput.Append(combatTextBoxBot);
            Console.WriteLine(textoutput);

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
    }
}
