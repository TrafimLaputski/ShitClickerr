using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Action dataUpdateAction;

    [SerializeField] private InputManager _inputManager = null;
    [SerializeField] private TimeManager _timeManager = null;

    [SerializeField] private float _clickUpgradeCoefficient = 1.50f;
    [SerializeField] private float _timeUpgradeCoefficient = 1.50f;
    [SerializeField] private float _clickPriceUpgradeCoefficient = 2f;
    [SerializeField] private float _timePriceUpgradeCoefficient = 2f;

    private int _moneyCount = 0;
    private int _clickMoneyCount = 1;
    private int _timeMoneyCount = 1;
    private int _clickUpgradePrice = 1;
    private int _timeUpgradePrice = 1;

    public int MoneyCount
    {
        set
        {
            _moneyCount += value;
            dataUpdateAction?.Invoke();
        }
        get
        {
            return _moneyCount;
        }
    }

    public int ClickPrice
    {
        get
        {
            return _clickUpgradePrice;
        }
    }

    public int TimePrice
    {
        get
        {
            return _timeUpgradePrice;
        }
    }

    private void Start()
    {
        _inputManager.clickAction += () => MoneyCount = _clickMoneyCount;
        _timeManager.timeAction += () => MoneyCount = _timeMoneyCount;

        LoadData();
    }

    public void UpgradeClick()
    {
        if (_moneyCount >= _clickUpgradePrice)
        {
            MoneyCount = -_clickUpgradePrice;

            _clickUpgradePrice = Mathf.RoundToInt(_clickUpgradePrice * _clickPriceUpgradeCoefficient);
            _clickMoneyCount = Mathf.RoundToInt(_clickMoneyCount * _clickUpgradeCoefficient);
        }

        dataUpdateAction?.Invoke();
    }

    public void UpgradeTime()
    {
        if (_moneyCount >= _timeUpgradePrice)
        {
            MoneyCount = -_timeUpgradePrice;

            _timeUpgradePrice = Mathf.RoundToInt(_timeUpgradePrice * _timePriceUpgradeCoefficient);
            _timeMoneyCount = Mathf.RoundToInt(_timeMoneyCount * _timeUpgradeCoefficient);
        }

        dataUpdateAction?.Invoke();
    }

    private void OnDestroy()
    {
        _inputManager.clickAction -= () => MoneyCount = _clickMoneyCount;
        _timeManager.timeAction -= () => MoneyCount = _timeMoneyCount;

        SaveData();
    }

    private void SaveData()
    {
        DataSaver.Save("MoneyCount", _moneyCount);
        DataSaver.Save("ClickMoneyCount", _clickMoneyCount);
        DataSaver.Save("TimeMoneyCount", _timeMoneyCount);
        DataSaver.Save("ClickUpgradePrice", _clickUpgradePrice);
        DataSaver.Save("TimeUpgradePrice", _timeUpgradePrice);
    }

    private void LoadData()
    {
        _moneyCount = DataSaver.Load("MoneyCount");
        _clickMoneyCount = DataSaver.Load("ClickMoneyCount");
        _timeMoneyCount = DataSaver.Load("TimeMoneyCount");
        _clickUpgradePrice = DataSaver.Load("ClickUpgradePrice");
        _timeUpgradePrice = DataSaver.Load("TimeUpgradePrice");
    }
}
