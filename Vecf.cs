
namespace LinearAlgebra;


public class Vecf : Vec<float>
{
    public Vecf(params float[] values):base(values){}
    public Vecf(Vec<float> values, params float[] values2):base(values, values2){}
    
    protected override Operation<float> opAdd => (f, s) => f + s;

    protected override Operation<float> opSub => (f, s) => f - s;

    protected override Operation<float> opMul => (f, s) => f * s;

    protected override Operation<float> opDiv => (f, s) => f / s;

    protected override VecConstructor<float> vecCtor => (values) => new Vecf(values);
}