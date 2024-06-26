using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGenericTest : MonoBehaviour
{
    public CubeParent cubeFrom;
    public CubeParent cubeTo;

    private void Awake()
    {
        // cubeFrom의 colors, xPositions, scales 배열을 각각 복사하고 싶음.
        cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
        cubeTo.scales = ArrayCopy<float>(cubeFrom.scales);
        cubeTo.xPositions = ArrayCopy<int>(cubeFrom.xPositions);
    }

    private Color[] ArrayCopy(Color[] from)
    {
        Color[] to = new Color[from.Length];

        for(int i = 0; i< from.Length; i++)
        {
            to[i] = from[i];
        }

        return to;
    }

    private T[] ArrayCopy<T>(T[] from)
    {
        T[] to = new T[from.Length];

        for (int i = 0; i < from.Length; i++)
        {
            to[i] = from[i];
        }

        return to;
    }
}

/*
 제네릭 활용은 크게 2가지

1. 제네릭을 사용하여 정의된 클래스를 자료형으로 사용 또는 함수를 호출
예시) List<int> : List라는 클래스를 사용하는데, 안에서 취급될 자료형은 int.
예시2) GetComponent<T>() : 게임 오브젝트에 부착된 컴포넌트를 찾는데, T 클래스의 컴포넌트를 찾는다.

2. 직접 제네릭을 사용한 클래스 또는 함수를 정의
 
 */

public class GenericExample : MonoBehaviour
{
    public List<int> intList = new List<int>(0);

    private void Start()
    {
        new GameObject().AddComponent<SpriteRenderer>();

        StructT<Vector3> a;
        ClassT<SpriteRenderer> b;
        // 추상클래스는 객체를 생성하지 못하기 때문에 new를 사용할 수 없다.

        //NewT<NoneDefaultConstructorClass> c; 오류
        NewT<int> c;
        ParentT<Child> d;
        InterfaceT<string> e;
    }
}

class NoneDefaultConstructorClass
{
    public NoneDefaultConstructorClass(int a)
    {

    }
}

class Parent { }
class Child : Parent { }

// 클래스에서 사용하는 제네릭 자료형에 제약사항을 명시할 수 있다.

class StructT<T> where T : struct  // 1. 구조체만 가능(Vector3...)
{

}

class ClassT<T> where T : class // 2. 클래스만 가능
{

}

class NewT<T> where T : new() // 3. 파라미터가 없는 기본 생성자를 정의한 클래스만 가능
{

}

class ParentT<T> where T : Parent // 4. Parent 클래스를 상속한 클래스만 가능
{

}

class InterfaceT<T> where T : IComparable // 5. IComparable 인터페이스를 구현한 클래스만 가능
{

}

class MultiT<T1, T2, T3> where T1: struct where T2 : class where T3 : new() // 6. 다중 제네릭
{

}
