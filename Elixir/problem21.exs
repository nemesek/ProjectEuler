defmodule Problem21 do
  def solve do
    doubleSum = _buildAmicableNumbers(10000, [])
    |> List.foldl(0, fn(x,y) -> x + y end)
    div doubleSum,2
  end

  defp _buildAmicableNumbers(1, acc) do acc end
  defp _buildAmicableNumbers(n, acc ) do
    candidate = getSumOfDivisors(n)
    if(candidate > 9999 || candidate == n) do
      _buildAmicableNumbers(n-1,acc)
    else
      if(getSumOfDivisors(candidate) == n) do
        _buildAmicableNumbers(n-1,[n |[candidate|acc]])
      else
        _buildAmicableNumbers(n-1,acc)
      end
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
