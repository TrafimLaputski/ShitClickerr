using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public Action timeAction;
    private bool _play = true;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (_play)
        {
            yield return new WaitForSeconds(1);

            timeAction?.Invoke();
        }
    }

    private void OnDestroy()
    {
        _play = false;
    }
}