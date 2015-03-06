defmodule Problem12 do
  def solve(numDiv) do _solve(1, 1, numDiv, false) end
  defp _solve(_, candidate, _, true) do candidate end
  defp _solve(n, _, numDiv, false) do
    candidate = getTriangularFast(n)
    # d1+d2+(d1-1)*(d2-1)-1 where d1,d2 are the divisor count of the factors (i, i+1/2)
    #d1 = getNumDivisors(n)
    #d2 = getNumDivisors(div((n+1),2))
    #numDivisors = d1 + d2 + (d1 - 1) * (d2 - 1) - 1
    #isLarger = numDivisors > numDiv
    _solve(n+1, candidate, numDiv, getNumFactors(candidate) > numDiv)
    #_solve(n+1, candidate, numDiv, isLarger)
  end

  # def getNumDivisors(n) do _getNumDivisors(n,n,0) end
  # defp _getNumDivisors(_, 1, acc) do 1 + acc end
  # defp _getNumDivisors(n, d, acc) do
  #   cond do
  #     n == d -> _getNumDivisors(n, div(d,2), acc + 1)
  #     rem(n,d) == 0 -> _getNumDivisors(n, d-1, acc + 1)
  #     true -> _getNumDivisors(n, d-1, acc)
  #   end
  # end

  defp getNumFactors(n) do length(_factors(n, div(n, 2))) + 1 end
  defp _factors(1, _), do: [1]
  defp _factors(_, 1), do: [1]
  defp _factors(n, i) do
    if rem(n, i) == 0 do
      [i| _factors(n, i-1)]
    else
      _factors(n, i-1)
    end
  end


  def getTriangularFast(n) do div(n * (n+1),2) end
  defp getTriangular(n) do _getTriangular(n, 0) end
  defp _getTriangular(1, acc) do acc + 1 end
  defp _getTriangular(n, acc) do _getTriangular(n-1,acc + n) end  # tail call optimized


end

defmodule PrimeFactors do
  def of(n) do
    factors(n, div(n, 2)) |> Enum.filter(&is_prime?/1)
  end

  def factors(1, _), do: [1]
  def factors(_, 1), do: [1]
  def factors(n, i) do
    if rem(n, i) == 0 do
      [i|factors(n, i-1)]
    else
      factors(n, i-1)
    end
  end

  def is_prime?(n) do
    factors(n, div(n, 2)) == [1]
  end
end

#76576500
