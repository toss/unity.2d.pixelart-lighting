using UnityEngine;

/// <summary>
/// 모바일 환경에서만 터치 입력 UI를 활성화합니다.
/// 이 스크립트를 MobileInputCanvas에 추가하세요.
/// </summary>
public class MobileInputToggle : MonoBehaviour
{
    [Tooltip("데스크톱에서도 터치 UI를 강제로 표시하려면 체크")]
    [SerializeField] private bool forceShowOnDesktop = false;

    private void Awake()
    {
        bool shouldShow = forceShowOnDesktop || IsMobileOrTouchDevice();

        if (!shouldShow)
        {
            gameObject.SetActive(false);
            Debug.Log("[MobileInput] 데스크톱 환경 - 터치 UI 비활성화");
        }
        else
        {
            Debug.Log("[MobileInput] 모바일/터치 환경 - 터치 UI 활성화");
        }
    }

    private bool IsMobileOrTouchDevice()
    {
#if UNITY_EDITOR
        // Editor에서는 항상 표시 (테스트용)
        return true;
#elif UNITY_WEBGL
        // WebGL에서는 JavaScript로 모바일 여부 확인
        return IsMobileWebGL();
#else
        // 네이티브 빌드
        if (Application.isMobilePlatform)
            return true;

        if (Input.touchSupported)
            return true;

        return false;
#endif
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsMobileWebGL();
#endif
}
