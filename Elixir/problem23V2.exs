defmodule Problem23 do
  def solve do solve(20162) end # ~ 110 seconds
  def solve(n) do
    # correct answer is 4179871
    #28123 ~ 288 seconds, but wrong anser of 4207994 - the diff is the last number
    # 10001 ~15 seconds
    # 20161
    upperBound = n - 1
    abundants = _getAbundants(upperBound, [])
    abunSums = _sumAllPairs(abundants,upperBound,[])
    # sortedSums = Enum.sort(abunSums)
    range = Enum.to_list 1..upperBound
    # list = Enum.filter(range, fn(e) -> binarySearch(sortedSums,e) == -1 end)
    list = Enum.filter(range, fn(e) -> !Enum.member?(abunSums,e) end)
    List.foldl(list, 0, fn(x,y) -> x + y end)
  end

  def _sumElementWithAll(n, list, upper) do
    Enum.map(list, fn(x) -> if(x + n < upper) do x + n end end)
    |> Enum.filter(fn(x) -> x != nil end)
  end

  def _sumAllPairs([],_, acc) do acc end
  def _sumAllPairs([head|tail],upper, acc) do
    l = _sumElementWithAll(head,[head|tail],upper)
    _sumAllPairs(tail, upper, l ++ acc) # last arg which side is on ++ makes huge perf impact
  end

  # def binarySearch(list, key) do _binSearch(list,key,0,Enum.count(list) - 1) end
  # defp _binSearch(list,key,low,high) do
  #   if(high < low) do
  #     -1
  #   else
  #     mid = div(low + high,2)
  #     item = Enum.at(list,mid)
  #     cond do
  #       key < item -> _binSearch(list,key,low,mid - 1)
  #       key > item -> _binSearch(list,key,mid + 1, high)
  #       true -> mid
  #     end
  #   end
  # end

  # def distinct(list) do _distinct(list,[]) end
  # defp _distinct([], acc) do acc end
  # defp _distinct([head|tail], acc) do
  #   if(!Enum.member?(acc,head)) do
  #     _distinct(tail, [head|acc])
  #   else
  #     _distinct(tail, acc)
  #   end
  # end

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
