using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Delegate 1 : 대리자. 함수의 이름을 대체해준다.
//내부적으로는 일종의 Class처럼 동작

//delegate의 선언 형태 : [반환형] 델리게이트이름(파라미터);

public delegate void SomeMethod(int a); //return이 없는 함수(Method)
public delegate int SomeFunction(int a, int b);


//delegate 키워드 2 : 무명 메서드 선언으로 활용.
public class Delegate : MonoBehaviour
{


    public Text text;


    private void Start()
    {
        SomeMethod myMethod = PrintInt;
        myMethod(1); //Console : 1출력
        myMethod += CreateInt;
        myMethod(2); //Console : 2출력, 2라는 이름의 게임 오브젝트 생성
        myMethod -= PrintInt;
        myMethod(3); //3이라는 이름의 게임 오브젝트 생성
        myMethod -= CreateInt;
        myMethod?.Invoke(4); //myMethid가 null이면 그냥 호출 안함(?.Invoke의 역할)

        if (myMethod != null) myMethod.Invoke(4); //위에 Invoke 역할과 같음

        SomeMethod delegateisclass = new SomeMethod(PrintInt);
        delegateisclass(5); // Console : 5출력

        SomeFunction idontknow = Plus;
        int firstReturn = idontknow(1, 2);
        print(firstReturn);
        idontknow += Multiple;
        int secondReturn = idontknow(1, 2);
        print(secondReturn);
        //idontknow += PlusFloat; //에러


        //delegate의 무명메서드 활용
        SomeMethod someUnnamedMethod =
            delegate (int a) {
                text.text = a.ToString();
            };


        //람다식 1차 간소화 : delegate 키워드 대신 => 연산자로 대체
        someUnnamedMethod += (int a) => { print(a); };

        //2차 간소화 : 파라미터 데이터타입을 생략 가능.
        someUnnamedMethod += (b) => {
            print(b);
            text.text = b.ToString();
        };

        //3차 간소화 : 함수 내용이 1줄(세미콜론;이 1개만 사용)일 경우, 중괄호 생략 가능
        someUnnamedMethod += (c) => print(c);

        // 함수 1줄 간소화의 경우 return 키워드까지 생략 가능.
        SomeFunction someUnnamedFunction = (someIntA, someIntB) => Plus(someIntA, someIntB);


        someUnnamedMethod(4);

        myMethod += someUnnamedMethod;

        myMethod -= someUnnamedMethod;
        //무명메서드의 단점 : 해당 메서드를 추후에 다시 참조할 수 없다.
        //선언시점에서만 참조가 가능.

        //string stringA = new string("");
        //string stringB = "";

        //.netFramework 내장 delegate

        //1. 리턴이 없는 함수(Method) : Action
        System.Action nonParamMethod = () => { };
        System.Action<int> intParamMethod = (int a) => { };
        System.Action<string> stringParamMethod = (b) => { };

        //2.리턴이 있는 함수(Function) : Func
        System.Func<int> nonParamFunc = () => { return 3; };
        System.Func<int, string> intParamFunc = (int a) => { return a.ToString(); };

        //3. 조건검사를 위해 무조건 bool 리턴을 가진 함수 : Predicate
        System.Predicate<int> isOne = (a) => { return a==1; };

        //그 외
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
        print("Plus 호출됨");
        return a + b;
    }

    private int Multiple(int c, int d)
    {
        print("Multiple 호출됨");
        return c * d;
    }

    private float PlusFloat(float a, float b)
    { 
        return a + b ; 
    }

}
