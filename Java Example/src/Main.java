import java.util.ArrayList;
import java.util.List;

import Utility.IO.*;
import Utility.Math;
import Utility.StopWatch;


public class Main {
	
	private static StopWatch _sw = new StopWatch();
	
	public static void main(String[] args) {
		
		User.Msg("Welcome to my example java project!!!");
		
		CalculateAge();		
		
		TellMagicTrick();
		
		CalculatePrimeNumber();
		
		User.Msg("Thanks " + User.Name() + " for using our program. Goodbye!");
		
	}
	
	public static void TellMagicTrick(){
		if(User.askYesNo("So do you want to hear a magic trick?")){		
			try {
				User.waitMsg("Ok " + User.Name() + ", pick a 3-digit number where the first and last digits differ by 2 or more...");
				User.Msg("Consider the \"reverse\" number, obtained by reading it backwards.");
				Thread.sleep(5000);
				User.Msg("Subtract the smaller of these two numbers from the larger one.");
				Thread.sleep(5000);
				User.Msg("Add the result to its own reverse.");
				Thread.sleep(5000);
				User.waitMsg("Call me crazy but I think I know what it is.");
				
				if(User.askYesNo("Did you get 1089?"))
					User.Msg("Read your mind son.  Aint that sumpin?");
				else 
					User.Msg(User.Name() + " wow, that just means you suck math. lol its all good!");
				
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
	
	private static void TimeStamp(){
		TimeStamp("");
	}
	
	private static void TimeStamp(String action){
		User.Msg(String.format("Total time spent %s  -  %s", action, _sw.Time()));
	}
	
	private static void CalculatePrimeNumber() {
		_sw.Reset();
		boolean quit = false;
		String action = "finding prime numbers";
		
		while(!quit){
			List<Integer> PrimeNumbers = new ArrayList<Integer>();
			
			User.Msg("Hey " + User.Name() + ", how many Prime Numbers do you want to find?");
			int count = User.getInt();
			PrimeNumbers.add(2);
			int currentNumber = 3;
			
			if (count > 0)
				while(PrimeNumbers.size() != count){
					if(Math.isPrime(currentNumber)){
						PrimeNumbers.add(currentNumber);
					}
					currentNumber+=2;
				}
					
			User.Msg(PrimeNumbers.toString());
			
			quit = User.askQuit(action);
		}
		
		TimeStamp(action);
	}

	private static void CalculateAge() {
		_sw.Reset();
		boolean quit = false;
		String action = "calculating your friends age";
		while(!quit){
			User.Msg (User.Name() + " give me the age of one of your bros.");		
			Integer age = User.getInt();
			Integer days = age*365;
			if(User.askYesNo("Did you know that he is " + days + " days old."))
				User.Msg("Ha im calling bull fucking shit on that! Im a fucking computer, only I know this shit.");
			quit = User.askQuit(action);
		}	
		
		TimeStamp(action);
	}	
}
