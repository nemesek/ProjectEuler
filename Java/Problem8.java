package Pad;


import java.io.File;
import java.io.FileInputStream;


public class Problem8 {
	public void Solve()
	{
		long time1 = System.currentTimeMillis();
		
		//string x = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

		int greatest = 0;
		File file = new File("C:\\Users\\Socrates\\Desktop\\Problem8.txt");
		int ch;
		StringBuffer strContent = new StringBuffer("");
		int index = 0;
		try
		{
			FileInputStream fin = new FileInputStream(file);

			int total = 0;
			while((ch = fin.read()) != -1)
			{
				strContent.append((char)ch);

			}
			while(index < 996)
			{

				Character c1 = new Character(strContent.charAt(index));
				Character c2 = new Character(strContent.charAt(index+1));
				Character c3 = new Character(strContent.charAt(index+2));
				Character c4 = new Character(strContent.charAt(index+3));
				Character c5 = new Character(strContent.charAt(index+4));
				
				String s1 = c1.toString();
				String s2 = c2.toString();
				String s3 = c3.toString();
				String s4 = c4.toString();
				String s5 = c5.toString();
				int val1 = Integer.parseInt(s1);
				int val2 = Integer.parseInt(s2);
				int val3 = Integer.parseInt(s3);
				int val4 = Integer.parseInt(s4);
				int val5 = Integer.parseInt(s5);
				total = val1 * val2 * val3 * val4 * val5;
				if(total > greatest)
					greatest = total;
				index++;
				
			}
			
		}
		catch(Exception e)
		{
			System.out.println("Uh Oh");
		}
		System.out.println("Program: " + this.toString());
		System.out.println("The greatest " + greatest);
		long time2 = System.currentTimeMillis();
		System.out.println("The time taken: " + (time2 - time1));

	}
	

	

}
