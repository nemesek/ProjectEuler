package Pad;

public class Problem9 {
	public void Solve()
	{
		int[] squares = new int[2000];
		int result = 0;
		double total = 0;
		for(int i = 1; i < 2001 ; ++i)
		{
			result = i*i;
			//System.out.println(result);
			squares[i-1] = result;
		
		}
		
		for(int i=0; i < squares.length; ++i)
		{
			for(int j=0; j < squares.length; ++j)
			{
				for(int k = 0; k < squares.length; ++k)
				{
					if(squares[i] == squares[j] + squares[k])
					{
						System.out.println("Match " + squares[i] + " " + squares[j] + " " + squares[k]);
						double a = Math.sqrt(squares[i]);
						double b = Math.sqrt(squares[j]);
						double c = Math.sqrt(squares[k]);
						
						total = a + b + c;
						if(total == 1000.0)
						{
							System.out.println("Found it");
							i = squares.length + 1;
							j = squares.length + 1;
							k = squares.length + 1;
							System.out.println("Total is: " + a*b*c);
							
						}
					}
				}
			}
		}
	}

}
