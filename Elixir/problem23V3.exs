defmodule Problem23 do
  def solve do solve(20162) end # ~ correct ~ 34 seconds
  def solve(n) do
    # correct answer is 4179871
    # 10001 ~6 seconds but some sort of off by one error
    # 20161
    upperBound = n - 1
    abundants = _getAbundants(upperBound, [])
    range = Enum.to_list 1..upperBound
    abunSums = _filterOut(abundants,upperBound, range)
    List.foldl(abunSums, 0, fn(x,y) -> x + y end)
  end

  def _sumElementWithAll(n, list, upper) do
    Enum.map(list, fn(x) -> if(x + n < upper) do x + n end end)
    |> Enum.filter(fn(x) -> x != nil end)
  end

  def _filterOut([],_, acc) do acc end
  def _filterOut([head|tail],upper, acc) do
    l = _sumElementWithAll(head,[head|tail],upper)
    keep = Enum.filter(acc, fn(e) -> !Enum.member?(l,e) end)
    _filterOut(tail, upper, keep) # last arg which side is on ++ makes huge perf impact
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
