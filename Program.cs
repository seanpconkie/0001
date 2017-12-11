using System;

namespace myPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool blnIsUserAnswerValid = false; //returned from method ProValidateInput

            string strUserAnswer = "N"; // standard var for user to answer questions

            int intPasswordLength = 0; //total char length of password
            int intFormatType = 0; //password format, standard is 1

            const string strWelcome = "Welcome to myPasswordGenerator.\nThis will generate a password with the format; "; //message shown to user at start
            string strPassword = "";

            string[] strFormatDescriptionArr = new string[4] {
                                                              "upper case and lower case letters with numbers and symbols."
                                                            , "upper case and lower case letters with numbers but no symbols."
                                                            , "upper case and lower case letters with no numbers or symbols."
                                                            , "lower case letters only."
                                                            };






            //welcome user, explain function
            Console.WriteLine(strWelcome + strFormatDescriptionArr[intFormatType]);

            Console.WriteLine("Would you like to change the format? [Y/N]");

            //check input and prompt user for correct input if required
            while (true)
            {
                strUserAnswer = Console.ReadLine();
                blnIsUserAnswerValid = ProValidateInput(strUserAnswer);

                if (blnIsUserAnswerValid == true)
                {
                    break;
                }
                else if (blnIsUserAnswerValid == false)
                {
                    Console.WriteLine("Answer Invalid.\nPlease answer either \'Y\' or \'N\'.");
                    continue;
                }
            }

            if (strUserAnswer == "Y")
            {
                //if format to be changed prompt user for desired format
                Console.WriteLine("Please choose a password format from;");

                for (int i = 0; i <= 3; i++)
                {
                    Console.WriteLine(i + ": " + strFormatDescriptionArr[i]);
                }

                do //loop until user is happy with selected format
                {

                    Console.WriteLine("\n\nPlease provide the format ID (i.e. 1).");


                    while (true)//check input and prompt user for correct input if required
                    {
                        intFormatType = Convert.ToInt32(Console.ReadLine());

                        if (intFormatType <= 3)
                        {
                            break;
                        }
                        else if (intFormatType > 3)
                        {
                            Console.WriteLine("Format Invalid.\nPlease provide a valid ID.");
                            continue;
                        }
                    }


                    Console.WriteLine("You have selected format; " + strFormatDescriptionArr[intFormatType]);
                    Console.WriteLine("Would you like to change the format? [Y/N]");


                    while (true)//check input and prompt user for correct input if required
                    {
                        strUserAnswer = Console.ReadLine();
                        blnIsUserAnswerValid = ProValidateInput(strUserAnswer);

                        if (blnIsUserAnswerValid == true)
                        {
                            break;
                        }
                        else if (blnIsUserAnswerValid == false)
                        {
                            Console.WriteLine("Answer Invalid.\nPlease answer either \'Y\' or \'N\'.");
                            continue;
                        }
                    }


                } while (strUserAnswer == "Y")

                ;
            }

            //ask user for length of password
            Console.WriteLine("Please confirm the desired length of password.");

            intPasswordLength = Convert.ToInt32(Console.ReadLine());

            //generate password
            //code returns random numbers which are converted to characters based 
            //on ASCII
            var random = new Random();

            for (int i = 1; i <= intPasswordLength; i++)
            {
                //if symbol format
                if (intFormatType == 0)
                {
                    if (i % 10 == 0)
                    {
                        strPassword = strPassword + (char)random.Next(33, 47);
                        continue;
                    }
                    else if (i == intPasswordLength)
                    {
                        strPassword = strPassword + (char)random.Next(33, 47);
                        continue;
                    }
                }
                //if number format
                if (intFormatType <= 1)
                {
                    if (i % 9 == 0)
                    {
                        strPassword = strPassword + (char)random.Next(48, 57);
                        continue;
                    }
                    else if (i == intPasswordLength - 1)
                    {
                        strPassword = strPassword + (char)random.Next(48, 57);
                        continue;
                    }
                }
                //if upper case format
                if (intFormatType <= 2)
                {
                    if (i % 2 == 0)
                    {
                        strPassword = strPassword + (char)random.Next(65, 90);
                        continue;
                    }
                }
                //if lower case char required
                strPassword = strPassword + (char)random.Next(97, 122);

            }

            Console.WriteLine("Your password is: " + strPassword);
            ;

        }



        public static bool ProValidateInput(string strReturnValue)
        {
            bool blnIsUserInputValid = false;

            //check has user returned Y or N

            if (strReturnValue == "N")
            {
                blnIsUserInputValid = true;
            }
            else if (strReturnValue == "Y")
            {
                blnIsUserInputValid = true;
            }
            else
                blnIsUserInputValid = false;

            return blnIsUserInputValid;
        }


    }



    public enum pwdFormats
    {
        UpperLowerNumberSymbol = 0,
        UpperLowerNumberNoSymbol = 1,
        UpperLowerNoNumberNoSymbol = 2,
        NoUpperLowerNoNumberNoSymbol = 3

    }

}



