// *****************************************************************************
// *                             CS5-Electric Bill                             *
// *****************************************************************************
// *                                                                           *
// *  Programmer   : Max  Del Rio                                              *
// *  Chapter      : CS5                                                       *
// *  Assignment   : LAB#6                                                     *
// *  Class Name   : CS5-Electric Bill                                         *
// *  Date Created : 10/9/2016                                                 *
// *  Description  : This class determines a customer's electric bill.         *
// *                                                                           *
// *****************************************************************************

// Use System Namespace
using System;


// Begin CS5-Electric Bill Class
class CS5_Electric_Bill
{
    // Residential Rate constant = $.20
    const decimal RESIDENTIAL_RATE_Decimal = .20M;

    // Commercial Rate constant = $.15
    const decimal COMMERCIAL_RATE_Decimal = .15M;

    // Agricultural Rate constant = $.10
    const decimal AGRICULTURAL_RATE_Decimal = .10M;

    // Minimum KiloWatts constant = 1
    const int MINIMUM_KILOWATTS_Integer = 1;

    // Maximum KiloWatts constant = 10000
    const int MAXIMUM_KILOWATTS_Integer = 10000;



    // *************************************************************************
    // *  Method       : Main                                                  *
    // *  Description  : This method calls the Input Electric Data and Display *
    // *                 information methods. The operator is prompted if they *
    // *                 wish to enter more data. If they answer 'Y' the       *
    // *                 program continues. The Main method ends the program   *
    // *                 when the operator answers 'N' to the prompt. It       *
    // *                 displays an End of Program message when the Main      *
    // *                 method completes.                                     *
    // *************************************************************************

    // Begin Main ()
    static void Main()
    {

        // Define Variables: KiloWatts, Electric Rate Code, Answer
        int kiloWattsInt;
        string electricRateCodeString, answerString;


        // Do 
        do
        {
            // Clear Screen
            Console.Clear();

            // Display Three Titles Lines
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("****  Electric Bill Calculator Program  ****");
            Console.WriteLine("--------------------------------------------");

            // Display Blank Line
            Console.WriteLine();

            // Call Input Electric Data (Out: KiloWatts, Electric Rate Code)
            InputElectricData(out kiloWattsInt, out electricRateCodeString);

            // Display Blank Line
            Console.WriteLine();

            // Display "Call Display Information"
            DisplayInformation(kiloWattsInt, electricRateCodeString);

            // Display Blank Line
            Console.WriteLine();


            // Do 
            do
            {
                // Display Calculate another Electric Bill
                Console.Write("Calculate another Electric Bill (Y/N) ? ");

                // Input Answer
                answerString = Console.ReadLine().ToUpper();

                // While (Answer Not = "Y" And Answer Not = "N")
            } while (answerString != "Y" && answerString != "N");

        // While Answer = "Y"
        } while (answerString == "Y");

        // Clear Screen
        Console.Clear();

        // Display End of Program
        Console.WriteLine("End of Electric Bill Calculator Program!");

        // Display Blank Line
        Console.WriteLine();

        // DIsplay Press any key Prompt
        Console.Write("Press any key to continue . . . ");

        // Input Press Any Key
        Console.ReadKey();

    }// End Main

    // *************************************************************************
    // *  Method       : Input Electric Data                                   *
    // *  Description  : This method inputs the kilowatt usage and rate code   *
    // *                 from the keyboard. It must validate the input data    *
    // *                 that the input is within the specified limits. It     *
    // *                 returns the kilowatts and rate code as output         *
    // *                 parameters when completed. The rate code is returned  *
    // *                 capitalized.                                          *
    // *************************************************************************

    // Begin Input Electric Data ( Out: KiloWatts, Electric Rate Code )
    static void InputElectricData(out int KiloWattsInt, out string electricRateCodeString)
    {
        // Define Variables: None

        // Display Units Prompt
        Console.Write("Enter Units (" + MINIMUM_KILOWATTS_Integer + " to " + MAXIMUM_KILOWATTS_Integer + ") : ");

        // Input KiloWatts
        int.TryParse(Console.ReadLine(), out KiloWattsInt);


        // Do  While (KiloWatts < Minimum KiloWatts constant or KiloWatts > Maximum KiloWatts constant)
        while (KiloWattsInt < MINIMUM_KILOWATTS_Integer || KiloWattsInt > MAXIMUM_KILOWATTS_Integer)
        {
            // Display Units Error Message
            Console.Write("Units Error - Try Again  : ");

            // Input Another KiloWatts
            int.TryParse(Console.ReadLine(), out KiloWattsInt);

        }// End Do 

        // Display Blank Line
        Console.WriteLine();

        // Display Electric Rate Codes (4 lines)
        Console.WriteLine("Electric Rate Codes");
        Console.WriteLine("R - Residential Rate");
        Console.WriteLine("C - Commercial Rate");
        Console.WriteLine("A - Agricultural Rate");

        // Display Blank Line
        Console.WriteLine();

        // Display Electric Rate Code Prompt
        Console.Write("Enter Rate Code (R,C,A)  : ");

        // Input Electric Rate Code
        electricRateCodeString = Console.ReadLine().ToUpper();


        // Do  While (Electric Rate Code  Not  = "R" And Electric Rate Code  Not = "C" And Electric Rate Code Not = "A")
        while (electricRateCodeString != "R" && electricRateCodeString != "C" && electricRateCodeString != "A")
        {
            // Display Electric Rate Code Error Message
            Console.Write("Code Error - Try Again   : ");

            // Input Another Electric Rate Code
            electricRateCodeString = Console.ReadLine().ToUpper();

        }// End Do 

    }// End Input Electric Data

    // *************************************************************************
    // *  Method       : Display Information                                   *
    // *  Description  : This method calculates the bill amount and displays   *
    // *                 the customer's kilowatts, rate, and bill amount. It   *
    // *                 receives the kilowatts, and rate code as input        *
    // *                 parameters. The bill amount is calculated by          *
    // *                 multiplying the kilowatts times the electric rate.    *
    // *                 The electric rate value is obtained by calling the    *
    // *                 Electric Rate method.                                 *
    // *************************************************************************

    // Begin Display Information ( In: KiloWatts, Electric Rate Code )
    static void DisplayInformation(int kiloWattsInteger, string electricRateCodeString)
    {

        // Define Variables: Electric Bill
        decimal electricBillDecimal;

        // Display KiloWatts
        Console.WriteLine("Your KiloWatt Usage is " + kiloWattsInteger);

        // Display Call Get Electric Rate (In:  Electric Rate Code)
        Console.WriteLine("Your Rate Per KiloWatt is " + GetElectricRate(electricRateCodeString).ToString("C2"));

        // Display Blank Line
        Console.WriteLine();

        // Calculate Electric Bill = KiloWatts * Call Get Electric Rate (In: ELectric Rate Code)
        electricBillDecimal = kiloWattsInteger * GetElectricRate (electricRateCodeString);

        // Display Electric Bill
        Console.WriteLine("Your Electric Bill is " + electricBillDecimal.ToString("C2"));

    }// End Display Information

    // *************************************************************************
    // *  Method       : Get Electric Rate                                     *
    // *  Description  : This value returning method determines a rate based   *
    // *                 upon the rate code. The rate is determined: "R" uses  *
    // *                 Residential Rate, "C" uses Commercial Rate, and "A"   *
    // *                 uses Agricultural Rate. These rates are defines as    *
    // *                 class constants. It receives the rate code as an      *
    // *                 input parameter and returns the rate as a decimal     *
    // *                 value when completed                                  *
    // *************************************************************************

    // Begin Get Electric Rate ( In: Electric Rate Code ) As a Decimal Number
    static decimal GetElectricRate(string electricRateCodeString)
    {

        // Define Variables: Rate
        decimal rateDecimal;

        // IF Electric Rate Code = "R"
        if (electricRateCodeString == "R")

            // Rate = Residential Rate constant
            rateDecimal = RESIDENTIAL_RATE_Decimal;

        // Else IF Electric Rate Code = "C"
        else if (electricRateCodeString == "C")

            // Rate = Commercial Rate constant
            rateDecimal = COMMERCIAL_RATE_Decimal;

        // Else
        else

            // Rate = Agricultural Rate constant
            rateDecimal = AGRICULTURAL_RATE_Decimal;

        // End IF

        // Return Rate
        return rateDecimal;

    }// End Get Electric Rate


}// End CS5-Electric Bill Class

