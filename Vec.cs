
namespace LinearAlgebra;


public delegate Vec<T> VecConstructor<T>(T[] Values);

public abstract class Vec<T>: VecType<T>
{

    protected abstract VecConstructor<T> vecCtor {get;}

    public T[] Values {get; private set;}

    public Vec(params T[] values)
    {
        Values = values;
    }

    public Vec()
    {
        Values = new T[0];
    }

    public Vec(Vec<T> Valuess, params T[] Valuess2)
    {
        Values = Valuess.Values.Concat(Valuess2).ToArray();
    }

    public Vec<T> SetAdd(Vec<T> second)
    {
        Values = Add(second).Values;
        return this;
    }

    public Vec<T> SetSub(Vec<T> second)
    {
        Values = Sub(second).Values;
        return this;
    }

    public Vec<T> SetMul(Vec<T> second)
    {
        Values = Mul(second).Values;
        return this;
    }


    public Vec<T> SetDiv(Vec<T> second)
    {
        Values = Div(second).Values;
        return this;
    }




    public Vec<T> SetAdd(T second)
    {
        Values = Add(second).Values;
        return this;
    }

    public Vec<T> SetSub(T second)
    {
        Values = Sub(second).Values;
        return this;
    }

    public Vec<T> SetMul(T second)
    {
        Values = Mul(second).Values;
        return this;
    }


    public Vec<T> SetDiv(T second)
    {
        Values = Div(second).Values;
        return this;
    }

    public Vec<T> Add(Vec<T> second)
    {
        if(Values.Length != second.Values.Length) throw new Exception("vector Operand should have same volume");
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            res.Values[i] = opAdd(res.Values[i], second.Values[i]);
        return res;
    }

    public Vec<T> Sub(Vec<T> second)
    {
        if(Values.Length != second.Values.Length) throw new Exception("vector Operand should have same volume");
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            res.Values[i] = opSub(res.Values[i], second.Values[i]);
        return res;
    }

    public Vec<T> Mul(Vec<T> second)
    {
        if(Values.Length != second.Values.Length) throw new Exception("vector Operand should have same volume");
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            res.Values[i] = opMul(res.Values[i], second.Values[i]);
        return res;
    }


    public Vec<T> Div(Vec<T> second)
    {
        if(Values.Length != second.Values.Length) throw new Exception("vector Operand should have same volume");
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            res.Values[i] = opDiv(res.Values[i], second.Values[i]);
        return res;
    }




    public Vec<T> Add(T second)
    {
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            Values[i] = opAdd(Values[i], second);
        return res;
    }

    public Vec<T> Sub(T second)
    {
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            res.Values[i] = opSub(res.Values[i], second);
        return res;
    }

    public Vec<T> Mul(T second)
    {
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            res.Values[i] = opMul(res.Values[i], second);
        return res;
    }


    public Vec<T> Div(T second)
    {
        Vec<T> res = vecCtor(Values);
        for (int i = 0; i < Values.Length; i++)
            res.Values[i] = opDiv(res.Values[i], second);
        return res;
    }



    public T this[int index]
    {
        get { return Values[index]; }
        set { Values[index] = value; }
    }

    public Vec<T> this[params int[] indexes]
    {
        get
        { 
            T[] res = new T[indexes.Length];
            for(int i = 0; i < indexes.Length; i++)
                res[i] = Values[indexes[i]];
            
            return vecCtor(res);
        }
        set 
        {
            for(int i = 0; i < indexes.Length; i++)
                Values[indexes[i]] = Values[indexes[i]];
        }
    }

    public static Vec<T> operator +(Vec<T> first, Vec<T> second)
    {
        return first.Add(second);
    }

    public static Vec<T> operator -(Vec<T> first, Vec<T> second)
    {
        return first.Sub(second);
    }

    public static Vec<T> operator *(Vec<T> first, Vec<T> second)
    {
        return first.Mul(second);
    }

    public static Vec<T> operator /(Vec<T> first, Vec<T> second)
    {
        return first.Div(second);
    }



    public static Vec<T> operator +(Vec<T> first, T second)
    {
        return first.Add(second);
    }

    public static Vec<T> operator -(Vec<T> first, T second)
    {
        return first.Sub(second);
    }

    public static Vec<T> operator *(Vec<T> first, T second)
    {
        return first.Mul(second);
    }

    public static Vec<T> operator /(Vec<T> first, T second)
    {
        return first.Div(second);
    }
}
