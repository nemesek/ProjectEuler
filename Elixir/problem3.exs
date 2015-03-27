defmodule Problem3 do
  def solve(n) do
    primeFactors(n) |> _head
  end

  defp _head([head|tail]) do head end

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
