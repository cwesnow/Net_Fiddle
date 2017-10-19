// Original Source Information
// Author: GitGub on Reddit
// Link: https://www.reddit.com/r/learnprogramming/comments/77a49n/c_help_refactoring_an_ugly_method_with_lots_of_if/

// Refactored using .NET Fiddle - https://dotnetfiddle.net/F8UcJW
using System;
					
public class Program
{
	static Random random = new Random();
	
	enum Bones { Femur, Tibia, Humerus, Radius }
	enum Gender { Male, Female}
	
	public static void Main()
	{
		
		for(int x = 0; x < 5; x++) {
			
			// Get Randome Values
			float length = randomLength();
			Bones bone = randomBone();
			Gender gender = randomGender();
			int age = randomAge();
			
		// Result
			Console.WriteLine("\nGender: {0}\nAge: {1}\nBone: {2}\nLength: {3}\nHeight: {4}",
						  gender, age, bone, length, calculateHeight(bone, length, gender, age));
		}
	}
	
	private static float calculateHeight(Bones bone, float boneLength, Gender gender, int age)
    {
        float height = 0;

		switch(bone) {
			
			case Bones.Femur:
				height = (gender == Gender.Male) ?
					69.089f + (2.238f * boneLength) - age * 0.06f : 61.412f + (2.317f * boneLength) - age * 0.06f;
				break;
			
			case Bones.Tibia:
				height = (gender == Gender.Male) ?
					81.688f + (2.392f * boneLength) - age * 0.06f : 72.572f + (2.533f * boneLength) - age * 0.06f;
				break;
			
			case Bones.Humerus:
				height = (gender == Gender.Male) ?
					height = 73.570f + (2.970f * boneLength) - age * 0.06f : 64.977f + (3.144f * boneLength) - age * 0.06f;
				break;
			
			case Bones.Radius:
				height = (gender == Gender.Male) ?
					80.405f + (3.650f * boneLength) - age * 0.06f : 73.502f + (3.876f * boneLength) - age * 0.06f;
				break;
			
			default: break;
		}
		return height;
    }
	
	private static float randomLength() { return (float)random.NextDouble()*3; }
	private static Bones randomBone() { return (Bones)random.Next(1,4); }
	private static Gender randomGender() { return (Gender)random.Next(0,2); } // 1,2 & 0,1 always gave the same gender
	private static int randomAge() { return random.Next(16, 99); }	
}
