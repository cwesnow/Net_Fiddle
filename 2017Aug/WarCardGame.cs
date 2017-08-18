using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("A Game of War");
		
		War.Start();
	}
}

public class War {
	
	public static void Start(){
		
		Deck deck1 = new Deck();
		Deck deck2 = new Deck();
		
		deck1.Shuffle();
		deck2.Shuffle();
		
		int x = 0;
		while(true){
			x++;
			Console.WriteLine("Round: {0,-3}", x);
			flip(deck1,deck2);
			
			if(deck1.isNull()) {
				if( deck1.hasReserve() ) { deck1.Shuffle(); } else { break; }
			}
			if(deck2.isNull()) {
				if( deck2.hasReserve() ) { deck2.Shuffle(); } else { break; }
			}
		}
		
		Console.WriteLine("End of Game! {0} Wins!", deck2.isNull() ? "Player 1" : "Player 2");
	}
	
	// Round of Play - Each Player Draws a Card, Evaluates Win/Lose/War response
	static void flip(Deck deck1, Deck deck2) {
		List<Card> played = new List<Card>();
		
		Card card1 = deck1.Draw();
		played.Add(card1);
		
		Card card2 = deck2.Draw();
		played.Add(card2);
		
		int WinLoseDraw = checkCards(card1, card2);
		
		while(WinLoseDraw == 0 && (!deck1.isNull() || !deck2.isNull())) {
			// Nested Ternary (conditional) ? true : false statements
			Console.WriteLine("{0,-5} vs {1,-5} {2,-5}",
							  card1, card2, "This means WAR!");
			
			card1 = deck1.Draw();
			played.Add(card1);
		
			card2 = deck2.Draw();
			played.Add(card2);
		
			card1 = deck1.Draw();
			played.Add(card1);
		
			card2 = deck2.Draw();
			played.Add(card2);
		
			WinLoseDraw = checkCards(card1, card2);
		}
		// Nested Ternary (conditional) ? true : false statements
		Console.WriteLine("{0,-5} vs {1,-5} {2,-5}",
						  card1, card2, WinLoseDraw == 1 ? "Win" : "Lose");
		if(WinLoseDraw == 1) deck1.won(played); else deck2.won(played);
	}
	
	static int checkCards(Card c1, Card c2){
		
		// Check for Nulls
		if( c1 == null && c2 == null) return 0;
		if (c1 == null || c2 == null) return (c1 != null) ? 1 : -1;

		// Equality check
		if( c1.worth == c2.worth ) return 0;
									   
		return c1.worth > c2.worth ? 1 : -1;
	}
}

public class Deck {
	static Random rng = new Random();
	List<Card> deck = new List<Card>(); // Current
	List<Card> reserve = new List<Card>(); // Winnings
	
	Char[] faces = {'D', 'H', 'S', 'C'};
	int[] values = { 2,3,4,5,6,7,8,9,10,11,12,13,14};
	
	// Constructor - Generates a classic 52 card deck
	public Deck(){
		foreach(Char face in faces) {
			foreach(int val in values) {
				deck.Add(new Card(face,val));
			}
		}
	}
	
	public bool isNull() { return deck.Count == 0 ? true : false; }
	public bool hasReserve() { return reserve.Count == 0 ? true : false; }
						  
	// Shuffles list of cards
	public void Shuffle() {
		deck.AddRange(reserve);
		reserve.RemoveRange(0, reserve.Count);
		
		for(int x = deck.Count-1; x > 0; x--) {
			int index = rng.Next(x+1);	// Random #
			Card card = deck[index];	// Temp Value
			deck[index] = deck[x];		// Swap 1
			deck[x] = card;				// Swap 2
		}
	}
	
	// Returns a card, after removing one from deck.  Returns null if no cards left
	public Card Draw() {
		if( deck.Count < 1 ) return null;
		Card card = deck[0];
		deck.RemoveAt(0);
		return card;
	}
	
	public Card Draw2() {
		Draw(); // Face Down Card
		return Draw();
	}
	
	public void won(List<Card> winnings) {
		reserve.AddRange(winnings);
	}
	
}

public class Card {
	public int worth;
	public char face;
	
	public Card(char face, int worth) {
		this.face = face;
		this.worth = worth;
	}
	
	public override string ToString(){
		return String.Format("{0}:{1}", face, worth);
	}

}
