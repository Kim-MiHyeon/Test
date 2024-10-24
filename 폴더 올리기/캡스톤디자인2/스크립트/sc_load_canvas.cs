using UnityEngine;

public class sc_load_canvas : MonoBehaviour
{
    public GameObject[] canvases;  // Ȱ��ȭ�� ���� ���� ĵ������ �迭�� ����

    void Start()
    {
        // PlayerPrefs�� ����� CanvasName�� �ҷ���
        string canvasName = PlayerPrefs.GetString("CanvasName", "");

        // ��� ĵ���� ��Ȱ��ȭ
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        // �̸��� �´� ĵ������ Ȱ��ȭ
        foreach (GameObject canvas in canvases)
        {
            if (canvas.name == canvasName)
            {
                canvas.SetActive(true);
            }
        }
    }
}
