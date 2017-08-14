using System;
					
public class Program
{
	public static void Main()
	{
		// 10 Questions
		string[] questions = new string[10]{
			"Question 1:",
			"Question 2:",
			"Question 3:",
			"Question 4:",
			"Question 5:",
			"Question 6:",
			"Question 7:",
			"Question 8:",
			"Question 9:",
			"Question 10:"
		};
	
		// 10 Answers
		string[] answers = new string[10]{
			"A",
			"B",
			"C",
			"D",
			"E",
			"T",
			"F",
			"T",
			"F",
			"T"
		};
		
		// Track correct answers
		bool[] correct = new bool[10];
			
		Console.WriteLine("Begin Test");
		
		for(int x = 0; x < questions.Length; x++){
			Console.WriteLine(questions[x]);
			if( Console.ReadLine() == answers[x]) { correct[x] = true;}
		}
		
		int score = 0;
		foreach(bool TF in correct) { if(TF == true) score++;}
		Console.WriteLine("Score: {0}", score);
									 
		Console.WriteLine("Missed Questions");
		
		for(int x = 0; x < questions.Length; x++) {
			if(!correct[x]) {
				Console.WriteLine(questions[x]);
				if( Console.ReadLine() == answers[x]) {
					correct[x] = true;
				}
			}
		}

		score = 0;
		foreach( bool TF in correct) { if(TF == true) score++;}
		Console.WriteLine("Score: {0}", score);

	}
}
