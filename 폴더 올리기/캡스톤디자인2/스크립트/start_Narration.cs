using UnityEngine;
using TMPro;

public class start_Narration : MonoBehaviour
{

    public MonoBehaviour targetScript1;
    public MonoBehaviour targetScript2;

    public TextMeshProUGUI narrationText;      // �����̼� �ؽ�Ʈ ������Ʈ
    public GameObject narrationPanel;          // �����̼� �г�
    public GameObject button;                  // ��ư ����
    public TextMeshProUGUI[] textArray;        // �ν����Ϳ��� �Ҵ��� �ؽ�Ʈ �迭
    private int currentIndex = 0;              // ���� �ؽ�Ʈ �ε���

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��Ŭ�� �̺�Ʈ �߻�
        {
            if (currentIndex < textArray.Length) // �ؽ�Ʈ�� �����ִٸ�
            {
                narrationText.text = textArray[currentIndex].text; // �迭���� �ؽ�Ʈ ��������
                currentIndex++; // �ε��� ����
            }
            else // ��� �ؽ�Ʈ�� ǥ���ߴٸ�
            {
                narrationPanel.SetActive(false); // �г� ��Ȱ��ȭ

                // targetScript1�� targetScript2�� null�� �ƴ� ���� ����
                if (targetScript1 != null) targetScript1.enabled = true;
                if (targetScript2 != null) targetScript2.enabled = true;
                // ��ư Ȱ��ȭ

                if (button != null) button.SetActive(true);

            }
        }
    }
}
