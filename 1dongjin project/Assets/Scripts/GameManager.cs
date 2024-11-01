using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    public int money;

    public TextMeshProUGUI moneyText;

    public static GameManager instance;

    public GameObject menuSet;
    public GameObject player;


    private PauseControl pauseControl;

    public bool isDoubleSpeed = false;

    public void ToggleDoubleSpeed()
    {
        if (isDoubleSpeed)
        {
            Time.timeScale = 1;
            isDoubleSpeed = false;
        }
        else
        {
            Time.timeScale = 2;
            isDoubleSpeed = true;
        }
    }

    void Awake()
    {
        instance = this;

        pauseControl = GetComponent<PauseControl>();
    }


    void Update()
    {
        //Sub Menu

        if (Input.GetButtonDown("Cancel"))
        {
            
            ToggleMenuAndPause();

            //if (menuSet.activeSelf)
            //    menuSet.SetActive(false);
            //else
            //    menuSet.SetActive(true);

        }

        if (Input.GetMouseButtonDown(0))
        {
            ToggleDoubleSpeed();
        }
    }

    public void ToggleMenuAndPause()
    {
        if (menuSet.activeSelf)
        {
            menuSet.SetActive(false);
            pauseControl.pauseBtn();
        }
        else
        {
            menuSet.SetActive(true);
            pauseControl.pauseBtn();


        }

    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

    public void TakeMoney(int amount)
    {
        money -= amount;
        moneyText.text = "$" + money.ToString();

    }

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;


        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0);
    }

    public void GameExit()
    {
        Application.Quit();
    }


}
