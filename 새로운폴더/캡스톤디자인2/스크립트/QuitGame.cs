using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        //  빌드중에는 로그를 출력
        #if UNITY_EDITOR
                Debug.Log("게임 종료");
                UnityEditor.EditorApplication.isPlaying = false; // 플레이 상태를 false로 변경하여 종료 효과
        #else
                Application.Quit(); // 실제 빌드된 게임
        #endif
    }
}
