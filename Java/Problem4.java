package Pad;

public class Problem4 {
	public void Solve()
	{
		long time1 = System.currentTimeMillis();
		int result = 0;
		int greatest = 0;
		for(int i = 999; i > 99; i--)
		{
			for(int j = 999; j > 99; j--)
			{
				result = i*j;
				if(IsPalindrome(result))
				{
					if(result > greatest)
					{
						greatest = result;
					}				
					

				}
				
			}
		}
		System.out.println("Program: " + this.toString());
		System.out.println("The largest palindrome: " + greatest);
		long time2 = System.currentTimeMillis();
		System.out.println("The time taken: " + (time2 - time1));
	
	}
	private boolean IsPalindrome(int x)
	{
		int temp = x;
		int compare = 0;
		int ones = temp % 10;
		ones *= 100000;
		temp = temp / 10;
		int tens = temp % 10;
		tens *= 10000;
		temp = temp /10;
		int hundred = temp % 10;
		hundred *=1000;
		temp = temp /10;
		int thousand = temp % 10;
		thousand *= 100;
		temp = temp /10;
		int tenThousand = temp %10;
		tenThousand *= 10;
		temp = temp /10;
		int hundredThousand = temp;
		//hundredThousand *= 100000;
		compare = hundredThousand + tenThousand + thousand + hundred + tens + ones;
		
		if(x == compare)
			return true;
		else
			return false;

		
	}

}
