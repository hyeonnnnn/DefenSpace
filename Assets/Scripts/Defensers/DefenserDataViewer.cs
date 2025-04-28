using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenserDataViewer : MonoBehaviour
{
    [SerializeField] private Image imageDefenser;
    [SerializeField] private TextMeshProUGUI textDamage;
    [SerializeField] private TextMeshProUGUI textRate;
    [SerializeField] private TextMeshProUGUI textRange;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private DefenserAttackRange defenserAttackRange;
    [SerializeField] private Button buttonUpgrade;
    [SerializeField] private Button buttonSell;

    private DefenserWeapon currentDefenser;

    private void Awake()
    {
        OffPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
    }

    public void OnPanel(Transform defenserWeapon)
    {
        currentDefenser = defenserWeapon.GetComponent<DefenserWeapon>();
        gameObject.SetActive(true);
        UpdateDefenserData();
        defenserAttackRange.OnAttackRange(currentDefenser.transform.position, currentDefenser.Range);
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
        defenserAttackRange.OffAttackRange();
    }

    public void UpdateDefenserData()
    {
        imageDefenser.sprite = currentDefenser.DefenserSprite;
        textDamage.text = "공격력: " + currentDefenser.Damage;
        textRate.text = "공격 속도: " + currentDefenser.Rate;
        textRange.text = "공격 범위: " + currentDefenser.Range;
        textLevel.text = "레벨 " + currentDefenser.Level;

        buttonUpgrade.interactable = currentDefenser.Level < currentDefenser.MaxLevel ? true : false;
    }

    public void OnClickEventDefenserUpgrade()
    {
        Debug.Log("클릭");

        bool isSuccess = currentDefenser.Upgrade();

        if (isSuccess == true)
        {
            UpdateDefenserData();
            defenserAttackRange.OnAttackRange(currentDefenser.transform.position, currentDefenser.Range);
        }
        else
        {
            Debug.Log("업그레이드 비용 부족");
        }
    }

    public void OnClickEventDefenserSell()
    {
        currentDefenser.Sell();
        OffPanel();
    }
}
