// https://www.reddit.com/r/TapTitans2/comments/7jbvzg/flipping_a_formula_in_excel/
// Formula posted by: CFMcGhee
// Author: cwesnow - CrimsonWolfSage

using System;
					
public class Program
{
	public static void Main()
	{
		// Input Book of Shadows
		int BookOfShadows = 750;
		
		// Input Desired Relics
		int DesiredRelics = 1000000000;
		
		Console.WriteLine(
			"Prestige at Stage: {0} for {1} relics.",
			CalculateStage(DesiredRelics, BookOfShadows),
			DesiredRelics);
	}
	
	static int CalculateStage(int Relics, int Book){
		double P = doB(Book);
		
		for(int x = 100; x < 9999;x++) {
			double B = Math.Pow(x,.48);
			double C = Math.Pow(1.21,B);
			double G = Math.Pow(x, 1.1) * 0.0000005+1;
			double I = Math.Pow(x, 1.005 * G);
			double J = Math.Pow(1.002, I);
			double K = (3*C) + (1.5 * (x-110)) + J;
			if( K*P > Relics ) return x;
		}
		return 1;
	}
	
	static double doB(int Book){
		double answer = 1.5*(.0001 * Book);
		answer = Math.Pow((1+answer), .5);
		return 1 + 0.05 * Math.Pow(Book, answer);
	}
	
	static int Floor(decimal x) { return (int)x; }
}
