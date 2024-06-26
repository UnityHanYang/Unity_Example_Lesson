using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    // 오늘 수업 내용 (컬렉션)
    // 데이터를 묶은 단위로 취급할 수 있는 클래스의 집합
    // 1. 배열
    // 2. 리스트(어레이 리스트)
    // 3. 딕셔너리(해쉬테이블)
    // 4. 스택 / 큐

    // 정수형 배열을 선언한다.

    #region 배열
    private int[] intArray = new int[5]; // 기본적으로 배열은 래퍼런스 타입이기 때문에 초기화 할당을
    // 하지 않으면  null 상태

    private int someInt; // int는 리터럴 타입 -> 리터럴 타입은 초기값 할당을 하지 않아도 기본값이 할당 됨.

    public int[] publicIntArray = new int[10];
    // 초기 할당값은 Unity 엔진에 의해 대체될 수 있음

    #endregion

    #region 리스트

    // 배열과 비슷한 기능을 한다.
    // 유동적으로 크기 변동이 가능.
    // 요소 비교 등의 기능을 지원하는 함수가 포함된 

    List<int> intList = new List<int>();

    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList;
    #endregion

    #region 딕셔너리

    public GameObject cube;
    public GameObject sphere;
    public GameObject capsule;
    public GameObject cylinder;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    private Hashtable hashtable = new Hashtable();
    // 잘 사용되진 않음 -> 타입에 제약이 없기 때문에 오류가 날 확률이 높음.

    // 배열: 공간 복잡도(낮음), 시간 복잡도(높음)
    // 딕셔너리(해시테이블): 공간 복잡도(높음), 시간 복잡도(낮음)
    #endregion

    #region 프로퍼티
    int a { get; set; }

    // 캡슐화
    private int a_1;

    // setter 메서드
    public void SetA_1(int value)
    {
        if (value > 100)
        {
            print("잘못된 값이 입력되었습니다.");
            a_1 = 100;
        }
        else
        {
            a_1 = value;
        }
    }

    public int GetA_1()
    {
        return a_1;
    }
    #endregion

    #region 스택/큐

    // 스택
    private Stack<int> intStack = new Stack<int>();

    // 큐
    private Queue<int> intQueue = new Queue<int>();
    #endregion


    // Reset 메서드: 전역변수의 초기값 할당 수행 후, 호출 됨

    private void Start()
    {
        Array.Fill<int>(intArray, 1);

        for (int i = 0; i < intArray.Length; i++)
        {
            print(intArray[i]);
        }

        foreach (var value in publicIntArray)
        {
            print(value);
        }

        print(intArray[0]);

        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);
        intList.Add(5);

        foreach (int someInt in intList)
        {
            print(someInt);
        }

        foreach (GameObject obj in gameObjects)
        {
            print(obj.name);
        }

        arrayList.Add(1);
        arrayList.Add(1f);
        arrayList.Add(new GameObject());

        foreach(object element in arrayList)
        {
            print(element);
        }

        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cyliner", sphere);
        dictionary.Add("capsule", capsule);

        // 리스트 참조
        print(intList[0]);

        // 딕셔너리 참조
        dictionary["capsule"].GetComponent<Renderer>().material.color = Color.red;
        dictionary["sphere"].GetComponent<Renderer>().material.color = Color.blue;
        dictionary["cube"].GetComponent<Renderer>().material.color = Color.green;
        dictionary["cyliner"].GetComponent<Renderer>().material.color = Color.green;

        hashtable.Add("a", 1);
        hashtable.Add(3f, new GameObject());

        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        print(intStack.Pop());
        print(intStack.Pop());
        print(intStack.Pop());

        intStack.Push(6);
        intStack.Push(7);

        print(intStack.Pop());
        print(intStack.Pop());
        print(intStack.Pop());
        print(intStack.Pop());

        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());

        intQueue.Enqueue(4);
        intQueue.Enqueue(5);

        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
    }
}
