filterPrimes :: [Integer] -> Integer -> Integer -> [Integer]
filterPrimes acc n x
  | n `mod` x == 0 = filterPrimes(x:acc)(n `div` x) x -- This builds up the list of prime factors, and reduces n
  | n <= 2 = acc  -- base case
  | otherwise = filterPrimes acc n (x+1) -- ow, increment x

solve :: Integer
solve = foldr max 0  (filterPrimes [] 600851475143 3)
main = print solve
