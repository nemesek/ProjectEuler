defmodule Problem45 do
  def solve do _solve(287, 0, false) end
  # every hexagonal number is an odd triangular number
  # https://en.wikipedia.org/wiki/Hexagonal_number
  defp _solve(_, t, true) do t end
  defp _solve(n, _, false) do
    t = getTriangular n
    found = isPentagonal? t
    if found do
      _solve(n, t, true)
    else
      _solve(n+2, t, false)
    end
  end

  defp _getTriangular n do
    n * (n+1)/2
  end

  # note that if the inverse is an integer then
  # then n is Pentagonal https://en.wikipedia.org/?title=Pentagonal_number
  defp _isPentagonal? n do
    num = :math.sqrt(1 + 24 * n) + 1.0
    candidate = num / 6.0
    candidate == trunc(candidate)
  end
end
