using UnityEngine;
using TMPro;

public class start_Narration : MonoBehaviour
{

    public MonoBehaviour targetScript1;
    public MonoBehaviour targetScript2;

    public TextMeshProUGUI narrationText;      // 나레이션 텍스트 컴포넌트
    public GameObject narrationPanel;          // 나레이션 패널
    public GameObject button;                  // 버튼 변수
    public TextMeshProUGUI[] textArray;        // 인스펙터에서 할당할 텍스트 배열
    private int currentIndex = 0;              // 현재 텍스트 인덱스

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭 이벤트 발생
        {
            if (currentIndex < textArray.Length) // 텍스트가 남아있다면
            {
                narrationText.text = textArray[currentIndex].text; // 배열에서 텍스트 가져오기
                currentIndex++; // 인덱스 증가
            }
            else // 모든 텍스트를 표시했다면
            {
                narrationPanel.SetActive(false); // 패널 비활성화

                // targetScript1과 targetScript2가 null이 아닐 때만 실행
                if (targetScript1 != null) targetScript1.enabled = true;
                if (targetScript2 != null) targetScript2.enabled = true;
                // 버튼 활성화

                if (button != null) button.SetActive(true);

            }
        }
    }
}
