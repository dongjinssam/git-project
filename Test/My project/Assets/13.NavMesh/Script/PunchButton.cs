
//using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PunchButton : MonoBehaviour
{

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

   // Tweener punchTween;
   // private void Punch()
  //  {

    //    if (punchTween != null)
    //    {
    //        punchTween.Complete();
    //    }

    //    Vector3 punchSize = new Vector3(1.3f, 1.3f, 1.3f);

    //    punchTween =  transform.DOPunchScale(punchSize, 0.5f);
    //}

    private void Shake()
    {
        //if (punchTween != null)
        //{
        //    punchTween.Complete(); //트윈이 진행중이면 트윈을 완전히 끝냄.
        //}


        //punchTween = transform.DOShakePosition(0.5f, 3f);
    }

}
