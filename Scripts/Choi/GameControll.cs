using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public GameObject MainCamera;
    public List<GameObject> FocusCameras; // 슬라임들이 생성될때마다 각 포커스 카메라들을 제어하기위해 리스트화
    public GameObject StageFocusCamera; // 스테이지 포커스 카메라 고정

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

        if (Input.GetKeyDown(KeyCode.Space)) // Space(임시)가 입력되면 스테이지 포커스 카메라를 On/Off 하는 기능
        {
            if (StageFocusCamera.activeSelf == false) // 스테이지 포커스 카메라의 상태가 비활성화라면
            {
                if (PlayerBlue)
                {
                    //1P태그 일때 포커스 카메라 시점
                    StageFocusCamera.SetActive(true); // 스테이지 포커스 카메라의 상태를 활성화
                    Transform focuscamerarotate = StageFocusCamera.transform; // 스테이지 포커스 카메라의 위치를 저장할 선언
                    focuscamerarotate.rotation = Quaternion.Euler(0, 0, 0); // 스테이지 포커스 카메라의 각도
                    StageFocusCamera.transform.position = new Vector3(5.2f, 9f, -15); // 스테이지 포커스 카메라의 위치
                }
                else if (PlayerRed) //2P태그 일때 포커스 카메라 시점
                {
                    StageFocusCamera.SetActive(true); // 스테이지 포커스 카메라의 상태를 활성화
                    Transform focuscamerarotate = StageFocusCamera.transform; // 스테이지 포커스 카메라의 위치를 저장할 선언
                    focuscamerarotate.rotation = Quaternion.Euler(0, 0, 0); // 스테이지 포커스 카메라의 각도
                    StageFocusCamera.transform.position = new Vector3(5.2f, 9f, 25f); // 스테이지 포커스 카메라의 위치
                }
            }
            else if (StageFocusCamera.activeSelf == true)
            {
                MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // 스테이지 포커스 카메라가 종료될때 자동으로
                StageFocusCamera.SetActive(false);                       // 탑뷰 시점의 메인카메라로 돌아감
            }
        }
        else if (Input.GetKeyDown(KeyCode.Backspace)) // Back Space(임시)가 입력되면 메인 카메라를
        {                                             // 초기 위치로 되돌려 주는 기능
            StageFocusCamera.SetActive(false);
            MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f);

            for (int i = 0; i < FocusCameras.Count; i++) // 슬라임들의 포커스 카메라들을 체크
            {
                if (FocusCameras[i] == true)             // 만약 포커스 카메라들중 활성화된게 있다면
                {
                    
                    FocusCameras[i].SetActive(false);    // 활성화되어있는 포커스 카메라를 비활성화해주고
                    MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // 탑뷰 시점의 메인 카메라로 돌아감
                    
                }
            }
            GameObject.Find("MobileSpin").SetActive(false);
        }

    }
    //IEnumerator DelayP1Turn() // 1P 턴 지연을 위한 IEnumerator
    //{
    //    yield return new WaitForSeconds(2);
    //    Trun.Player1_Trun = false;
    //}

    //IEnumerator DelayP2Turn() // 2P 턴 지연을 위한 IEnumerator
    //{
    //    Debug.Log("턴 지연 2초전");
    //    yield return new WaitForSeconds(2);
    //    Debug.Log("턴 지연 후");
    //    Trun.Player2_Trun = false;
    //}

    public void turnEnd(GameObject slimeObj)//부모 오브젝트를 호출
    {
        //셀렉티드 카메라 해제
        FindObjectOfType<GameControll>().selectedCamera = null;

        if (Trun.Player1_Trun == true && PlayerBlue.GetComponent<BattleTest>().enabled == true)
        {
            //StartCoroutine(DelayP1Turn()); // 1P 턴일때 2초 지연 후 1P 턴 종료
            Trun.Player1_Trun = false;
            Trun.totalTrun++;
            PlayerBlue.GetComponent<BattleTest>().enabled = false;
            slimeObj.GetComponent<SlimeManager>().FocusCamera.SetActive(false);
            MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // 탑뷰 시점의 메인 카메라로 돌아감
            
            Trun.Player2_Trun = true;
            PlayerRed.GetComponent<BattleTest>().enabled = true;
        }
        else if (Trun.Player2_Trun == true && PlayerRed.GetComponent<BattleTest>().enabled == true)
        {
            //StartCoroutine(DelayP2Turn()); // 2P 턴일때 2초 지연 후 2P 턴 종료
            Trun.Player2_Trun = false;
            Trun.totalTrun++;
            PlayerRed.GetComponent<BattleTest>().enabled = false;
            slimeObj.GetComponent<SlimeManager>().FocusCamera.SetActive(false);
            MainCamera.transform.position = new Vector3(5.4f, 30.0f, 5.8f); // 탑뷰 시점의 메인 카메라로 돌아감

            Trun.Player1_Trun = true;
            PlayerBlue.GetComponent<BattleTest>().enabled = true;
        }
    }
}
