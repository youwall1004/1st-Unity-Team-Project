using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trun : MonoBehaviour
{
    // 텍스트 표시
    public TextMeshProUGUI randomNum1;
    public TextMeshProUGUI randomNum2;
    public TextMeshProUGUI trunText;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI TurnCheck;
    //
    public GameObject rollPanel;
    public GameObject resultPanel;
    public GameObject[] itemActive;


    // 필드 슬라임 개수 확인 및 설정
    static int player1_Slime;
    static int player2_Slime;

    // 선공 정하기용 난수
    static int player1_Roll;
    static int player2_Roll;

    // 턴확인
    static bool player1_Trun;
    static bool player2_Trun;
    public static int totalTrun;

    // 아이템 랜덤 생성용

    GameObject[] items;//= Resources.LoadAll<GameObject>("Prefabs/");
    static int item_Roll;
    public bool isSpawnFlag = true;

    // 결과화면에서 승리자 표시 할 때 사용 (미정)
    string winner;


    public static int Player1_Slime
    {
        set
        {
            player1_Slime = value;
        }
        get
        {
            return player1_Slime;
        }
    }
    public static int Player2_Slime
    {
        set
        {
            player2_Slime = value;
        }
        get
        {
            return player2_Slime;
        }
    }
    public static int Player1_Roll
    {
        set
        {
            player1_Roll = value;
        }
        get
        {
            return player1_Roll;
        }
    }
    public static int Player2_Roll
    {
        set
        {
            player2_Roll = value;
        }
        get
        {
            return player2_Roll;
        }
    }
    public static bool Player1_Trun
    {
        set
        {
            player1_Trun = value;
        }
        get
        {
            return player1_Trun;
        }
    }
    public static bool Player2_Trun
    {
        set
        {
            player2_Trun = value;
        }
        get
        {
            return player2_Trun;
        }
    }
    public static int TotalTrun
    {
        set
        {
            totalTrun = value;
        }
        get
        {
            return totalTrun;
        }
    }


    void Start()
    {
        Player1_Trun = false;
        Player2_Trun = false;
        Player1_Slime = 5;
        Player2_Slime = 5;
        totalTrun = 1;

    }
    void Update()
    {
        ShowTrun();

        if (isSpawnFlag)
            SpawnItem();

        Result();
    }


    //선공 정하기
    public void Roll()
    {
        while (Player1_Roll == Player2_Roll)
        {
            Player1_Roll = Random.Range(1, 7);
            Player2_Roll = Random.Range(1, 7);

            if (Player1_Roll > Player2_Roll)
            {
                Player1_Trun = true;
                GameObject.FindGameObjectWithTag("1P").GetComponent<BattleTest>().enabled = true;
            }

            else if (Player1_Roll < Player2_Roll)
            {
                Player2_Trun = true;
                GameObject.FindGameObjectWithTag("2P").GetComponent<BattleTest>().enabled = true;
            }

            else if (Player1_Roll == Player2_Roll)
                continue;

            ShowRoll();
            //
            Invoke("RollPanelOff", 2.0f);
        }
    }

    // 아이템 랜덤 생성
    void SpawnItem()
    {
        // Resources 안에 있는 Prefabs폴더 하위 오브젝트들을 불러와서 배열에 담음
        GameObject[] items = Resources.LoadAll<GameObject>("Prefabs/");

        if (totalTrun % 2 == 0)
        {
            item_Roll = Random.Range(0, 2);
            Instantiate(items[item_Roll], new Vector3(Random.Range(-5, 15), 0, Random.Range(0, 10)), Quaternion.identity);
            isSpawnFlag = false;
        }
    }

    // 슬라임 개수가 0일시 결과화면으로 넘어가는 함수
    void Result()
    {
        if (Player1_Slime == 0 && Player1_Slime != Player2_Slime)
        {
            ResultPanelOn();
            winnerText.text = "WIN";
            winnerText.color = Color.red;
        }
        else if (Player2_Slime == 0 && Player1_Slime != Player2_Slime)
        {
            ResultPanelOn();
            winnerText.text = "WIN";
            winnerText.color = Color.green;
        }
        //else if (Player1_Slime == 0 && Player2_Slime == 0)
        //{
        //    ResultPanelOn();
        //    winnerText.text = "DRAW";
        //}
        Player1_Roll = Player2_Roll = 0;
        ;
    }
    // 정보 표시
    public void ShowRoll()
    {
        if (Player1_Roll != Player2_Roll)
        {
            randomNum1.text = "Green Dice  " + Player1_Roll;
            randomNum1.color = Color.green;
            randomNum2.text = "Red Dice  " + Player2_Roll;
            randomNum2.color = Color.red;
        }

    }
    public void ShowTrun()
    {
        if (Player1_Trun == true)
        {
            TurnCheck.text = "Green Turn";
            TurnCheck.color = Color.green;

        }
        else if (Player2_Trun == true)
        {
            TurnCheck.text = "Red Turn";
            TurnCheck.color = Color.red;

        }
    }
    // 창 활성화 및 비활성화
    public void RollPanelOff()
    {
        rollPanel.SetActive(false);
    }
    public void ResultPanelOn()
    {
        resultPanel.SetActive(true);
    }


}
