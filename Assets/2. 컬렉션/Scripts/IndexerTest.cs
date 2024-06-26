using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyIndexer
{
    private int[] a = new int[10];

    public int this[int i]
    {
        get
        {
            return a[i];
        }

        set
        {
            a[i] = value;
        }
    }

    private string temp = string.Empty;

    public string this[string a]
    {
        get
        {
            if(a.Equals("a"))
            {
                return "apple";
            }
            else if(a.Equals("b"))
            {
                return "boat";
            }
            return temp;
        }

        set
        {
            if(!a.Equals("a") || !a.Equals("b"))
            {
                temp = value;
            }
        }
    }

    public MyIndexer()
    {
        for(int i = 0;i<a.Length; i++)
        {
            a[i] = i;
        }
    }
}
public class IndexerTest : MonoBehaviour
{
    private void Start()
    {
        MyIndexer myIndexer = new MyIndexer();

        print(myIndexer[0]);

        print(myIndexer["a"]);
        myIndexer["abc"] = "abc";
        print(myIndexer["c"]);
        // 인덱서: 프로퍼티의 배열 버전
    }
}
