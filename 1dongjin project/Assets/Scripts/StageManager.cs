using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

    public int stage = 1;
    public int enemiesDefeated = 0;
    public int enemiesPerStage = 10;
    public int maxStage = 10;

    public Text stageText;
    public GameObject winUI;


    private void Start()
    {
        UpdateStageUI();
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;

        if (enemiesDefeated >= enemiesPerStage)
        {
            AdvanceStage();
        }
    }

    private void AdvanceStage()
    {
        if (stage >= maxStage) // �ִ� �������� ���� �� �¸�
        {
            WinGame();
            return;
        }

        stage++;
        enemiesDefeated = 0; // ���� �������� ���� �� óġ �� �ʱ�ȭ
      //  enemySpawner.IncreaseDifficulty(stage); // ���������� ���̵� ����
        UpdateStageUI();
    }

    private void UpdateStageUI()
    {
        stageText.text = "Stage: " + stage;
    }

    private void WinGame()
    {
        winUI.SetActive(true);   // �¸� UI Ȱ��ȭ
        Time.timeScale = 0;      // ���� ����
        Debug.Log("���� �¸�! ��� ���������� �Ϸ��߽��ϴ�.");
    }
}

