reverseInt :: Integer -> Integer
reverseInt = read . reverse . show

solve = maximum [if p == reverseInt p then p else 0 | x <-[100..999], y <- [x..999], let p = x * y]


-- this is soln I got from the Hasekll wiki -- seems to be a lot faster than mine
solve' = maximum [x | y <-[100..999], z <- [y..999], let x = y*z, let s = show x, s == reverse s]


solve2 = maximum [p | x <- [100..999], y <- [x..999], let p = x * y, p == reverseInt p]
