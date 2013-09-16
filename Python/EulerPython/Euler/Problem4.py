#A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
#Find the largest palindrome made from the product of two 3-digit numbers.

import math

# returns a Cartesian product of the list passed in
def findPalindromes(seq):
    l = []
    for x,y in ((x,y) for x in seq for y in seq): 
        if isPalindrome(x*y):
            l.append(x*y)
    return l



def isPalindrome(number):
    #Faster way I found on Euler, basically compare string with string printed in reverse
    if str(number) == str(number)[::-1]: return True
    return False
    #numDigits = int(math.floor(math.log10(number) + 1))
    #half = int(numDigits / 2)
    #count = 0
    #pre = 0
    #post = 0

    #while count < half:
    #    digit = int(number % 10)
    #    number /= 10
    #    post += int(math.pow(10, count) * digit)
    #    count += 1
    
    #if numDigits % 2 != 0:
    #    number /= 10

    #count -= 1

    #while count >= 0:
    #    digit = int(number % 10)
    #    number /= 10
    #    pre += int(math.pow(10, count) * digit)
    #    count -= 1

    #if pre == post: return True
    #return False


seq = range(100,1000)
palindromes = sorted(list(findPalindromes(seq)))
print(palindromes[-1])



                    