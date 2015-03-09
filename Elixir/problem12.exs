defmodule Problem12 do
  def solve(numDiv) do _solve(1, numDiv, false, 1) end
  defp _solve(_, _, true, acc) do acc end
  defp _solve(n, numDiv, false, acc) do
    acc = acc + n + 1
    _solve(n+1, numDiv, getNumDivisors(acc) > numDiv, acc)
  end

  def getNumDivisors(n) do _getNumDivisors(n,trunc(:math.sqrt(n)),0) end
  defp _getNumDivisors(_, 1, acc) do 2 + acc end
  defp _getNumDivisors(n, d, acc) do
    if rem(n,d) == 0 do
      _getNumDivisors(n, d - 1, acc + 2)
    else
      _getNumDivisors(n, d - 1, acc)
    end
  end

  # faster
  def solve2(numDiv) do _solve2(1, numDiv, false, 1) end
  defp _solve2(_, _, true, acc) do acc end
  defp _solve2(n, numDiv, false, acc) do
    acc = acc + n + 1
    _solve2(n+1, numDiv, getNumFactors(acc) > numDiv, acc)
  end

  # my implementation of tau to get num factors
  def getNumFactors(n) do
    primeFactors(n)
    |> Enum.group_by(fn x -> x end)
    |> Dict.values
    |> Enum.map(fn x -> length(x) + 1 end)
    |> List.foldr(1, fn (x,y) -> x * y end)
  end

  defp primeFactors(n) do _primeFactors(n,2,[]) end
  defp _primeFactors(1, _, acc) do acc end
  defp _primeFactors(2, _, acc) do [2|acc] end
  defp _primeFactors(n, d, acc) do
    if(rem(n,d) == 0) do
      _primeFactors(div(n,d), d, [d|acc])
    else
      _primeFactors(n, d + 1, acc)
    end
  end
end
#:timer.tc(Problem12,:solve,[500])

#76576500
