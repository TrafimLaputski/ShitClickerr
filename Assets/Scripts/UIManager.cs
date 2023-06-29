using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private DataManager _dataManager = null;

    [SerializeField] private TextMeshProUGUI _textMoney—ount = null;
    [SerializeField] private TextMeshProUGUI _textClickPrice = null;
    [SerializeField] private TextMeshProUGUI _textTimePrice = null;

    private void Start()
    {
        _dataManager.dataUpdateAction += UpdateData;
    }

    private void UpdateData()
    {
        _textMoney—ount.text = _dataManager.MoneyCount.ToString();
        _textClickPrice.text = _dataManager.ClickPrice.ToString();
        _textTimePrice.text = _dataManager.TimePrice.ToString();
    }
}
