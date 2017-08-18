using System;
					
public class Program
{
	public static void Main()
	{
		bool validated = false;
		string output = "output";
		string age = "";
		int AGEMIN = 18;
		int AGEMAX = 99;

		while(output != "quit") {
			Console.WriteLine("Text Input [\"quit\" to exit]: ");
			validated = getText( Console.ReadLine(), out output);
			if(validated) {
				Console.WriteLine("Valid Input is {0}", output);
			} else {
				Console.WriteLine("Invalid Input! Only Letters from {0} to {1} are allowed!!", (char)65, (char)90);
			}
		}
			
		while( age == "") {
			Console.WriteLine("Text Input [number between 18 and 99]:");
			validated = getNumber( Console.ReadLine(), out age, AGEMIN, AGEMAX);
			if(!validated) { 
				Console.WriteLine("Invalid Input! Only Numbers from {0} to {1} allowed!", AGEMIN, AGEMAX);
			}
		}
	}
	
	// Alternatively, can do this
	// (char)65 to 90 - UpperCase Letters
	// (char)97 to 122 - LowerCase Letters
	// if( (int)c < 65 || (int)c > 90) { //Invalid }
    public static bool getText(string textIn, out string textOut) {
		textOut = "";
        string validation = "abcdefghijklmnopqrstuvwxyz";
        char[] chars = textIn.ToCharArray();
        foreach(Char c in chars) {
            if( !validation.Contains(c.ToString().ToLower()) ) {
                return false;
			}
        }
        textOut = textIn;
        return true;
    }
	

	public static bool getNumber(string textIn, out string textOut, int MIN, int MAX) {
		textOut = "";
		int x = 0;
		if( int.TryParse(textIn, out x) && x >= MIN && x <= MAX ) {
			textOut = x.ToString();
			return true;
		}else {
			return false;
		}
	}
}
