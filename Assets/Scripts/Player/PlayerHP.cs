using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int maxHP = 10;
    [SerializeField] private Image screenRedImage;
    private int currentHP;

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        if (currentHP <= 0)
        {

        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = screenRedImage.color;

        color.a = 0.4f;
        screenRedImage.color = color;

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            screenRedImage.color = color;

            yield return null; 
        }
    }

}
