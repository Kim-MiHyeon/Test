using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        //  �����߿��� �α׸� ���
        #if UNITY_EDITOR
                Debug.Log("���� ����");
                UnityEditor.EditorApplication.isPlaying = false; // �÷��� ���¸� false�� �����Ͽ� ���� ȿ��
        #else
                Application.Quit(); // ���� ����� ����
        #endif
    }
}
