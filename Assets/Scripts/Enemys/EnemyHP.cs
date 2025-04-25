using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    private float currentHP;
    private bool isDie = false;
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHP = enemyData.maxHp;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDie)
        {
            return;
        }

        currentHP -= damage;

        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        if (currentHP <= 0)
        {
            isDie = true;
            enemy.OnDie();
        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = spriteRenderer.color;

        color.a = 0.4f;
        spriteRenderer.color = color;

        yield return new WaitForSeconds(0.05f);

        color.a = 1.0f;
        spriteRenderer.color = color;
    }
}
