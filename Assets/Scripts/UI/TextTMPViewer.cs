using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPlayerHP;
    [SerializeField] private PlayerHP playerHP;

    private void Update()
    {
        if (playerHP == null || textPlayerHP == null)
        {
            Debug.LogWarning("PlayerHP 또는 TextPlayerHP가 null입니다.");
            return;
        }

        textPlayerHP.text = playerHP.CurrentHP + " / " + playerHP.MaxHP;
    }
}
