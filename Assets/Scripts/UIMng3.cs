using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMng3 : MonoBehaviour
{
    public GameObject Select;
    public GameObject PT;
    public GameObject Menu;

    public Button done;

    public List<Text> TestInfos; //메인화면의 라벨들 선언

    private int ExIdx;
    private List<int> Counts = new List<int> { 0 }; //메인화면의 라벨들 숫자 리스트로 기록 (Counts)

    public void setSelect()
    {
        FindObjectOfType<ExpInfo3>().Guide.SetActive(true);
        int idx = 0; //정수값 idx가 0으로 시작
        foreach (var item in TestInfos) //메인 화면의 라벨들안에서의 item은 각각
        {
            item.text = string.Format("Test {0}\n{1}", idx + 1, Counts[idx]);
            idx++; //idx는 1씩 점점 증가한다.
        }

        bool isExpDone = false; //로그텍스트 저장 함수
        Counts.ForEach((int i) => { if (i == 100) isExpDone = true; }); //3개까지 카운트 되면

        if (isExpDone)
        {
        }

        Select.SetActive(true); //메인화면 활성화
        PT.SetActive(false); //테스트화면 비활성화
    }

    public void setEx(int idx) //테스트화면 함수
    {
        Select.SetActive(false); //메인화면 비활성화
        PT.SetActive(true); //테스트화면 활성화
        ExIdx = idx; //idx를 ExIdx로 저장
        Menu.SetActive(true); //테스트화면의 메뉴화면 활성화

        FindObjectOfType<ExpInfo3>().StartExp(ExIdx, Counts[ExIdx]);
        Counts[ExIdx]++; //Counts 리스트기록 순차적으로 숫자 증가
    }
}