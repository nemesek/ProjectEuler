reverseInt :: Integer -> Integer
reverseInt = read . reverse . show

reverseIntToString :: Integer -> String 
reverseIntToString = reverse . show

reverseInt' :: Integer -> Integer
reverseInt' 0 = 0
reverseInt' n = mod n 10 * 10^place + reverseInt' (div n 10)
	where
		n' = fromIntegral n
		place = (floor . logBase 10) n'

solve = maximum [if p == reverseInt p then p else 0 | x <-[100..999], y <- [x..999], let p = x * y] -- slow

-- this is soln I got from the Hasekll wiki -- seems to be a lot faster than mine
solve' = maximum [x | y <-[100..999], z <- [y..999], let x = y*z, let s = show x, s == reverse s] -- fast

solve2 = maximum [p | x <- [100..999], y <- [x..999], let p = x * y, p == reverseInt p] -- slow

solve3 = maximum [p | x <- [100..999], y <- [x..999], let p = x * y, show p == reverseIntToString p] -- fast

solve4 = maximum [p | x <- [100..999], y <- [x..999], let p = x * y, show p == reverse (show p)]	-- fast

solve5 = maximum [p | x <- [100..999], y <- [x..999], let p = x * y, p == reverseInt' p] -- slow