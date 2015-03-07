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
end
#:timer.tc(Problem12,:solve,[500])

#76576500
