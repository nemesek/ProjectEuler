package Pad;

public class Problem2 {

	public void Solve()
	{
		long time1 = System.currentTimeMillis();
		int total = 0;
		int f1 = 1;
		int f2 = 1;
		int nMinus2 = f1;
		int nMinus1 = f2;
		int[] fibNumbers = new int[5000000];
		int index = 2;
		fibNumbers[0] = f1;
		fibNumbers[1] = f2;
		double sum = 0;
		int fn = 0;
 		while(fn < 4000000)
		{
			fn = nMinus1 + nMinus2;
			//total += fn;
			fibNumbers[index] = fn;
			index++;
			total++;
			nMinus2 = nMinus1;
			nMinus1 = fn;
			
			
		}
 		
 		for(int i=0; i < fibNumbers.length; ++i)
 		{
 			
 			if(fibNumbers[i] > 0)
 			{
 				//System.out.println(fibNumbers[i]);
 				if(fibNumbers[i] % 2 ==0)
 				{
 					sum+= fibNumbers[i]; 					
 				
 				}
 				
 			}
 			
 		}
 		System.out.println("Program: " + this.toString());
 		System.out.println("Sum total: " + sum);
 		long time2 = System.currentTimeMillis();
 		System.out.println("The time taken: " + (time2 - time1));
 		
 		
		
		
		
	}
}
