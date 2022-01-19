using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�÷��̾�� �������� �ڵ鸸 �ٷ��, ������ ��ü�� �ڵ��� ���� ���� �����Ѵ�

public class SlimeDraw : MonoBehaviour
{
    //public Color color = new Vector4(0, 0, 0, 0.5f);
    private float distance = 10;
    //public int tempCount;
    //public TextMeshProUGUI cursorText;
    //public TextMeshProUGUI rangeText;
    //public TextMeshProUGUI powerGaugeText;
    public GameObject gameObj;      //��ü
    public GameObject camObj;       //��ü�� �Ҽӵ� ī�޶�

    private int powerGauge;      // 1~5����

    public float objDistance;

    private float tempX;
    private float tempY;
    private float tempZ;

    private float xRange;
    private float yRange;
    private float zRange;

    //private bool fucking_Bug_Activate = true;    //������ ���װ� �������̴�.


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
            Debug.Log("����!");
        }
    }

    private void OnMouseUp()
    {
        if (objDistance > 14)
        {
            powerGauge = 5;
            //Debug.Log("5�� �����!");
        }
        else if (objDistance > 12)
        {
            powerGauge = 4;
            //Debug.Log("4�� �����!");
        }
        else if (objDistance > 10)
        {
            powerGauge = 3;
            //Debug.Log("3�� �����!");
        }
        else if (objDistance > 8)
        {
            powerGauge = 2;
            //Debug.Log("2�� �����!");
        }
        else if (objDistance <= 8)
        {
            powerGauge = 1;
            //Debug.Log("1�� �����!");
        }

        //powerGaugeText.text = "[Power]: " + powerGauge;

        switch (powerGauge)
        {
            case 5:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 10f*5;        //5�ܰ�

                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 4:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 7f * 5;        //4�ܰ�

                //���� �θ������Ʈ�� ����
                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 3:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 5f * 5;        //3�ܰ�

                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 2:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 3f * 5;        //2�ܰ�

                FindObjectOfType<GameControll>().turnEnd(transform.parent.gameObject);

                break;
            case 1:
                gameObj.GetComponent<SlimeMove>().slimeSpeed = 0f;        //1�ܰ�
                break;
        }
        gameObj.GetComponent<SlimeMove>().ImpulsePower();
        //�ڵ��� ������ ��ġ�� �̵�. �ڵ��� ������Ʈ�κ��� �������� ������ ���� ��, �ڵ��� ������Ʈ���� �ٽ� ���ư��� ���� �ڵ�
        GetComponent<Transform>().position = gameObj.GetComponent<Transform>().position;
        
        
    }


    
}