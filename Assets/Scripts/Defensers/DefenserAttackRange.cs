using UnityEngine;

public class DefenserAttackRange : MonoBehaviour
{
    public void OnAttackRange(Vector3 position, float range)
    {
        Debug.Log("범위 활성화");
        gameObject.SetActive(true);
        float diameter = range * 2.0f;
        transform.localScale = Vector3.one * diameter;
        transform.position = position;
    }

    public void OffAttackRange()
    {
        gameObject.SetActive(false);
    }
}
