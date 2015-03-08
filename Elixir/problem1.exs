defmodule Problem1 do
  def solve(n) do _generateList(n, &(rem(&1,3) == 0 || rem(&1,5) == 0), []) |> _sum(0) end
  defp _generateList(1, _, acc) do acc end
  defp _generateList(n, condition, acc) do
    if condition.(n) do
      _generateList(n-1, condition, [n | acc])
    else
      _generateList(n-1, condition, acc)
    end
  end
  defp _sum([], acc) do acc end
  defp _sum([head | tail], acc) do _sum(tail, acc + head) end

end
