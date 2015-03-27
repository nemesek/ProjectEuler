defmodule Problem12 do
  def solve(numDiv, fun) do _solve(1, numDiv, fun, false, 1) end
  def solveSlow(numDiv) do solve(numDiv, fn x -> getNumDivisors(x) end) end
  def solveFast(numDiv) do solve(numDiv, fn x -> getNumFactors(x) end) end
  defp _solve(_, _, _,true, acc) do acc end
  defp _solve(n, numDiv, fun, false, acc) do
    acc = acc + n + 1
    _solve(n+1, numDiv, fun, fun.(acc) > numDiv, acc)
  end

  # slower
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
  # my implementation of tau to get num divisors
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
