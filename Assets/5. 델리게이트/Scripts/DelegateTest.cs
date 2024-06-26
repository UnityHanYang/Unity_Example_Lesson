using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate (�븮��)
// C++�� �Լ������Ϳ� ������ ���
// �޼��带 ����ó�� ���������� Ȱ���� �� �ִ� ���

// Delegate ���� -> ������ (���۷���)�ڷ���ó�� ������ �����ϵ��� �����ؾ� �Ѵ�.
// [������] delegate [��ȯ��] [�̸�] ([�Ű����� ����]);
// dselegate�� ���� ���� ��ġ�� class, enum��� ����.
public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);


public class DelegateTest : MonoBehaviour
{
    public float x;
    public float y;

    // delegate �ʵ� ����
    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    private void Start()
    {
        //someDelegate = Plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divide;

        //otherDelegate = PrintMessage;
        //otherDelegate = print; // �Ű������� �Ͻ��� ĳ������ ������ ��쿡�� ����

        // Delegate�� �ν��Ͻ��� �����ϴ� �������� ������.
        otherDelegate = null;
        //otherDelegate("hello"); // null ����
        //otherDelegate = new OtherDelegateMethod(PrintMessage);
        //otherDelegate("");
        otherDelegate?.Invoke("");
        // ?. ������ �ϸ�, ? ���� ������ null�� ��� �������� �ʤ���
    }

    public void CalcChange(int i)
    {
        switch(i)
        {
            case 0:
                someDelegate = Plus;
                break;
            case 1:
                someDelegate = Minus;
                break;
            case 2:
                someDelegate = Multiple;
                break;
            case 3:
                someDelegate = Divide;
                break;
        }
    }

    public void ButtonClick()
    {
        print(someDelegate?.Invoke(x, y));
    }

    public float Plus(float x, float y)
    {
        return x + y;
    }

    public float Minus(float x, float  y)
    {
        return x - y;
    }

    public float Multiple(float a, float b)
    {
        return a * b;
    }

    public float Divide(float i, float j)
    {
        return i / j;
    }

    public void PrintMessage(string message)
    {
        print(message);
    }
}
