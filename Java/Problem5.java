package Pad;



public class Problem5 {
	public void Solve()
	{
		long time1 = System.currentTimeMillis();
		int num = 380;
		while(!isDivisible(num))
		{
			num += 20;
		}
		System.out.println("Program: " + this.toString());
		System.out.println("The smallest number: " + num);
		long time2 = System.currentTimeMillis();
		System.out.println("The time taken: " + (time2 - time1));

		
	
	}
	private boolean isDivisible(int x)
	{
		for (int i = 19; i > 10; i--)
		{
			if(!(x % i == 0))
			{
				return false;
			}
			
		}
		return true;
		
	}

}
