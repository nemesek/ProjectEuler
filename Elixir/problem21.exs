defmodule Problem21 do
  def solve do
    doubleSum = _solve(10000, [])
    |> reduce(0,fn(x,y) -> x + y end)

    div doubleSum,2
  end

  defp _solve(1, acc) do acc end
  defp _solve(n, acc ) do
    candidate = getSumOfDivisors(n)
    if(candidate > 9999 || candidate == n) do
      _solve(n-1,acc)
    else
      if(getSumOfDivisors(candidate) == n) do
        _solve(n-1,[n |[candidate|acc]])
      else
        _solve(n-1,acc)
      end
    end
  end

  def getSumOfDivisors(n) do
    getProperDivisors(n)
    |> reduce(0,fn(x,y) -> x + y end)
  end

  def getProperDivisors(n) do _getProperDivisors(n,trunc(:math.sqrt(n)),[]) end
  defp _getProperDivisors(_, 1, acc) do [1|acc] end
  defp _getProperDivisors(n, d, acc) do
    if rem(n,d) == 0 do
      list = [d|acc]
      o = div n,d
      if(d == o) do
        _getProperDivisors(n, d - 1, list)
      else
        _getProperDivisors(n, d - 1, [o|list])
      end
    else
      _getProperDivisors(n, d - 1, acc)
    end
  end

  def reduce([], value, _), do: value
  def reduce([head|tail], value, func), do: reduce(tail, func.(head,value), func)

end
