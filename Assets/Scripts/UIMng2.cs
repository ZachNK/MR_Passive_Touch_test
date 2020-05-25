using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMng2 : MonoBehaviour
{
    public GameObject Select; //메인화면 오브젝트 선언
    public GameObject PT; //테스트화면 오브젝트 선언
    public GameObject Menu; //테스트화면의 소리변수 메뉴 오브젝트 선언

    //public GameObject LeftHand;
    //public GameObject RightHand;
    //public Toggle LeftToggle;
    //public Toggle RightToggle;

    public Button done; //테스트화면의 테스트완료버튼 선언

    //public List<Dropdown> dropDowns;
    //public List<Dropdown> rightdropDowns;
    public List<Text> TestInfos; //메인화면의 라벨들 선언

    private int ExIdx;
    private List<int> Counts = new List<int> { 0, 0, 0 }; //메인화면의 라벨들 숫자 리스트로 기록 (Counts)

    public void Update() //매 프레임마다
    {
        if (Input.GetKeyDown(KeyCode.F1)) //F1을 누르면
        {
            setEx(0); //setEX가 0으로 실행
        }
    }

    public void OnLeftToggled()
    {
        //RightToggle.isOn = false;
    }

    public void OnRightToggled()
    {
        //LeftToggle.isOn = false;
    }

    public void RightDropChanged()
    {
        /* if ((rightdropDowns[0].value != rightdropDowns[1].value &&
             rightdropDowns[1].value != rightdropDowns[2].value &&
             rightdropDowns[2].value != rightdropDowns[0].value))
             done.interactable = true;
         else
             done.interactable = false;*/
    }

    public void LeftDropChanged()
    {
        /* if ((dropDowns[0].value != dropDowns[1].value &&
            dropDowns[1].value != dropDowns[2].value &&
            dropDowns[2].value != dropDowns[0].value))
             done.interactable = true;
         else
             done.interactable = false;*/
    }

    public void setSelect() //setSelect실행 함수
    {
        FindObjectOfType<ExpInfo2>().Guide.SetActive(true);
        int idx = 0; //정수값 idx가 0으로 시작
        foreach (var item in TestInfos) //메인 화면의 라벨들안에서의 item은 각각
        {
            item.text = string.Format("Test {0}\n{1}", idx + 1, Counts[idx]); //item의 text는 문자 포맷을 "Test {0}\n{1}"에서 idx가 1씩 증가할 때마다 반영하고, idx는 리스트로 기록한다(Counts).
            idx++; //idx는 1씩 점점 증가한다.
        }

        /* FindObjectOfType<LogWriter>().AddText(
             string.Format("실험 1 : {0}, {1}, {2} 순서로 사용자가 지정\n",
             dropDowns[0].value, dropDowns[1].value, dropDowns[2].value));*/

        bool isExpDone = false; //로그텍스트 저장 함수
        Counts.ForEach((int i) => { if (i == 9) isExpDone = true; }); //9개까지 카운트 되면
        if (isExpDone)
        {
            FindObjectOfType<LogWriter>().SaveText(); //텍스트 파일로 저장
            //EXP DONE
        }

        // int id = 0;
        //dropDowns.ForEach((Dropdown d) => { d.value = id; id += 1; });
        //id = 0;
        //rightdropDowns.ForEach((Dropdown d) => { d.value = id; id += 1; });
        Select.SetActive(true); //메인화면 활성화
        PT.SetActive(false); //테스트화면 비활성화
    }

    public void setEx(int idx) //테스트화면 함수
    {
        Select.SetActive(false); //메인화면 비활성화
        PT.SetActive(true); //테스트화면 비활성화
        ExIdx = idx; //idx를 ExIdx로 저장
        Menu.SetActive(true); //테스트화면의 메뉴화면 활성화
        // RightHand.SetActive(RightToggle.isOn);
        //LeftHand.SetActive(LeftToggle.isOn);
        FindObjectOfType<ExpInfo2>().StartExp(ExIdx, Counts[ExIdx]);
        Counts[ExIdx]++; //Counts 리스트기록 순차적으로 숫자 증가
    }
}