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
        if (stage >= maxStage) // 최대 스테이지 도달 시 승리
        {
            WinGame();
            return;
        }

        stage++;
        enemiesDefeated = 0; // 다음 스테이지 시작 시 처치 수 초기화
      //  enemySpawner.IncreaseDifficulty(stage); // 스테이지별 난이도 증가
        UpdateStageUI();
    }

    private void UpdateStageUI()
    {
        stageText.text = "Stage: " + stage;
    }

    private void WinGame()
    {
        winUI.SetActive(true);   // 승리 UI 활성화
        Time.timeScale = 0;      // 게임 정지
        Debug.Log("게임 승리! 모든 스테이지를 완료했습니다.");
    }
}

