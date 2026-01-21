using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 메인 화면 UI 관리
/// </summary>
public class MainManager : MonoBehaviour
{
    [SerializeField] private Button startBtn = null;                  // 악몽 물리치기 버튼
    [SerializeField] private Button storeBtn = null;                  // 마법의 상점 버튼
    [SerializeField] private Button storeCloseBtn = null;             // 상점 닫기 버튼
    [SerializeField] private GameObject storePanel = null;            // 상점 UI 패널

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
        if (storePanel != null)
        {
            storePanel.SetActive(false);
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
        if (storeBtn != null)
        {
            storeBtn.onClick.AddListener(OnStoreBtnClick);
        }

        // 상점창 닫기 버튼 클릭 이벤트 등록
        if (storeCloseBtn != null)
        {
            
        }

    }

    /// <summary>
    /// 메인 씬으로 이동
    /// </summary>
    private void OnStartBtnClick()
    {
        SceneManager.LoadScene("InGameScene");
    }


    /// <summary>
    /// 마법의 상점 패널 열기
    /// </summary>
    private void OnStoreBtnClick()
    {
        if (storePanel != null)
        {
            storePanel.SetActive(true);
        }
    }
}
