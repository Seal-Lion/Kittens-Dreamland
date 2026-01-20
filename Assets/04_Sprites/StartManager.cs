using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 시작 화면 UI 관리
/// </summary>
public class StartManager : MonoBehaviour
{
    [SerializeField] private Button startBtn = null;                  // 게임 시작 버튼
    [SerializeField] private Button settingBtn = null;                // 설정 버튼
    [SerializeField] private Button settingCloseBtn = null;           // 설정 닫기 버튼
    [SerializeField] private GameObject settingPanel = null;          // 설정 UI 패널


    /// <summary>
    /// UI 초기 상태 설정
    /// </summary>
    void Start()
    {

        InitializeUI();
        RegisterButtonEvent();
    }

    void Update()
    {
        
    }


    /// <summary>
    /// UI 초기 상태 설정
    /// </summary>
    private void InitializeUI()
    {
        if (settingPanel != null)
        {
            settingPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 버튼 클릭 이벤트 등록
    /// </summary>
    private void RegisterButtonEvent()
    {
        // 시작 버튼 클릭 이벤트 등록
        if (startBtn != null)
        {
            startBtn.onClick.AddListener(OnStartBtnClick);
        }

        // 설정 버튼 클릭 이벤트 등록
        if (settingBtn != null)
        {
            settingBtn.onClick.AddListener(OnSettingBtnClick);
        }

        // 설정창 닫기 버튼 클릭 이벤트 등록
        if (settingCloseBtn != null)
        {
            settingCloseBtn.onClick.AddListener(OnCloseSettingPanelBtnClick);
        }

    }

    /// <summary>
    /// 메인 씬으로 이동
    /// </summary>
    private void OnStartBtnClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// 설정 패널 열기
    /// </summary>
    private void OnSettingBtnClick()
    {
        if (settingBtn != null)
        {
            settingPanel.SetActive(true);
        }
    }

    /// <summary>
    /// 설정 패널 닫기
    /// </summary>
    private void OnCloseSettingPanelBtnClick()
    {
        if (settingPanel != null)
            settingPanel.SetActive(false);
    }

}
