using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckArray : MonoBehaviour
{
    void Start()
    {
        SafeArray<int> sa = new SafeArray<int>(30);
        for (int i = 0; i < 32; i++)
        {
            sa[i] = i;
        }

        //for (int i = 0; i < 30; i++)
        //{
        //    print(sa[i]);
        //}
    }
}

class SafeArray<T>
{
    T[] arr;
    int n;
    public SafeArray(int size)
    {
        arr = new T[size];
        n = size;
    }

    public T this[int i]
    {
        get
        {
            return arr[i];
        }
        set
        {
            if (i >= n)
            {
                Debug.LogWarning("�ε����� �ʰ��߽��ϴ�");
            }
            else
            {
                arr[i] = value;
            }
        }
    }
}