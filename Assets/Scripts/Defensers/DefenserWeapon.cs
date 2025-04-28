using UnityEngine;
using System.Collections;

public enum WeaponState
{
    SearchTarget = 0,
    AttackToTarget
}

public class DefenserWeapon : MonoBehaviour
{
    [SerializeField] private DefenserTemplete defenserTemplete;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    
    private int level = 0;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform attackTarget = null;
    private EnemySpawner enemySpawner;

    private SpriteRenderer spriteRenderer;
    private PlayerGold playergold;
    private Tile ownerTile;

    public Sprite DefenserSprite => defenserTemplete.weapon[level].sprite;
    public float Damage => defenserTemplete.weapon[level].damage;
    public float Range => defenserTemplete.weapon[level].rate;
    public float Rate => defenserTemplete.weapon[level].range;
    public int Level => level + 1;
    public int MaxLevel => defenserTemplete.weapon.Length;

    public void Setup(EnemySpawner enemySpawner, PlayerGold playerGold, Tile tile)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.enemySpawner = enemySpawner;
        this.playergold = playerGold;
        this.ownerTile = tile;

        ChangeState(WeaponState.SearchTarget);
    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        weaponState = newState;
        StartCoroutine(weaponState.ToString());
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closetDistSqr = Mathf.Infinity;

            for (int i = 0; i < enemySpawner.EnemyList.Count; ++i)
            {
                float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);

                if (distance <= defenserTemplete.weapon[level].range && distance <= closetDistSqr)
                {
                    closetDistSqr = distance;
                    attackTarget = enemySpawner.EnemyList[i].transform;
                }
            }

            if (attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }

            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            if( attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                yield break;
            }

            float distance = Vector3.Distance(attackTarget.position, transform.position);
            if (distance > defenserTemplete.weapon[level].range)
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                yield break;
            }

            yield return new WaitForSeconds(defenserTemplete.weapon[level].rate);

            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        if (attackTarget == null) return;

        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(attackTarget, defenserTemplete.weapon[level].damage);
    }

    public bool Upgrade()
    {
        if (level >= MaxLevel)
        {
            Debug.Log("최대 레벨");
            return false;
        }

        if (playergold.CurrentGold < defenserTemplete.weapon[level].cost)
        {
            Debug.Log("골드 부족");
            return false;
        }

        playergold.CurrentGold -= defenserTemplete.weapon[level].cost;
        level++;

        return true;
    }

    public void Sell()
    {
        playergold.CurrentGold += defenserTemplete.weapon[level].sell;
        ownerTile.IsPlaceDefenser = false;
        Destroy(gameObject);
    }
}
