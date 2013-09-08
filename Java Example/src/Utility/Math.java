package Utility;

public class Math {
	
	public static Boolean isPrime(Integer value){
		Boolean check = false;
		
		if (value == 2)
			check = true;
		else if (!(value == 1 || isEven(value))){
			check = true;
			
			int size = value / 2;
			
			for(int i = 3; i < size ; i += 2){
				if(value % i == 0)
					check = false;
			}
		}
	
		return check;
	}
	
	public static boolean isEven(Integer value){
		return value % 2 == 0;
	}
	
}
