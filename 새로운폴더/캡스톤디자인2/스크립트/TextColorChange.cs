using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextColorChange : MonoBehaviour
{
    public Toggle myToggle;           // 연결할 토글
    public TextMeshProUGUI labelText; // 라벨에 사용할 TextMeshPro 컴포넌트

    public Color onColor = Color.green;   // 토글이 켜졌을 때 색상
    public Color offColor = Color.black;  // 토글이 꺼졌을 때 색상

    void Start()
    {
        // 초기 색상 설정
        UpdateLabelColor(myToggle.isOn);

        // 토글 상태가 변경될 때 이벤트 리스너 추가
        myToggle.onValueChanged.AddListener(delegate { UpdateLabelColor(myToggle.isOn); });
    }

    // 토글 상태에 따라 텍스트 색상 변경
    void UpdateLabelColor(bool isOn)
    {
        labelText.color = isOn ? onColor : offColor;
    }
}
