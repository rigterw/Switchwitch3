using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class start : MonoBehaviour
{
    async void Start()
    {
        Debug.Log("hi");
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log("startData");
    }


}
