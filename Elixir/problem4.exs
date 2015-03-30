#A palindromic number reads the same both ways.
#The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
#Find the largest palindrome made from the product of two 3-digit numbers.

defmodule Problem4 do
  def solve(n) do
    range = Enum.to_list 1..n
    list = _mulAllPairs(range,[])
    filtered = Enum.filter(list,fn(x) -> isPalindrome?(x) end)
    findMax(filtered,0)
  end

  def findMax([],acc) do acc end
  def findMax([head|tail], acc) do
    if(head > acc) do
      findMax(tail,head)
    else
      findMax(tail,acc)
    end
  end

  def isPalindrome?(num) do
    numStr = Integer.to_string(num)
    if(numStr == String.reverse(numStr)) do
      true
    else
      false
    end
  end

  def _mulAllPairs([], acc) do acc end
  def _mulAllPairs([head|tail], acc) do
    l = _mulElementWithAll(head,[head|tail])
    _mulAllPairs(tail, l ++ acc) # last arg which side is on ++ makes huge perf impact
  end

  def _mulElementWithAll(n, list) do
    Enum.map(list, fn(x) -> x * n end)
    #|> Enum.filter(fn(x) -> x != nil end)
  end

end
