using UnityEngine;

public class Delay_scpt : MonoBehaviour
{
    public MonoBehaviour targetScript;  // 활성화/비활성화할 스크립트(컴포넌트)
    public float delayTime = 2.0f;      // 몇 초 후에 동작할지 설정
    public bool activate = true;        // true이면 활성화, false이면 비활성화

    // OnClick 이벤트에서 연결할 메서드
    public void OnButtonClick()
    {
        // 버튼 클릭 시 delayTime 후에 ActivateScript 메서드 실행
        Invoke("ActivateScript", delayTime);
    }

    void ActivateScript()
    {
        // 스크립트 활성화/비활성화
        if (targetScript != null)
        {
            targetScript.enabled = activate;
        }
    }
}
