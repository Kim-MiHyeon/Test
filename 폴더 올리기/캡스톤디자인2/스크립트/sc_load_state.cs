using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_load_state : MonoBehaviour
{
    public string sceneName;   // ��ȯ�� �� �̸�
    public string canvasName;  // ��ȯ�� ĵ������ �̸�

    // OnClick �̺�Ʈ���� ȣ��Ǵ� �޼���
    public void LoadSceneWithCanvas()
    {
        // PlayerPrefs ��� ���ڿ��� ĵ���� �̸� ����
        PlayerPrefs.SetString("CanvasName", canvasName);

        // �� ��ȯ
        SceneManager.LoadScene(sceneName);
    }
}
