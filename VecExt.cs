namespace LinearAlgebra;


public static class VecExt
{
    public static Vecf ToVec(this float val) => new Vecf(val);

    public static Vecf ToVec(this float[] val) => new Vecf(val);

    public static Vecd ToVec(this double val) => new Vecd(val);

    public static Vecd ToVec(this double[] val) => new Vecd(val);

    public static Veci ToVec(this int val) => new Veci(val);

    public static Veci ToVec(this int[] val) => new Veci(val);
}