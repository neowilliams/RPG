using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace RPG_temp
{

    class PartyMember
    {
        public int health;
        public int attack;
        public int defense;
        public int magic;
    }
    class Enemy
    {
        public int health;
        public int attack;
        public int defense;
        public int magic;
    }

    internal class RPG_temp
    {
        static void Main(string[] args)
        {

            PartyMember Knight = new PartyMember();
            Knight.health = 100;
            Knight.attack = 100;
            Knight.defense = 100;
            Knight.magic = 100;

            Enemy FDBeast = new Enemy();
            FDBeast.health = 600;
            FDBeast.attack = 300;
            FDBeast.defense = 300;
            FDBeast.magic = 0;

            Random rng = new Random();

            //WelcomeScreen();    
            //        public static void WelcomeScreen()
            //        {
            //            Console.Clear();
            //            const string welcomeScreen = @"
            // _------------------------------------------------------------_
            ///                                                              \
            //|                                                              |
            //|       __        _______ _     ____ ___  __  __ _____         |
            //|       \ \      / / ____| |   / ___/ _ \|  \/  | ____|        |
            //|        \ \ /\ / /|  _| | |  | |  | | | | |\/| |  _|          |
            //|         \ V  V / | |___| |__| |__| |_| | |  | | |___         |
            //|          \_/\_/  |_____|_____\____\___/|_|  |_|_____|        |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //|                                                              |
            //\                                                              /
            // '------------------------------------------------------------' ";
            //            Console.WriteLine(welcomeScreen);
            //}



            const string combatBase =
@" _------------------------------------------------------------_
/                     Foul Dragonian Beast                     \
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
|______________________________________________________________|
|       knight       |        mage        |        bard        |
|  HP...........105  |  HP............73  |  HP............47  |
|  SP............21  |  MP............96  |  MP............12  |
|  CS........asleep  |  CS........burned  |  CS..........fine  |
|     Cannot take    |      Has taken     |    Has not taken   |
\     their turn     |     their turn     |   their turn yet   /
 '------------------------------------------------------------' ";

            const string combatWindow =
@" _------------------------------------------------------------_
/                     Foul Dragonian Beast                     \
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

            string[] combatPHover = {
             @"|       knight       |        mage        |        bard        |"
            ,@"|   >   knight   <   |        mage        |        bard        |"
            ,@"|       knight       |   >    mage    <   |        bard        |"
            ,@"|       knight       |        mage        |   >    bard    <   |"};
            int partySelect = 1;

            const string combatParty =
@"|  HP...........105  |  HP............73  |  HP............47  |
|  SP............21  |  MP............96  |  MP............12  |
|  CS........asleep  |  CS........burned  |  CS..........fine  |
|     Cannot take    |      Has taken     |    Has not taken   |
\     their turn     |     their turn     |   their turn yet   /
 '------------------------------------------------------------' ";

            string[] combatMoSelect = {
@"| /                   What will Knight do?                   \ |",
@"| /                    What will Mage do?                    \ |",
@"| /                    What will Bard do?                    \ |",
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


            string[] combatSpSelect = {
@" _------------------------------------------------------------_
/                              ||                              \
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|"
,@" _------------------------------------------------------------_
/                              ||                              \
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|"
,@" _------------------------------------------------------------_
/                              ||                              \
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|                              ||                              |
|______________________________][______________________________|"};

            //party member selection system
            Console.Clear();
            Console.WriteLine(combatWindow);
            Console.WriteLine(combatPHover[1]);
            Console.WriteLine(combatParty);
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
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(combatWindow);
                    Console.WriteLine(combatPHover[partySelect]);
                    Console.WriteLine(combatParty);
                }
            }

            //move selection system
            Console.Clear();
            Console.WriteLine(combatWindow);
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

                    Console.Clear();
                    Console.WriteLine(combatWindow);
                    Console.WriteLine(combatMoSelect[partySelect - 1]);
                    Console.WriteLine(combatMHover[moveSelect]);
                }
            }

            int damageDealt = 0;
            if (moveSelect == 1)
            {
                if (partySelect == 1)
                {
                    int crit = 1;

                    if (rng.Next(1, 21) == 20)
                    {
                        crit = 2;
                    }

                    damageDealt = Knight.attack * crit;

                }
                string resultMessage = "Knight dealt " + damageDealt + " damage to Foul Dragonian Beast";

            }



            //special attack selection system
            Console.Clear();
            Console.WriteLine(combatSpSelect[partySelect - 1]);


            //string TextToConvert = ("What will Knight do?");
            //int ResolutionWidth = (62);
            //float RemainingWidth = ResolutionWidth - TextToConvert.Length;
            //int TextLength = (TextToConvert.Length);
            //float OtherSide = RemainingWidth;
            //for (int i = 0; i < (RemainingWidth / 2); i++)
            //{
            //    Console.Write(" ");
            //    OtherSide--;
            //}
            //Console.Write(TextToConvert);
            //for (int i = 0; i < (OtherSide); i++)
            //{
            //    Console.Write(" ");
            //}
            //Console.Write("#");


        }
        public static void outputTextBox(string text)
        {
            const string combatTextBoxBorderL = "| | ";
            const string combatTextBoxBorderR = " | |";
            const string combatTextBoxTop = @"| .----------------------------------------------------------. |";
            const string combatTextBoxBot = @"\ '----------------------------------------------------------' /
 '------------------------------------------------------------' ";

            for (int i = 0; i < text.Length; i++)
            {
                Console.Clear();
                Console.WriteLine(combatWindow);
                Console.WriteLine(combatTextBoxTop);
                Console.Write(combatBorder);
                Console.Write(" ");
                for (int k = 0; k < i; k++)
                {
                    Console.Write(text[k]);
                }

                for (int j = 1; j <= 56 - i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(" ");
                Console.WriteLine(combatBorder);
                Console.WriteLine(
@"| |                                                          | |
| |                                                          | |
| |                                                          | |");
                Console.WriteLine(combatTextBoxBot);
                Thread.Sleep(50);
            }
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
