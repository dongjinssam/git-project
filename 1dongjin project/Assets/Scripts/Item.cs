using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{

    [SerializeField] float speed = -5f;


    void Start()
    {
        Destroy(gameObject, 10f);
    }


    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

    }

 
}
