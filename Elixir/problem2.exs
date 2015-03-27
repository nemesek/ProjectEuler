defmodule Problem2 do
  def solve(n) do _solve(n) end
  defp _solve(n) do
    generateFibs(n)
    |> Enum.filter(fn n -> _isEven(n) end)
    |> _sum(0)
  end

  def generateFibs(limit) do _generateFibs(limit,1,false,[]) end
  defp _generateFibs(_,_,true,[_ | tail]) do tail end
  defp _generateFibs(limit,n,false,acc) do
    nextFib = fib2(n)
    _generateFibs(limit, n+1, nextFib > limit, [nextFib | acc])
  end

  defp _sum([],acc) do acc end
  defp _sum([head | tail], acc) do _sum(tail, acc + head) end
  defp _isEven(n) do rem(n,2) == 0 end

  # genFibTerm is too slow
  # def genFibTerm(1) do 1 end
  # def genFibTerm(2) do 2 end
  # def genFibTerm(n) do genFibTerm(n-1) + genFibTerm(n-2) end

  def fib2(n) when is_integer(n) and n >= 0 do fib_iter(1,0,n) end

  # Tail recursive function using accumulating parameters a and b
  defp fib_iter(_,b,0) do b end
  defp fib_iter(a,b,m) do fib_iter(a+b,a,m-1) end
end
