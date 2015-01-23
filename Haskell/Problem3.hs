primeFactors :: [Integer] -> Integer -> Integer -> [Integer]
primeFactors acc n x
  | n `mod` x == 0 = primeFactors(x:acc)(n `div` x) x -- This builds up the list of prime factors
  | n <= 2 = acc
  | otherwise = primeFactors acc n (x+1)
solve :: Integer
solve = foldr max 0 $ primeFactors [] 600851475143 3
main = print solve
