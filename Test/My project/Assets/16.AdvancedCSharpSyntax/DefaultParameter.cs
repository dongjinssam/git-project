using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class DefaultParameter : MonoBehaviour
{

    //기본 매개변수 : 매개변수에 전달할 값을 할당을 안해도 기본적으로 특정 값이 전달 되도록 할 수 있음.
    //런타임이 아닌 컴파일타임에서 알 수 있는 값이여야 함.(리터럴)
    //[반환형] 함수이름(타입 매개변수형 = 기본값){}
    public Player newPlayer;
    private void Start()
    {
        GameObject a = CreateNewObject();
        //a.name = "New Obj";

        GameObject b = CreateNewObject("New Obj2");

        newPlayer = CreatePlayer("윤동진", 1, 5f, Vector2.zero, new GameObject());

    }


    private GameObject CreateNewObject(string name = "Some Obj")
    {
        GameObject returnObject = new GameObject();
        returnObject.name = name;
        return returnObject;
    }

    //팩토리 패턴
    private Player CreatePlayer(string name, int level = 1, float damage = 5f, Vector2 position = default, GameObject obj = null)
    {
        Player returnPlayer = new Player();
        returnPlayer.name = name;
        returnPlayer.level = level;
        returnPlayer.damage = damage;
        returnPlayer.position = position;
        returnPlayer.rendererObject = obj;

        return returnPlayer;
    }


    //paramas 키워드 : 피라미드에 배열을 받고 싶은 겨우,맨 바지막 배열 피라미터 params키워를 붙여두면,
    //    배열 생성 대신 쉼표(,)로 구분하여 배열을 자동생성할 수 있는 파라미터
    private Player CreatePlayer(string name, int[] itemes)
    {
        Player returnPlayer = CreatePlayer(name);
        //returnPlayer.items = items;
        return returnPlayer;
    
    }
    

    [Serializable]
    public class Player
    {
        public string name;
        public int level;
        public float damage;
        public Vector2 position;
        public GameObject rendererObject;
        public int[] items;
    }

}
