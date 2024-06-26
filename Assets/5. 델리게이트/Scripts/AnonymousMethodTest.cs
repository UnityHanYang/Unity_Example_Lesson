using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AnonymousMethodTest : MonoBehaviour
{

    // ���� �޼����
    // Ŭ���� ���� �ƴ� �޼��� ������ ���ǵǴ� �޼���
    // �޼��忡 �̸��� ������, Delegate�� �Ҵ��ϱ� ���ؼ���
    // �ش� Delegate�� �Ű������� ��ȯ���� Ÿ���� ��ġ�ؾ� ��.
    Action someAction;
    Action<int, float> autoCastPlus;
    Func<int, string> someFunc;
    Func<int, int, string> someFunc2;

    // ����޼����� ���� : 1ȸ������ ���Ǵ� �Լ��� ���Ǹ� ���� �Լ� �ۿ��� �� �ʿ䰡 ���� ��������
    // �����ϴ� ������ �ִ�. ���� ���������� ���Ǵ� ��������Ʈ ������ �Ҵ��ϴ� ������ ���� ���
    // �ش� ��Ŀ���� ����Ǹ� �޸� �Ҵ��� ���� �ϹǷ� ���ʿ��ϰ� �Լ��� �޸𸮸� �����ϴ� ���� ���� �� ����.

    // ����޼����� ���� : ��������Ʈ ü�̴��� ����� ��, �ش� �޼��常 ü�ο��� �����ϴ� ���� �Ұ���.
    // ��ȯ, �� �޼��忡�� ���� ����޼��� ���� �ÿ� ������ �������� ������ �� �ִ�.

    // ���ٽ� : ����޼����� ���� ǥ��

    private void Awake()
    {
        someAction = delegate () { print("Anonymous Method Called."); };

        autoCastPlus = delegate (int a, float b)
        {
            int result = a + (int)b;
            print(result);
        };

        // ���� �޼��� �Ҵ翡�� �Ű����� ������ ���ʿ��� ��� ������ �����ϴ�.
        autoCastPlus = delegate
        {
            print("Calc Finished");
        };

        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("�Էµ� �Ķ���ʹ� ");
            sb.Append(a);
            sb.Append(" �Դϴ�.");

            return sb.ToString();
        };


        // ���ٽ� ǥ�� ���
        someAction += (/*�Ķ����*/) => { /*�Լ� ����*/ };

        someFunc += (a) => { return a + " is intager"; };
        // �Ķ������ �ڷ��� ���� ����, ����, �߰�ȣ�� ���� ����
        someFunc += (a) => a + " is intager";
        // �Ķ���Ͱ� 1�� �� �� �Ұ�ȣ ���� ����
        someFunc += a => a + " is intager";

        someFunc2 = (a, b) => $"{a} + {b} = {a + b}";
    }

    private void Start()
    {

        someAction?.Invoke();
        someAction?.Invoke();

        autoCastPlus?.Invoke(1, 1.1f);
        print(someFunc.Invoke(923));
    }
}
