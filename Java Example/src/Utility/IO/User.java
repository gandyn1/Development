package Utility.IO;

import java.util.Scanner;

public class User {
	
	private static String _Name = null;
	
	public static String Name(){
		if(_Name == null){
			if(askYesNo("Hey man can I ask a quick question?")){
				Msg("What the fuck is your name?  I just cant remember...");
				_Name = getString();
				waitMsg(_Name + ", thats it! Im sorry man, im fucking terrible with names.");
			}else{
				Msg("Fuck you then bro!");
				_Name = "Asshole";
			}	
		}
		
		return _Name;
	}
	
	public static boolean askYesNo(String question){
		Msg (question);
		
		String answer = getString();
		answer = answer.toUpperCase();
		
		return answer.compareTo("Y") == 0 ||
		   answer.contains("YES") ||
		   answer.compareTo("T") == 0 ||
		   answer.contains("TRUE") ||
		   answer.contains("SURE") ||
		   answer.contains("YEA");
	}
	
	public static boolean askQuit(){
		return askQuit("");
	}
	
	public static boolean askQuit(String action){
		boolean response = askYesNo(Name() + " should we quit " + action + "?");
		
		if(response)
			User.Msg("Ok cool.  That shit was getting old anyway.");
		else
			User.Msg("Ok well then we must continue " + action + " with our cocks out!");
		
		return response;
	}
	
	public static void waitMsg(String value){
		Msg(value);
		getString();
	}
	
	public static String getString(){
		Scanner reader = new Scanner(System.in);
		return reader.nextLine();
	}
	
	public static Integer getInt(){

		Integer value = 0;
		boolean check = false;
		
		while(check == false){
			try{
				Scanner reader = new Scanner(System.in);
				value = reader.nextInt();
				check = true;
			}catch(Exception ex){
				User.Msg("You fucked up bro.  Type a number!");
			}	
		}
		
		return value;
	}

	public static void Msg (String value){
		
		System.out.println(value);	
	}
}
