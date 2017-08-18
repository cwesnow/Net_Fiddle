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
		
		// Shuffle Player Decks
		deck1.Shuffle();
		deck2.Shuffle();
		
		// Loop until no more cards to play
		while(!(deck1.isNull() || deck2.isNull())){
			flip(deck1,deck2);
			
			if(deck1.isNull()) deck1.Shuffle();
			if(deck2.isNull()) deck2.Shuffle();
		}
		
		// Display: End of Game
		Console.WriteLine("End of Game! {0} Wins!", deck2.isNull() ? "Player 1" : "Player 2");
	}
	
	// Round of Play - Each Player Draws a Card, Evaluates Win/Lose/War response
	static void flip(Deck deck1, Deck deck2) {
		
		// Cards played this round
		List<Card> played = new List<Card>();
		
		// Clumsy, but works
		Card card1 = deck1.Draw();
		played.Add(card1);
		
		Card card2 = deck2.Draw();
		played.Add(card2);
		
		// Compare flipped cards, 0 = Tie, 1 = Deck1 won, 2 = Deck2 lost
		int WinLoseDraw = checkCards(card1, card2);
		
		// Tie breaker, play until somebody wins or runs out of cards
		// Note: Check Rules for Reshuffle during War
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
		// Display: Current cards and result
		Console.WriteLine("{0,-5} vs {1,-5} {2,-5}",
						  card1, card2, WinLoseDraw == 1 ? "Win" : "Lose");
		
		// Winner gets all played cards for their use
		if(WinLoseDraw == 1) deck1.won(played); else deck2.won(played);
	}
	
	// Compare cards with each other
	// Note: a comparator method would be better
	static int checkCards(Card c1, Card c2){
		
		// Check for Nulls
		if( c1 == null && c2 == null) return 0;
		if (c1 == null || c2 == null) return (c1 != null) ? 1 : -1;

		// Equality check
		if( c1.worth == c2.worth ) return 0;
		
		// 1 = card 1 won, -1 = card 2 won
		return c1.worth > c2.worth ? 1 : -1;
	}
}

// Holds a deck of playing cards and the reserve cards from winnings
public class Deck {
	static Random rng = new Random();
	List<Card> deck = new List<Card>(); // Current
	List<Card> reserve = new List<Card>(); // Winnings
	
	// Diamonds, Hearts, Spades, Clubs
	Char[] faces = {'D', 'H', 'S', 'C'};
	int[] values = { 2,3,4,5,6,7,8,9,10,11,12,13,14}; // Jack, Queen, King, Ace
	
	// Constructor - Generates a classic 52 card deck
	public Deck(){
		foreach(Char face in faces) {
			foreach(int val in values) {
				deck.Add(new Card(face,val));
			}
		}
	}
	
	// Quick methods for IF statements, useful for checking private variables without making them public
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
	
	// Simply adds a list of Cards into the Reserve pile
	public void won(List<Card> winnings) {
		reserve.AddRange(winnings);
	}

}

// Simple Card
public class Card {
	public int worth;
	public char face;
	
	public Card(char face, int worth) {
		this.face = face;
		this.worth = worth;
	}
	
	// override method on ToString for custom Text Output
	public override string ToString(){
		return String.Format("{0}:{1}", face, worth);
	}

}
