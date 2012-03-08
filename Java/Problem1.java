package Pad;

public class Problem1 {
	public void Solve()
	{
		long time1 = System.currentTimeMillis();
		int total = 0;
		for(int i=0; i< 1000; ++i)
		{
			if(i % 3 ==0)
			{
				total+=i;
			}
			if(i % 5 ==0)
			{
				total+=i;
			}
			if((i % 3 == 0) && (i % 5 ==0))
				total -= i;
		}
		long time2 = System.currentTimeMillis();
		System.out.println("Program: " + this.toString());
		System.out.println(total);;
		System.out.println("The time taken: " + (time2 - time1));
		
	}

}
