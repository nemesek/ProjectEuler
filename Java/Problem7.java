package Pad;

public class Problem7 {
	public void Solve()
	{
		long time1 = System.currentTimeMillis();
		int total = 1;
		int num = 2;
		while(total < 10002)
		{
			if(IsPrime(num))
			{
				total +=1;
			}
			if(total == 10002)
			{
				break;
			}
			num +=1;
			
		}
 		System.out.println("Program: " + this.toString());
 		System.out.println("The 1001st prime: " + num);
 		long time2 = System.currentTimeMillis();
 		System.out.println("The time taken: " + (time2 - time1));
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
