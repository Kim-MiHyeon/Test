using UnityEngine;

public class sc_load_canvas : MonoBehaviour
{
    public GameObject[] canvases;  // 활성화할 여러 개의 캔버스를 배열로 관리

    void Start()
    {
        // PlayerPrefs로 저장된 CanvasName을 불러옴
        string canvasName = PlayerPrefs.GetString("CanvasName", "");

        // 모든 캔버스 비활성화
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        // 이름에 맞는 캔버스만 활성화
        foreach (GameObject canvas in canvases)
        {
            if (canvas.name == canvasName)
            {
                canvas.SetActive(true);
            }
        }
    }
}
