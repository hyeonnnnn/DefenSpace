using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPlayerHP;
    [SerializeField] private PlayerHP playerHP;

    [SerializeField] private TextMeshProUGUI textPlayerGold;
    [SerializeField] private PlayerGold playerGold;

    [SerializeField] private TextMeshProUGUI textWave;
    [SerializeField] private WaveSystem waveSystem;

    [SerializeField] private TextMeshProUGUI textEnemyCount;
    [SerializeField] private EnemySpawner enemySpawner;

    private void Update()
    {
        textPlayerHP.text = playerHP.CurrentHP + " / " + playerHP.MaxHP;
        textPlayerGold.text = playerGold.CurrentGold.ToString();
        textWave.text = "Wave " + waveSystem.CurrentWave;
        textEnemyCount.text = enemySpawner.CurrentEnemyCount + " / " + enemySpawner.MaxEnemyCount;
    }
}
