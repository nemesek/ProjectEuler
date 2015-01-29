primeFactors :: [Integer] -> Integer -> Integer -> [Integer]
primeFactors acc n x
  | n `mod` x == 0 = primeFactors(x:acc)(n `div` x) x -- This builds up the list of prime factors, and reduces n
  | n <= 2 = acc  -- base case
  | otherwise = primeFactors acc n (x+1) -- ow, increment x

-- simple function that takes a list and returns a list
test1 :: [a] -> [a]
test1 a = a
-- function that takes a function that returns a list, and returns that list
test2 :: ([a] -> a -> a -> [a]) -> [a] -> a -> a -> [a]
test2 f x y z = f x y z
solve :: Integer
--solve = foldr max 0  (primeFactors [] 600851475143 3) -- Works
--solve = maximum (test2 (primeFactors) [] 600851475143 3)  -- Works
--solve = maximum (test1(primeFactors [] 600851475143 3))  -- Works
solve = maximum (primeFactors []  600851475143 3) -- Works
main = print solve
