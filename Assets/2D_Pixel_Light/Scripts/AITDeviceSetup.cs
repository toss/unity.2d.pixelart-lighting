using UnityEngine;
using AppsInToss;

/// <summary>
/// 게임 시작 시 AIT 디바이스 설정을 초기화합니다.
/// 화면 방향을 landscape로 설정합니다.
/// </summary>
public class AITDeviceSetup : MonoBehaviour
{
    private async void Start()
    {
        await SetLandscapeOrientation();
    }

    private async System.Threading.Tasks.Task SetLandscapeOrientation()
    {
        try
        {
            Debug.Log("[AITDeviceSetup] 화면 방향을 landscape로 설정 중...");

            var options = new SetDeviceOrientationOptions
            {
                Type = SetDeviceOrientationOptionsType.Landscape
            };

            await AIT.SetDeviceOrientation(options);

            Debug.Log("[AITDeviceSetup] 화면 방향 설정 완료");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[AITDeviceSetup] 화면 방향 설정 실패: {e.Message}");
        }
    }
}
