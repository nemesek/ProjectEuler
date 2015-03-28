defmodule Problem23 do
  def solve(n) do
    #28123
    upperBound = n - 1
    abundants = _getAbundants(upperBound, [])
    range = Enum.to_list 1..upperBound
    list = Enum.filter(range, fn(e) -> !doesPairExist(abundants,e) end)
    List.foldl(list, 0, fn(x,y) -> x + y end)
  end

  def doesPairExist(list,n) do _doesPairExist(list,n,0,Enum.count(list) - 1) end
  defp _doesPairExist(list,n,low,high) do
    if(low > high) do
      false
    else
      sum = Enum.at(list,low) + Enum.at(list,high)
      cond do
        sum == n -> true
        sum > n -> _doesPairExist(list,n,low,high - 1)
        sum < n -> _doesPairExist(list,n,low + 1, high)
      end
    end
  end

  def _getAbundants(1, acc) do acc end
  def _getAbundants(n, acc) do
    sum = getSumOfDivisors(n)
    if(n < sum) do
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
