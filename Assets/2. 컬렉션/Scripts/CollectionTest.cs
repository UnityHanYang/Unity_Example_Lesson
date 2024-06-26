using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    // ���� ���� ���� (�÷���)
    // �����͸� ���� ������ ����� �� �ִ� Ŭ������ ����
    // 1. �迭
    // 2. ����Ʈ(��� ����Ʈ)
    // 3. ��ųʸ�(�ؽ����̺�)
    // 4. ���� / ť

    // ������ �迭�� �����Ѵ�.

    #region �迭
    private int[] intArray = new int[5]; // �⺻������ �迭�� ���۷��� Ÿ���̱� ������ �ʱ�ȭ �Ҵ���
    // ���� ������  null ����

    private int someInt; // int�� ���ͷ� Ÿ�� -> ���ͷ� Ÿ���� �ʱⰪ �Ҵ��� ���� �ʾƵ� �⺻���� �Ҵ� ��.

    public int[] publicIntArray = new int[10];
    // �ʱ� �Ҵ簪�� Unity ������ ���� ��ü�� �� ����

    #endregion

    #region ����Ʈ

    // �迭�� ����� ����� �Ѵ�.
    // ���������� ũ�� ������ ����.
    // ��� �� ���� ����� �����ϴ� �Լ��� ���Ե� 

    List<int> intList = new List<int>();

    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList;
    #endregion

    #region ��ųʸ�

    public GameObject cube;
    public GameObject sphere;
    public GameObject capsule;
    public GameObject cylinder;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    private Hashtable hashtable = new Hashtable();
    // �� ������ ���� -> Ÿ�Կ� ������ ���� ������ ������ �� Ȯ���� ����.

    // �迭: ���� ���⵵(����), �ð� ���⵵(����)
    // ��ųʸ�(�ؽ����̺�): ���� ���⵵(����), �ð� ���⵵(����)
    #endregion

    #region ������Ƽ
    int a { get; set; }

    // ĸ��ȭ
    private int a_1;

    // setter �޼���
    public void SetA_1(int value)
    {
        if (value > 100)
        {
            print("�߸��� ���� �ԷµǾ����ϴ�.");
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

    #region ����/ť

    // ����
    private Stack<int> intStack = new Stack<int>();

    // ť
    private Queue<int> intQueue = new Queue<int>();
    #endregion


    // Reset �޼���: ���������� �ʱⰪ �Ҵ� ���� ��, ȣ�� ��

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

        // ����Ʈ ����
        print(intList[0]);

        // ��ųʸ� ����
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
