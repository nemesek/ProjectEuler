total = 0
for x in range(1, 1000):
    if x % 3 == 0 or x % 5 == 0: 
        total += x
print(total)

#Slicker way on I saw on Project Euler -- Just learning Python
a, b = list(range(0, 1000, 3)), list(range(0, 1000, 5))
c = set(a+b)
print(sum(c))