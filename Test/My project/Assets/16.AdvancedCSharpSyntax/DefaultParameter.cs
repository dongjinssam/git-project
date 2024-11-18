using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class DefaultParameter : MonoBehaviour
{

    //�⺻ �Ű����� : �Ű������� ������ ���� �Ҵ��� ���ص� �⺻������ Ư�� ���� ���� �ǵ��� �� �� ����.
    //��Ÿ���� �ƴ� ������Ÿ�ӿ��� �� �� �ִ� ���̿��� ��.(���ͷ�)
    //[��ȯ��] �Լ��̸�(Ÿ�� �Ű������� = �⺻��){}
    public Player newPlayer;
    private void Start()
    {
        GameObject a = CreateNewObject();
        //a.name = "New Obj";

        GameObject b = CreateNewObject("New Obj2");

        newPlayer = CreatePlayer("������", 1, 5f, Vector2.zero, new GameObject());

    }


    private GameObject CreateNewObject(string name = "Some Obj")
    {
        GameObject returnObject = new GameObject();
        returnObject.name = name;
        return returnObject;
    }

    //���丮 ����
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


    //paramas Ű���� : �Ƕ�̵忡 �迭�� �ް� ���� �ܿ�,�� ������ �迭 �Ƕ���� paramsŰ���� �ٿ��θ�,
    //    �迭 ���� ��� ��ǥ(,)�� �����Ͽ� �迭�� �ڵ������� �� �ִ� �Ķ����
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
