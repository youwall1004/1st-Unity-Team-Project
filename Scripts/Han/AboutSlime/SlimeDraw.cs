using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//플레이어는 슬라임의 핸들만 다루고, 슬라임 본체는 핸들을 통해 간접 제어한다

public class SlimeDraw : MonoBehaviour
{
    //public Color color = new Vector4(0, 0, 0, 0.5f);
    private float distance = 10;
    //public int tempCount;
    //public TextMeshProUGUI cursorText;
    //public TextMeshProUGUI rangeText;
    //public TextMeshProUGUI powerGaugeText;
    public GameObject gameObj;      //본체
    public GameObject camObj;       //본체에 소속된 카메라

    private int powerGauge;      // 1~5까지

    public float objDistance;

    private float tempX;
    private float tempY;
    private float tempZ;

    private float xRange;
    private float yRange;
    private float zRange;

    //private bool fucking_Bug_Activate = true;    //염병할 버그가 동작중이다.


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDrag()
    {
        //float objDistance;
        objDistance = Vector3.Distance(gameObj.transform.position, gameObject.transform.position);
        //rangeText.text = "[Distance]: " + objDistance.ToString();

        if (enabled is true)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = camObj.GetComponent<Camera>().ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
        else
        {
            Debug.Log("멈춰!");
        }
    }

    private void OnMouseUp()
    {
        if (objDistance > 14)
        {
            powerGauge = 5;
            //Debug.Log("5로 당겨짐!");
        }
        else if (objDistance > 12)
        {
            powerGauge = 4;
            //Debug.Log("4로 당겨짐!");
        }
        else if (objDistance > 10)
        {
            powerGauge = 3;
            //Debug.Log("3로 당겨짐!");
        }
        else if (objDistance > 8)
        {
            powerGauge = 2;
            //Debug.Log("2로 당겨짐!");
        }
        else if (objDistance <= 8)
        {
            powerGauge = 1;
            //Debug.Log("1로 당겨짐!");
        }

        //powerGaugeText.text = "[Power]: " + powerGauge;

        switch (powerGauge)
        {
            case 5:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 10f*5;        //5단계

                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 4:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 7f * 5;        //4단계

                //보낼 부모오브젝트를 지정
                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 3:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 5f * 5;        //3단계

                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 2:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 3f * 5;        //2단계

                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 1:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 0f;        //1단계
                break;
        }
        gameObj.GetComponent<SlimeMove>().ImpulsePower();
        //핸들을 슬라임 위치로 이동. 핸들이 오브젝트로부터 떨어지는 쪽으로 했을 시, 핸들이 오브젝트에게 다시 돌아가기 위한 코드
        GetComponent<Transform>().position = gameObj.GetComponent<Transform>().position;
        
        
    }


    
}