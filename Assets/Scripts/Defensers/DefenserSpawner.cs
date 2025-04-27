using UnityEngine;

public class DefenserSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defenserPrefab;
    [SerializeField] private int defenserSpawnGold = 50;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] PlayerGold playerGold;

    public void SpawnDenfenser(Transform tileTransform)
    {
        if (playerGold.CurrentGold < defenserSpawnGold)
        {
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

        if ( tile.IsPlaceDefenser == true )
        {
            return;
        }
        
        playerGold.CurrentGold -= defenserSpawnGold;
        tile.IsPlaceDefenser = true;

        Vector3 position = tileTransform.position + Vector3.back;
        GameObject clone = Instantiate(defenserPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<DefenserWeapon>().Setup(enemySpawner);

    }
}
