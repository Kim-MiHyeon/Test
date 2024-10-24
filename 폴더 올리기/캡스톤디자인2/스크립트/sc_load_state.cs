using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_load_state : MonoBehaviour
{
    public string sceneName;   // 전환할 씬 이름
    public string canvasName;  // 전환할 캔버스의 이름

    // OnClick 이벤트에서 호출되는 메서드
    public void LoadSceneWithCanvas()
    {
        // PlayerPrefs 대신 문자열로 캔버스 이름 저장
        PlayerPrefs.SetString("CanvasName", canvasName);

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }
}
