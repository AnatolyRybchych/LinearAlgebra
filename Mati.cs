
namespace LinearAlgebra;


public class Mati : Mat<int>
{
    public Mati(int[,] values) : base(values)
    {
    }

    public Mati(params int[][] values) : base(values)
    {
    }

    public override MatConstructor<int> matCtor => (values) => new Mati(values);

    public override VecConstructor<int> vecCtor => (values) => new Veci(values);

    public override ScalarConstructor<int> zeroScalrCtor => () => 0;

    protected override Operation<int> opAdd => (f, s) => f+s;

    protected override Operation<int> opSub => (f, s) => f-s;

    protected override Operation<int> opMul => (f, s) => f*s;

    protected override Operation<int> opDiv => (f, s) => f/s;
}