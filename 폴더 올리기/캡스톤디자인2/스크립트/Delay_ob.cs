using UnityEngine;

public class Delay_ob : MonoBehaviour
{
    public GameObject targetObject;  // 활성화/비활성화할 오브젝트
    public float delayTime = 2.0f;   // 몇 초 후에 동작할지 설정
    public bool activate = true;     // true이면 활성화, false이면 비활성화

    // OnClick 이벤트에서 연결할 메서드
    public void OnButtonClick()
    {
        // 버튼 클릭 시 delayTime 후에 ActivateObject 메서드 실행
        Invoke("ActivateObject", delayTime);
    }

    void ActivateObject()
    {
        // 오브젝트 활성화/비활성화
        if (targetObject != null)
        {
            targetObject.SetActive(activate);
        }
    }
}
