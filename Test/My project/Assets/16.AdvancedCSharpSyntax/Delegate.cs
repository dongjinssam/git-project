using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Delegate 1 : �븮��. �Լ��� �̸��� ��ü���ش�.
//���������δ� ������ Classó�� ����

//delegate�� ���� ���� : [��ȯ��] ��������Ʈ�̸�(�Ķ����);

public delegate void SomeMethod(int a); //return�� ���� �Լ�(Method)
public delegate int SomeFunction(int a, int b);


//delegate Ű���� 2 : ���� �޼��� �������� Ȱ��.
public class Delegate : MonoBehaviour
{


    public Text text;


    private void Start()
    {
        SomeMethod myMethod = PrintInt;
        myMethod(1); //Console : 1���
        myMethod += CreateInt;
        myMethod(2); //Console : 2���, 2��� �̸��� ���� ������Ʈ ����
        myMethod -= PrintInt;
        myMethod(3); //3�̶�� �̸��� ���� ������Ʈ ����
        myMethod -= CreateInt;
        myMethod?.Invoke(4); //myMethid�� null�̸� �׳� ȣ�� ����(?.Invoke�� ����)

        if (myMethod != null) myMethod.Invoke(4); //���� Invoke ���Ұ� ����

        SomeMethod delegateisclass = new SomeMethod(PrintInt);
        delegateisclass(5); // Console : 5���

        SomeFunction idontknow = Plus;
        int firstReturn = idontknow(1, 2);
        print(firstReturn);
        idontknow += Multiple;
        int secondReturn = idontknow(1, 2);
        print(secondReturn);
        //idontknow += PlusFloat; //����


        //delegate�� ����޼��� Ȱ��
        SomeMethod someUnnamedMethod =
            delegate (int a) {
                text.text = a.ToString();
            };


        //���ٽ� 1�� ����ȭ : delegate Ű���� ��� => �����ڷ� ��ü
        someUnnamedMethod += (int a) => { print(a); };

        //2�� ����ȭ : �Ķ���� ������Ÿ���� ���� ����.
        someUnnamedMethod += (b) => {
            print(b);
            text.text = b.ToString();
        };

        //3�� ����ȭ : �Լ� ������ 1��(�����ݷ�;�� 1���� ���)�� ���, �߰�ȣ ���� ����
        someUnnamedMethod += (c) => print(c);

        // �Լ� 1�� ����ȭ�� ��� return Ű������� ���� ����.
        SomeFunction someUnnamedFunction = (someIntA, someIntB) => Plus(someIntA, someIntB);


        someUnnamedMethod(4);

        myMethod += someUnnamedMethod;

        myMethod -= someUnnamedMethod;
        //����޼����� ���� : �ش� �޼��带 ���Ŀ� �ٽ� ������ �� ����.
        //������������� ������ ����.

        //string stringA = new string("");
        //string stringB = "";

        //.netFramework ���� delegate

        //1. ������ ���� �Լ�(Method) : Action
        System.Action nonParamMethod = () => { };
        System.Action<int> intParamMethod = (int a) => { };
        System.Action<string> stringParamMethod = (b) => { };

        //2.������ �ִ� �Լ�(Function) : Func
        System.Func<int> nonParamFunc = () => { return 3; };
        System.Func<int, string> intParamFunc = (int a) => { return a.ToString(); };

        //3. ���ǰ˻縦 ���� ������ bool ������ ���� �Լ� : Predicate
        System.Predicate<int> isOne = (a) => { return a==1; };

        //�� ��
        System.Comparison<Color> compare = (Color a, Color b) => { return (int)(a.a - a.b); };
    
    }

    private void PrintInt(int a)
    {
        print(a);
    }

    private void CreateInt(int a)
    {
        new GameObject().name = a.ToString();
    }

    private int Plus(int a, int b)
    {
        print("Plus ȣ���");
        return a + b;
    }

    private int Multiple(int c, int d)
    {
        print("Multiple ȣ���");
        return c * d;
    }

    private float PlusFloat(float a, float b)
    { 
        return a + b ; 
    }

}
