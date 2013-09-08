import java.util.ArrayList;
import java.util.List;

import Utility.IO.*;
import Utility.Math;
import Utility.StopWatch;


public class Main {
	
	private static StopWatch _sw = new StopWatch();
	
	public static void main(String[] args) {
		
		User.Msg("Welcome to my example java project!!!");
		
		_sw.Start();
		
		CalculateAge();		
		
		_sw.Reset();
		
		CalculatePrimeNumber();
		
		User.Msg("Thanks " + User.Name() + " for using our program. Goodbye!");
		
	}
	
	private static void TimeStamp(){
		TimeStamp("");
	}
	
	private static void TimeStamp(String action){
		User.Msg(String.format("Total time spent %s  -  %s", action, _sw.Time()));
	}
	
	private static void CalculatePrimeNumber() {
		boolean quit = false;
		String action = "finding prime numbers";
		
		while(!quit){
			List<Integer> PrimeNumbers = new ArrayList<Integer>();
			
			User.Msg("Hey " + User.Name() + ", how many Prime Numbers do you want to find?");
			int count = User.getInt();
			PrimeNumbers.add(2);
			int currentNumber = 3;
					
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
