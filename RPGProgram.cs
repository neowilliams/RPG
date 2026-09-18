using System;

namespace RPG
{
    internal class RPGProgram
    {
        static void Main(string[] args)
        {

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

            string[] combatHover = {
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


            const string combatTextBoxTop = @"| .----------------------------------------------------------. |";
            const string combatBorder = "| |";
            //| |                                                          | |
            //| |                                                          | |
            //| |                                                          | |
            //| |                                                          | |
            const string combatTextBoxBot = @"\ '----------------------------------------------------------' /
 '------------------------------------------------------------' ";

            const string combatMoSelect =
@" _------------------------------------------------------------_
/                     Foul Dragonian Beast                     \
|-----------------------------------------------------------_  |
|                     What will Knight do?                   \ |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
|                                                            | |
| \__________________________________________________________/ |
|______________________________________________________________|
|       knight       |        mage        |        bard        |
|  HP...........105  |  HP............73  |  HP............47  |
|  SP............21  |  MP............96  |  MP............12  |
|  CS........asleep  |  CS........burned  |  CS..........fine  |
|     Cannot take    |      Has taken     |    Has not taken   |
\     their turn     |     their turn     |   their turn yet   /
 '------------------------------------------------------------' ";


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
            Console.WriteLine(combatHover[1]);
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
                    Console.WriteLine(combatHover[partySelect]);
                    Console.WriteLine(combatParty);
                }
            }

            //special move selection system
            Console.Clear();
            Console.WriteLine(combatSpSelect[partySelect-1]);





            //            string resultMessage = "Attacking with his sword, Knight dealt 9 damage to Foul Dragonian Beast";
            //            for (int i = 0; i < 56; i++)
            //            {
            //                Console.Clear();
            //                Console.WriteLine(combatWindow);
            //                Console.WriteLine(combatTextBoxTop);
            //                Console.Write(combatBorder);
            //                Console.Write(" ");
            //                for (int k = 0; k < i; k++)
            //                {
            //                    Console.Write(resultMessage[k]);
            //                }

            //                for (int j = 1; j <= 56 - i; j++)
            //                {
            //                    Console.Write(" ");
            //                }
            //                Console.Write(" ");
            //                Console.WriteLine(combatBorder);
            //                Console.WriteLine(@"| |                                                          | |
            //| |                                                          | |
            //| |                                                          | |");
            //                Console.WriteLine(combatTextBoxBot);
            //                Thread.Sleep(50);
            //            }




            string TextToConvert = ("What will Knight do?");
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
            Console.Write("#");


            //try
            //{
            //    Console.WriteLine("Choose between a sword or a shield. 1 for sword, 2 for shield");
            //    int gearChoice = Convert.ToInt32(Console.ReadLine());
            //    if (gearChoice == 1)
            //    {
            //        Console.WriteLine("You chose the sword");
            //    }
            //    else if (gearChoice == 2)
            //    {
            //        Console.WriteLine("You chose the shield");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Not an option");
            //    }

            //}
            //catch
            //{
            //    Console.WriteLine("Invalid entry");
            //}


            //Console.WriteLine("You reach a crossroads. Would you like to go left or right? Please enter l or r");
            //string pChoice = Console.ReadLine();
            //if (pChoice.Equals("l"))
            //{
            //    Console.WriteLine("You chose the left path. You find a house with three doors. One green, one red, one blue. Which one would you like to open? Please enter g, r, or b");
            //    string pChoice2 = Console.ReadLine();
            //    if (pChoice2.Equals("g"))
            //    {
            //        Console.WriteLine("You chose the green door. You find nothing");
            //    }
            //    else if (pChoice2.Equals("r"))
            //    {
            //        Console.WriteLine("You chose the red door. You find something.");
            //    }
            //    else if (pChoice2.Equals("b"))
            //    {
            //        Console.WriteLine("You chose the blue door. You find everything.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("I don't think that there is a door that colour.");
            //    }
            //}
            //else if (pChoice.Equals("r"))
            //{
            //    Console.WriteLine("You chose the right path. You find a chest at the end of the path. Would you like to open it? Please enter y or n");
            //    string pChoice2 = Console.ReadLine();
            //    if (pChoice2.Equals("y"))
            //    {
            //        Console.WriteLine("You open the chest. It is a mimic and you are slobbered to death.");
            //    }
            //    else if (pChoice2.Equals("n"))
            //    {
            //        Console.WriteLine("You do not open the chest. I guess we'll never know what was in there.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Open or don't open. Those are your options. Take it or leave it");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("That is not a direction.");
            //}

            //Random rnd = new Random();
            //int comChoice = rnd.Next(1, 7);
            //string plyrChoice = Console.ReadLine();
            //if (Convert.ToInt32(plyrChoice) == comChoice)
            //{
            //    Console.WriteLine("The two numbers were the same");
            //}
            //else 
            //{
            //    Console.WriteLine("Try again");
            //}






        }
    }
}
