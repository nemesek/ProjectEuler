package Pad;

public class Problem3 {
	
	public void Solve(long x)
	{
		long time1 = System.currentTimeMillis();
		double sqrt = StrictMath.sqrt(x);
		int value = (int)StrictMath.floor(sqrt);
		for(int i = value; i > 0; --i)
		{
			if(x % i == 0)
			{
				if(i == 1)
				{
					System.out.println("The number: " + x + " is prime");
					break;
				
				}
				//it is a divisor 
				//check if prime
				if(IsPrime(i))
				{
					System.out.println("Program: " + this.toString());
					System.out.println("The largest prime factor: " + i);
					long time2 = System.currentTimeMillis();
					System.out.println("The time taken: " + (time2 - time1));
					i = 0;
					
				}
			
			}

			
		}
			
		
	}
	private boolean IsPrime(int x)
	{
		double sqrt = StrictMath.sqrt(x);
		int value = (int)StrictMath.floor(sqrt);
		for(int i = 2; i <= value; ++i)
		{
			if(x % i == 0)
			{
				return false;
			}
		}
		return true;
		
	}

}
