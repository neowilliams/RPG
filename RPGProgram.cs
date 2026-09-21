using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

            PartyMember Mage = new PartyMember();
            Mage.health = 100;
            Mage.attack = 100;
            Mage.defense = 100;
            Mage.magic = 100;

            PartyMember Bard = new PartyMember();
            Bard.health = 100;
            Bard.attack = 100;
            Bard.defense = 100;
            Bard.magic = 100;


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

            string[] combatPHover = {
             @"|       knight       |        mage        |        bard        |"
            ,@"|   >   knight   <   |        mage        |        bard        |"
            ,@"|       knight       |   >    mage    <   |        bard        |"
            ,@"|       knight       |        mage        |   >    bard    <   |"};
            int partySelect = 1;


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

            bool inCombat = true;
            bool heroTurn = true;

            do
            {
                if (heroTurn == true)
                {
                    //party member selection system
                    partySelect = 1;
                    combatWindow();
                    Console.WriteLine(combatPHover[1]);
                    //combatParty();
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

                            combatWindow();
                            Console.WriteLine(combatPHover[partySelect]);
                            //combatParty();
                        }
                    }

                    //move selection system
                    moveSelect = 1;
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
                                Console.Clear();
                                continue;
                            }

                            combatWindow();
                            Console.WriteLine(combatMoSelect[partySelect - 1]);
                            Console.WriteLine(combatMHover[moveSelect]);
                        }
                    }

                    switch (moveSelect)
                    {
                        case 1:
                            //basic attack system
                            string resultMessage = "";
                            int damageDealt = 0;
                            int crit = 1;

                            if (rng.Next(1, 21) == 20)
                            {
                                crit = 2;
                            }

                            if (partySelect == 1)
                            {
                                damageDealt = Knight.attack * crit;
                                resultMessage = "Knight dealt " + damageDealt + " damage to Foul Dragonian Beast.";
                            }

                            else if (partySelect == 2)
                            {
                                damageDealt = Mage.attack * crit;
                                resultMessage = "Mage dealt " + damageDealt + " damage to Foul Dragonian Beast.";
                            }

                            else if (partySelect == 3)
                            {
                                damageDealt = Bard.attack * crit;
                                resultMessage = "Bard dealt " + damageDealt + " damage to Foul Dragonian Beast.";
                            }

                            outputTextBox(resultMessage);
                            break;

                        case 2:
                            spSelect = 1;
                            Console.Clear();
                            Console.WriteLine(combatSpHover[partySelect - 1, spSelect]);
                            Console.WriteLine(combatPHover[0]);
                            combatParty(Knight, Mage, Bard);
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
                                    //combatParty();
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
                }
                else
                {
                    //enemy turn
                }

            }
            while (inCombat == true);




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

        public static void combatWindow()
        {
            Console.Clear();
            Console.WriteLine(
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
|______________________________________________________________|");
        }


        public static void combatParty(PartyMember Knight, PartyMember Mage, PartyMember Bard)
        {
            StringBuilder party = new StringBuilder(
@"|  HP..............  |  HP..............  |  HP..............  |
|  SP..............  |  MP..............  |  MP..............  |
|  CS..............  |  CS..............  |  CS..............  |
|     Cannot take    |      Has taken     |    Has not taken   |
\     their turn     |     their turn     |   their turn yet   /
 '------------------------------------------------------------' ");
            Console.WriteLine(party);

            party.Insert(16, Knight.attack);

        }



        public static void outputTextBox(string text)
        {
            const string combatTextBoxBorder = " | |\n| | ";
            const string combatTextBoxTop = "| .----------------------------------------------------------. |\n| | ";
            const string combatTextBoxBot = @" | |
\ '----------------------------------------------------------' /
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
