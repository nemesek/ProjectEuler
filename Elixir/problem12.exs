defmodule Problem12 do
  def solve(numDiv) do _solve(1, 1, numDiv, false) end
  defp _solve(_, candidate, _, true) do candidate end
  defp _solve(n, _, numDiv, false) do
    candidate = getTriangularFast(n)
    _solve(n+1, candidate, numDiv, getNumDivisors(candidate) > numDiv)
  end

  def getNumDivisors(n) do _getNumDivisors(n,round(:math.sqrt(n)),0) end
  defp _getNumDivisors(_, 1, acc) do 2 + acc end
  defp _getNumDivisors(n, d, acc) do
    cond do
      # n == d -> _getNumDivisors(n, div(d,2), acc + 1)
      rem(n,d) == 0 -> _getNumDivisors(n, d - 1, acc + 2)
      true -> _getNumDivisors(n, d - 1, acc)
    end
  end

  def getTriangularFast(n) do div(n * (n+1),2) end
  defp getTriangular(n) do _getTriangular(n, 0) end
  defp _getTriangular(1, acc) do acc + 1 end
  defp _getTriangular(n, acc) do _getTriangular(n-1,acc + n) end  # tail call optimized


end

defmodule PrimeFactors do
  def of(n) do
    factors(n, div(n, 2)) #|> Enum.filter(&is_prime?/1)
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



defmodule Sieve do
  def eratosthenes(limit) do
    _eratosthenese(limit, :math.sqrt(limit), 2, HashSet.new)
  end

  defp _eratosthenese(limit, sqrtLimit, n, notPrimeSet) when n > sqrtLimit do
    addNumbersNotInHashSetToList(notPrimeSet, limit)
  end

  defp _eratosthenese(limit, sqrtLimit, n, notPrimeSet) do
    nPlus1 = n + 1

    if isInNotPrimes(n, notPrimeSet) do
      _eratosthenese(limit, sqrtLimit, nPlus1, notPrimeSet)
    else
      newNotPrimeHash = sieveMultipleOf(n, limit, notPrimeSet)
      _eratosthenese(limit, sqrtLimit, nPlus1, newNotPrimeHash)
    end
  end

  defp sieveMultipleOf(n, limit, notPrimeSet) do
    _sieveMultipleOf(n, limit, notPrimeSet, n + n)
  end

  defp _sieveMultipleOf(_, limit, notPrimeSet, notPrime) when notPrime > limit, do: notPrimeSet
  defp _sieveMultipleOf(n, limit, notPrimeSet, notPrime) do
    _sieveMultipleOf(n, limit, notPrimeSet |> Set.put(notPrime), notPrime + n)
  end

  defp isInNotPrimes(n, notPrimeSet), do: Enum.member?(notPrimeSet, n)

  defp addNumbersNotInHashSetToList(notPrimeSet, limit) do
    for n <- 2..limit, not isInNotPrimes(n, notPrimeSet), do: n
  end
end

#76576500
