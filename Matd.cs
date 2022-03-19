
namespace LinearAlgebra;


public class Matd : Mat<double>
{
    public Matd(double[,] values) : base(values)
    {
    }

    public Matd(params double[][] values) : base(values)
    {
    }
    
    public override MatConstructor<double> matCtor => (values) => new Matd(values);

    public override VecConstructor<double> vecCtor => (values) => new Vecd(values);

    public override ScalarConstructor<double> zeroScalrCtor => () => 0;

    protected override Operation<double> opAdd => (f, s) => f+s;

    protected override Operation<double> opSub => (f, s) => f-s;

    protected override Operation<double> opMul => (f, s) => f*s;

    protected override Operation<double> opDiv => (f, s) => f/s;
}