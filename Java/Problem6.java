package Pad;

public class Problem6 {
	public void Solve()
	{
		long time1 = System.currentTimeMillis();
		int x = SumOfSquares();
		int y = SquareOfSum();
		System.out.println("Program: " + this.toString());
		System.out.println("The sum of squares: " + x);
		System.out.println("The square of sums: " + y);
		System.out.println("Difference: " + (y - x));
		long time2 = System.currentTimeMillis();
		System.out.println("The time taken: " + (time2 - time1));
	}
	
	private int SumOfSquares()
	{
		int total = 0;
		for(int i = 1; i < 101; ++i)
		{
			total += i*i;
		}
		return total;
	}
	private int SquareOfSum()
	{
		int num = 100;
		int total = num*(num +1)/2;
		total *= total;
		return total;
	}
	

}
