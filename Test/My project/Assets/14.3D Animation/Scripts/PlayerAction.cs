using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


[RequireComponent(typeof(Animator), typeof(RigBuilder))]
public class PlayerAction : MonoBehaviour
{

    Animator animator;
    Rig rig;

    private WaitUntil untilReload;

    public AnimationClip reloadClip;

    private void Start()
    {
        
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //rig = GetComponent<Rig>().layers[0].rig;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    //R버튼을 누르면 재장전

            //rig.weigh = 0f;
  //          isReloading = ture;
            //animator.SetTrigger("Reload");
                
        }

  public void OnReloadEnd()
        {
            //print("ReloadEnd");
            //rig.weight = 1f;
            //isReloading = false;
        }
           
        //IEnumerator.ReloadCoroutine()
        //    {
        //    while (true)
        //    {
        //        yield return untilReload;
        //        yield return new WaitForSeconds(reloadClip.length);
        //        isReloading = false;
        //        rig.weight = 1f;
        //    }
        //}
    

}
