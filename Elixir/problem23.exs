defmodule Problem23 do
  def sumAllPairs(list) do Enum.map(list, fn(x) -> _sumElementWithAll(x,list) end) end
  def _sumElementWithAll(n, list) do
    Enum.map(list, fn(x) -> x + n end)
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
