using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextColorChange : MonoBehaviour
{
    public Toggle myToggle;           // ������ ���
    public TextMeshProUGUI labelText; // �󺧿� ����� TextMeshPro ������Ʈ

    public Color onColor = Color.green;   // ����� ������ �� ����
    public Color offColor = Color.black;  // ����� ������ �� ����

    void Start()
    {
        // �ʱ� ���� ����
        UpdateLabelColor(myToggle.isOn);

        // ��� ���°� ����� �� �̺�Ʈ ������ �߰�
        myToggle.onValueChanged.AddListener(delegate { UpdateLabelColor(myToggle.isOn); });
    }

    // ��� ���¿� ���� �ؽ�Ʈ ���� ����
    void UpdateLabelColor(bool isOn)
    {
        labelText.color = isOn ? onColor : offColor;
    }
}
