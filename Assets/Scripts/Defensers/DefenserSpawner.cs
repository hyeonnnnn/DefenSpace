using UnityEngine;

public class DefenserSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defenserPrefab;
    [SerializeField] EnemySpawner enemySpawner;

    public void SpawnDenfenser(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        if( tile.IsPlaceDefenser == true )
        {
            return;
        }

        tile.IsPlaceDefenser = true;
        GameObject clone = Instantiate(defenserPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<DefenserWeapon>().Setup(enemySpawner);
    }
}
