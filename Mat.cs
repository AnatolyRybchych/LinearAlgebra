
namespace LinearAlgebra;

public delegate Mat<T> MatConstructor<T>(T[,] values);
public delegate T ScalarConstructor<T>();

public abstract class Mat<T>:VecType<T>
{
    public abstract MatConstructor<T> matCtor { get; }
    public abstract VecConstructor<T> vecCtor { get; }
    public abstract ScalarConstructor<T> zeroScalrCtor { get; }

    public T[,] Values { get; private set;}
    public Mat(T[,] values)
    {
        Values = values;
    }

    public Mat(params T[][] values)
    {
        int maxLen = 0;
        foreach (var val in values)
            if(val.Length > maxLen) maxLen = val.Length;
        
        Values = new T[values.Length, maxLen];
        
        for(int y = 0; y < values.Length; y++)
        {
            for (int x = 0; x < maxLen; x++)
            {
                if(values[y].Length <= x) break;
                Values[y, x] = values[y][x]; 
            }
        }
    }


    public Mat<T> Sub(Mat<T> second)
    {
        if(Values.Length != second.Values.Length 
        || Values.GetLength(0) != second.Values.GetLength(0)) 
            throw new Exception("matrix Operands should have same volume");

        Mat<T> res = matCtor(Values);
        for(int y = 0; y < res.Values.GetLength(0); y++)
        for(int x = 0; x < res.Values.GetLength(1); x++)
            res.Values[y,x] = opSub(res.Values[y,x], second.Values[y,x]);
        
        return res;
    }

    public Mat<T> Sub(T second)
    {
        Mat<T> res = matCtor(Values);
        for(int y = 0; y < res.Values.GetLength(0); y++)
        for(int x = 0; x < res.Values.GetLength(1); x++)
            res.Values[y,x] = opSub(res.Values[y,x], second);
        
        return res;
    }

    public Mat<T> SetSub(Mat<T> second)
    {
        Values = Sub(second).Values;
        return this;
    }

    public Mat<T> SetSub(T second)
    {
        Values = Sub(second).Values;
        return this;
    }

    public Mat<T> SetAdd(Mat<T> second)
    {
        Values = Add(second).Values;
        return this;
    }


    public Mat<T> SetAdd(T second)
    {
        Values = Add(second).Values;
        return this;
    }

    public Mat<T> SetMul(Mat<T> second)
    {
        Values = Mul(second).Values;
        return this;
    }

    public Mat<T> SetMul(Vec<T> second)
    {
        Values = Mul(second).Values;
        return this;
    }

    public Mat<T> SetMul(T second)
    {
        Values = Mul(second).Values;
        return this;
    }

    public Mat<T> Add(Mat<T> second)
    {
        if(Values.Length != second.Values.Length 
        || Values.GetLength(0) != second.Values.GetLength(0)) 
            throw new Exception("matrix Operands should have same volume");

        Mat<T> res = matCtor(Values);
        for(int y = 0; y < res.Values.GetLength(0); y++)
        for(int x = 0; x < res.Values.GetLength(1); x++)
            res.Values[y,x] = opAdd(res.Values[y,x], second.Values[y,x]);
        
        return res;
    }


    public Mat<T> Add(T second)
    {
        Mat<T> res = matCtor(Values);
        for(int y = 0; y < res.Values.GetLength(0); y++)
        for(int x = 0; x < res.Values.GetLength(1); x++)
            res.Values[y,x] = opSub(res.Values[y,x], second);
        
        return res;
    }

    public Mat<T> Mul(Mat<T> second)
    {
        int mat1_cy = Values.GetLength(0);
        int mat1_cx = Values.GetLength(1);
        int mat2_cy = second.Values.GetLength(0);
        int mat2_cx = second.Values.GetLength(1);

        if(mat1_cx != mat2_cy) throw new ArgumentException("can multoply only matrices: m1[cy,cx], m2[cy,cx] where m1.cx == m2.cy");

        Mat<T> res = matCtor(Values);

        T[,] result = new T[mat1_cy, mat2_cx];

        for(int y = 0; y < mat1_cy; y++)
        {
            for (int x = 0; x < mat2_cx; x++)
            {
                for(int k = 0 ; k < mat2_cy; k++)
                {
                    result[y,x] = opAdd(result[y,x], opMul(Values[y, k], second.Values[k, x]));
                }
            }
        }

        res.Values = result;
        return res;
    }

    public Mat<T> Mul(Vec<T> second)
    {
        if(Values.GetLength(1) != second.Values.Length) throw new ArgumentException("can multoply only matrix  m1[cy,cx] by vector v1[cx]: m1.cx == v1.cx");
        Mat<T> res = matCtor(Values);
        T[,] result = new T[Values.GetLength(0), 1];

        for(int y = 0; y < Values.GetLength(0); y++)
        {
            for (int x = 0; x < Values.GetLength(1); x++)
            {
                result[y,x] =  opMul(Values[y, 0], second.Values[x]);
            }
        }

        res.Values = result;
        return res;
    }

    public Mat<T> Mul(T second)
    {
        Mat<T> res = matCtor(Values);
        for(int x = 0; x < Values.GetLength(1); x++)
        for (int y = 0; y < Values.GetLength(0); y++)
                res.Values[y, x] = opMul(res.Values[y, x], second);

        return res;
    }

    public T this[int y, int x]
    {
        get { return Values[y,x]; }
        set { Values[y, x] = value; }
    }

    public Vec<T> this[int index, bool horisontal = true]
    {
        get {
            if(horisontal)
            {
                T[] res = new T[Values.GetLength(1)];
                for(int x = 0; x < res.Length; x++)
                    res[x] = Values[0, x];
                return vecCtor(res);
            }
            else
            {
                T[] res = new T[Values.GetLength(0)];
                for(int y = 0; y < res.Length; y++)
                    res[y] = Values[y, 0];
                return vecCtor(res);
            }
        }
        set {
            if(horisontal)
            {
                for(int x = 0; x < Values.GetLength(1); x++)
                    Values[0, x] = value[x];
            }
            else
            {
                for(int y = 0; y < Values.GetLength(1); y++)
                    Values[y, 0] = value[y];
            }
        }
    }

    public static Mat<T> operator +(Mat<T> first, Mat<T> second)
    {        
        return first.Add(second);
    }

    public static Mat<T> operator +(Mat<T> first, T second)
    {        
        return first.Add(second);
    }

    public static Mat<T> operator -(Mat<T> first, Mat<T> second)
    {        
        return first.Sub(second);
    }

    public static Mat<T> operator -(Mat<T> first, T second)
    {        
        return first.Sub(second);
    }

    public static Mat<T> operator *(Mat<T> first, Mat<T> second)
    {        
        return first.Mul(second);
    }

    public static Mat<T> operator *(Mat<T> first, Vec<T> second)
    {        
        return first.Mul(second);
    }

    public static Mat<T> operator *(Mat<T> first, T second)
    {        
        return first.Mul(second);
    }
}