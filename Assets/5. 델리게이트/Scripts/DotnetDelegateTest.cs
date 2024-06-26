using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotnetDelegateTest : MonoBehaviour
{
    // Action ��������Ʈ :
    // �⺻���� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����
    // ��ȯ���� ���� Method.
    Action action;

    // Action ��������Ʈ�� ���׸� Ÿ���� �Ķ���� Ÿ���� ����
    Action<int> actionWithIntParam;


    // Func ��������Ʈ :
    // ��ȯ���� �ִ� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����.
    Func<object> func;

    // Func ��������Ʈ�� ���׸� Ÿ�� �� �� �� ��ȯ��, �� �մ� �Ķ���� Ÿ�� ����
    Func<string, int> parseFunc;

    // PRedicate ��������Ʈ :
    // ��ȯ���� bool�̰�, 1�� �̻��� �Ķ���Ͱ� �ִ� ������ ��������Ʈ.
    Predicate<float> predicate;

    private void Start()
    {
        action = SomeAction;
        actionWithIntParam = SomeActionWithPram;

        parseFunc = Parse;

        // Preditacte ��� ����
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(7);
        intList.Add(8);
        intList.Add(9);

        // intList���� ¦���� �̾ƿ��� �ʹ�.
        List<int> evenList = intList.FindAll(IsEven);

        foreach (int i in evenList)
        {
            print(i);
        }

        //prediacte�� ���, �Ϻ� �÷��� �Լ��� ���� �Ǵ��� ���� ���Ǹ�
        // Bool�� �����ϴ� �Լ��� ���·� �ޱ� ���� Ȱ���.

        // ¦���� FindAll �� �� ���� �޼��带 ����� ���
        // ������ �ε�ǰ� �ѹ��� ������ �� ����޼��带 ���
        List<int> evenListByAnonymousMethod = intList.FindAll(
            delegate (int param)
            {
                return param % 2 == 0;
            }
            );  
    }

    private void SomeAction()
    {

    }

    private void SomeActionWithPram(int a)
    {

    }

    private int Parse(string param)
    {
        return int.Parse(param);
    }

    private bool IsEven(int param)
    {
        return param % 2 == 0;
    }
}
