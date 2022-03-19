

namespace LinearAlgebra;

public delegate T Operation<T>(T f, T s);


public abstract class VecType<T>
{
    protected abstract Operation<T> opAdd { get; }
    protected abstract Operation<T> opSub { get; }
    protected abstract Operation<T> opMul { get; }
    protected abstract Operation<T> opDiv { get; }
}
