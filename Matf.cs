
namespace LinearAlgebra;


public class Matf : Mat<float>
{
    public Matf(float[,] values) : base(values)
    {
    }

    public Matf(params float[][] values) : base(values)
    {
    }

    public override MatConstructor<float> matCtor => (values) => new Matf(values);

    public override VecConstructor<float> vecCtor => (values) => new Vecf(values);

    public override ScalarConstructor<float> zeroScalrCtor => () => 0;

    protected override Operation<float> opAdd => (f, s) => f+s;

    protected override Operation<float> opSub => (f, s) => f-s;

    protected override Operation<float> opMul => (f, s) => f*s;

    protected override Operation<float> opDiv => (f, s) => f/s;
}