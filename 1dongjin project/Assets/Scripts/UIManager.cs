using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public SlimGgreen slime;
    public Text goldText;

    void Update()
    {

        goldText.text = "Gold : " + slime.gold;

    }
}
