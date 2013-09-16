#A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
#Find the largest palindrome made from the product of two 3-digit numbers.

def findMaxPalindrome(seq):
    max = 0
    for x,y in ((x,y) for x in seq for y in seq): 
        if str(x*y) == str(x*y)[::-1]:
            if x*y > max:
                max = x*y
    return max


seq = range(100,1000)
print(findMaxPalindrome(seq))



                    