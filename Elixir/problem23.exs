defmodule Problem23 do
  def solve(n) do
    #28123
    upperBound = n
    abundants = _getAbundants(upperBound, [])
    abunSums = _sumAllPairs(abundants,upperBound,[])
    range = Enum.to_list 1..upperBound
    list = Enum.filter(range, fn(e) -> !Enum.member?(abunSums,e) end)
    List.foldl(list, 0, fn(x,y) -> x + y end)
  end

  def _sumElementWithAll(n, list, upper) do
    Enum.map(list, fn(x) -> if(x + n < upper) do x + n end end)
    |> Enum.filter(fn(x) -> x != nil end)
  end

  def _sumAllPairs([],_, acc) do acc end
  def _sumAllPairs([head|tail],upper, acc) do
    l = _sumElementWithAll(head,tail,upper)
    _sumAllPairs(tail, upper, l ++ acc) # last arg which side is on ++ makes huge perf impact
  end

  def distinct(list) do _distinct(list,[]) end
  defp _distinct([], acc) do acc end
  defp _distinct([head|tail], acc) do
    if(!Enum.member?(acc,head)) do
      _distinct(tail, [head|acc])
    else
      _distinct(tail, acc)
    end
  end

  def _getAbundants(1, acc) do acc end
  def _getAbundants(n, acc) do
    sum = getSumOfDivisors(n)
    if(n <= sum) do
      _getAbundants(n-1, [n|acc])
    else
      _getAbundants(n-1, acc)
    end
  end

  def getSumOfDivisors(n) do
    getProperDivisors(n)
    |> List.foldl(0,fn(x,y) -> x + y end)
  end

  def getProperDivisors(n) do _getProperDivisors(n,trunc(:math.sqrt(n)),[]) end
  defp _getProperDivisors(_, 1, acc) do [1|acc] end
  defp _getProperDivisors(n, d, acc) do
    if rem(n,d) == 0 do
      o = div n,d
      if(d == o) do
        _getProperDivisors(n, d - 1, [d|acc])
      else
        _getProperDivisors(n, d - 1, [o|[d|acc]])
      end
    else
      _getProperDivisors(n, d - 1, acc)
    end
  end
end
