using RestThreeSixtyFive;

Calculator calc = new Calculator();

bool max2Numbers = true;
bool allowMoreThan1K = true;
bool allowNegatives = true;


Console.WriteLine("Samples - using Max 2 constraint, negative allowed and More than 1000 number is allowed ::\n");

try 
{
    //Exception Ones
    Console.WriteLine("1.1: Adding(1,2,3,4) = " + calc.Add("1,2,3,4", max2Numbers).ToString()); // More than 2 Numbers are passed 
}
catch (Exception ex)
{
    Console.WriteLine("1.1: Adding(1,2,3,4) = " + "Exception: " + ex.Message);
}
    
Console.WriteLine("1.1.a: Adding(20) = " + calc.Add("20", max2Numbers).ToString());
Console.WriteLine("1.1.b: Adding(1, 5000) = " + calc.Add("1, 5000", max2Numbers, allowMoreThan1K).ToString());

Console.WriteLine("1.1.c:Adding(4,-3) = " + calc.Add("4,-3", max2Numbers, !allowMoreThan1K, allowNegatives).ToString()); // Allow Negatives

Console.WriteLine("1.2: Adding(\"\") = " + calc.Add("", max2Numbers).ToString());
Console.WriteLine("1.3. Adding(5,tytyt) = " + calc.Add("5,tytyt", max2Numbers).ToString());


//*********************//
Console.WriteLine("\n\n Samples - using Any number, Negative not allowed, and No more than 1000 ::\n");
Console.WriteLine("2: Adding(1,2,3,4,5,6,7,8,9,10,11,12) = " + calc.Add("1,2,3,4,5,6,7,8,9,10,11,12").ToString());

Console.WriteLine("3: Adding(1\\n2,3) = " + calc.Add("1\n2,3").ToString());

try
{
    //Exception Ones
    Console.WriteLine("4: Adding(4,-3) = " + calc.Add("4,-3").ToString()); // Disallow Negatives, default false params are good  
}
catch (Exception ex) 
{
    Console.WriteLine("4: Adding(4,-3) = " + ex.Message);
}
    
Console.WriteLine("5: Adding(2,1001,6) = " + calc.Add("2,1001,6").ToString());

Console.WriteLine("6.1: Adding(//#\\n2#5) = " + calc.Add("//#\n2#5").ToString());
Console.WriteLine("6.2: Adding(//,\\n2,ff,100) = " + calc.Add("//,\n2,ff,100").ToString());
Console.WriteLine("7 :Adding(//[***]\\n11***22***33) = " + calc.Add("//[***]\n11***22***33").ToString());
Console.WriteLine("8: Adding(//[*][!!][r9r]\\n11r9r22*hh*33!!44) = " + calc.Add("//[*][!!][r9r]\n11r9r22*hh*33!!44").ToString());

while (true)
{
    Console.WriteLine("\nEnter input string with no constraints :");
    var src = Console.ReadLine();

    if (string.IsNullOrEmpty(src))
        continue;

    if (src.ToUpper().CompareTo("^C") == 0)
        break;

    try
    {
        Console.WriteLine(calc.Add(src)); // Default max2Numbers = false, allowMoreThan1K = false, allowNegatives = false
    }
    catch (ExceptionNegative ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
}



