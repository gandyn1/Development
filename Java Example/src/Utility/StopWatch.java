package Utility;

import java.util.Date;

public class StopWatch {
	
	private Date _Start = null;
	private int _TotalMilliseconds = 0;
	
	public void Start(){
		if(_Start == null)
			_Start = new Date();
	}
	
	public void Stop(){
		_TotalMilliseconds += timeElapsed();
		_Start = null;
	}
	
	public void Reset(){
		_TotalMilliseconds = 0;
		_Start = new Date();
	}
	
	public String Time(){
		int milliseconds = _TotalMilliseconds + timeElapsed();			
		int seconds = (int) (milliseconds / 1000) % 60 ;
		int minutes = (int) ((milliseconds / (1000*60)) % 60);
		int hours   = (int) ((milliseconds / (1000*60*60)) % 24);
		
		return String.format("%d:%d:%d.%d",hours,minutes,seconds,milliseconds);
	}
	
	private int timeElapsed(){
		return (_Start == null) ? 0 : (int) ((new Date()).getTime() - _Start.getTime());
	}
}
