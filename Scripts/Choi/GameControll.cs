using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public GameObject MainCamera;
    public List<GameObject> FocusCameras; // �����ӵ��� �����ɶ����� �� ��Ŀ�� ī�޶���� �����ϱ����� ����Ʈȭ
    public GameObject StageFocusCamera; // �������� ��Ŀ�� ī�޶� ����

    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    public Camera selectedCamera;

    public List<GameObject> greenSlimes;
    public List<GameObject> redSlimes;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) // Space(�ӽ�)�� �ԷµǸ� �������� ��Ŀ�� ī�޶� On/Off �ϴ� ���
        {
            if (StageFocusCamera.activeSelf == false) // �������� ��Ŀ�� ī�޶��� ���°� ��Ȱ��ȭ���
            {
                if (PlayerBlue)
                {
                    //1P�±� �϶� ��Ŀ�� ī�޶� ����
                    StageFocusCamera.SetActive(true); // �������� ��Ŀ�� ī�޶��� ���¸� Ȱ��ȭ
                    Transform focuscamerarotate = StageFocusCamera.transform; // �������� ��Ŀ�� ī�޶��� ��ġ�� ������ ����
                    focuscamerarotate.rotation = Quaternion.Euler(0, 0, 0); // �������� ��Ŀ�� ī�޶��� ����
                    StageFocusCamera.transform.position = new Vector3(5.2f, 9f, -15); // �������� ��Ŀ�� ī�޶��� ��ġ
                }
                else if (PlayerRed) //2P�±� �϶� ��Ŀ�� ī�޶� ����
                {
                    StageFocusCamera.SetActive(true); // �������� ��Ŀ�� ī�޶��� ���¸� Ȱ��ȭ
                    Transform focuscamerarotate = StageFocusCamera.transform; // �������� ��Ŀ�� ī�޶��� ��ġ�� ������ ����
                    focuscamerarotate.rotation = Quaternion.Euler(0, 0, 0); // �������� ��Ŀ�� ī�޶��� ����
                    StageFocusCamera.transform.position = new Vector3(5.2f, 9f, 25f); // �������� ��Ŀ�� ī�޶��� ��ġ
                }
            }
            else if (StageFocusCamera.activeSelf == true)
            {
                MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // �������� ��Ŀ�� ī�޶� ����ɶ� �ڵ�����
                StageFocusCamera.SetActive(false);                       // ž�� ������ ����ī�޶�� ���ư�
            }
        }
        else if (Input.GetKeyDown(KeyCode.Backspace)) // Back Space(�ӽ�)�� �ԷµǸ� ���� ī�޶�
        {                                             // �ʱ� ��ġ�� �ǵ��� �ִ� ���
            StageFocusCamera.SetActive(false);
            MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f);

            for (int i = 0; i < FocusCameras.Count; i++) // �����ӵ��� ��Ŀ�� ī�޶���� üũ
            {
                if (FocusCameras[i] == true)             // ���� ��Ŀ�� ī�޶���� Ȱ��ȭ�Ȱ� �ִٸ�
                {
                    
                    FocusCameras[i].SetActive(false);    // Ȱ��ȭ�Ǿ��ִ� ��Ŀ�� ī�޶� ��Ȱ��ȭ���ְ�
                    MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // ž�� ������ ���� ī�޶�� ���ư�
                    
                }
            }
            GameObject.Find("MobileSpin").SetActive(false);
        }

    }
    //IEnumerator DelayP1Turn() // 1P �� ������ ���� IEnumerator
    //{
    //    yield return new WaitForSeconds(2);
    //    Trun.Player1_Trun = false;
    //}

    //IEnumerator DelayP2Turn() // 2P �� ������ ���� IEnumerator
    //{
    //    Debug.Log("�� ���� 2����");
    //    yield return new WaitForSeconds(2);
    //    Debug.Log("�� ���� ��");
    //    Trun.Player2_Trun = false;
    //}

    public void turnEnd(GameObject slimeObj)//�θ� ������Ʈ�� ȣ��
    {
        //����Ƽ�� ī�޶� ����
        FindObjectOfType<GameControll>().selectedCamera = null;

        if (Trun.Player1_Trun == true && PlayerBlue.GetComponent<BattleTest>().enabled == true)
        {
            //StartCoroutine(DelayP1Turn()); // 1P ���϶� 2�� ���� �� 1P �� ����
            Trun.Player1_Trun = false;
            Trun.totalTrun++;
            PlayerBlue.GetComponent<BattleTest>().enabled = false;
            slimeObj.GetComponent<SlimeManager>().FocusCamera.SetActive(false);
            MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // ž�� ������ ���� ī�޶�� ���ư�
            
            Trun.Player2_Trun = true;
            PlayerRed.GetComponent<BattleTest>().enabled = true;
        }
        else if (Trun.Player2_Trun == true && PlayerRed.GetComponent<BattleTest>().enabled == true)
        {
            //StartCoroutine(DelayP2Turn()); // 2P ���϶� 2�� ���� �� 2P �� ����
            Trun.Player2_Trun = false;
            Trun.totalTrun++;
            PlayerRed.GetComponent<BattleTest>().enabled = false;
            slimeObj.GetComponent<SlimeManager>().FocusCamera.SetActive(false);
            MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // ž�� ������ ���� ī�޶�� ���ư�

            Trun.Player1_Trun = true;
            PlayerBlue.GetComponent<BattleTest>().enabled = true;
        }
    }
}
