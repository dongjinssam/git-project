using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public SlimGgreen slime;
    public Text goldText;

    public Text powerLevelText;

    void Update()
    {

        goldText.text = "Gold : " + SlimGgreen.gold;

        powerLevelText.text = "Power : " + slime.GetPowerLevel().ToString("F2");
    }
}
