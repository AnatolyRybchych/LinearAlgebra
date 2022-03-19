
namespace LinearAlgebra;


public class Vecd : Vec<double>
{
    public Vecd(params double[] values):base(values){}
    public Vecd(Vec<double> values, params double[] values2):base(values, values2){}
    
    protected override Operation<double> opAdd => (f, s) => f + s;

    protected override Operation<double> opSub => (f, s) => f - s;

    protected override Operation<double> opMul => (f, s) => f * s;

    protected override Operation<double> opDiv => (f, s) => f / s;

    protected override VecConstructor<double> vecCtor => (values) => new Vecd(values);
}