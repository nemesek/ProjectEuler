#By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
#What is the 10 001st prime number?
import math
from datetime import datetime

startTime = datetime.now()

def isPrime(n):
    sqrt = math.floor(math.sqrt(n))
    if len(list(filter(lambda x : n % x == 0, range(2, sqrt + 1)))) > 0: return False
    return True

count = 0
number = 2

while count < 10001:
    if isPrime(number): 
        count += 1
    number +=1

print(number - 1)
print(datetime.now() - startTime)





