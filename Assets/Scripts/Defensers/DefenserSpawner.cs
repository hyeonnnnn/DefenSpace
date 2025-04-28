using UnityEngine;

public class DefenserSpawner : MonoBehaviour
{
    [SerializeField] DefenserTemplete defenserTemplete;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] PlayerGold playerGold;

    public void SpawnDenfenser(Transform tileTransform)
    {
        if (playerGold.CurrentGold < defenserTemplete.weapon[0].cost)
        {
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

        if ( tile.IsPlaceDefenser == true )
        {
            return;
        }
        
        playerGold.CurrentGold -= defenserTemplete.weapon[0].cost;
        tile.IsPlaceDefenser = true;

        Vector3 position = tileTransform.position + Vector3.back;
        GameObject clone = Instantiate(defenserTemplete.defenserPrefab, position, Quaternion.identity);
        clone.GetComponent<DefenserWeapon>().Setup(enemySpawner, playerGold, tile);

        // 첫 번째 자식 스트라이트로 정렬
        Transform firstChild = clone.transform.GetChild(0);
        SpriteRenderer sr = firstChild.GetComponent<SpriteRenderer>();
        sr.sortingOrder = -(int)(clone.transform.position.y * 100);
    }
}
