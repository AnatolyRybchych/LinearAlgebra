
namespace LinearAlgebra;


public class Veci : Vec<int>
{
    public Veci(params int[] values):base(values){}
    public Veci(Vec<int> values, params int[] values2):base(values, values2){}
    
    protected override Operation<int> opAdd => (f, s) => f + s;

    protected override Operation<int> opSub => (f, s) => f - s;

    protected override Operation<int> opMul => (f, s) => f * s;

    protected override Operation<int> opDiv => (f, s) => f / s;

    protected override VecConstructor<int> vecCtor => (values) => new Veci(values);
}