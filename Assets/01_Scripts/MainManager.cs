using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

/// <summary>
/// 메인 화면 UI 관리
/// </summary>
public class MainManager : MonoBehaviour
{
    [SerializeField] private Button backBtn = null;                   // 뒤로가기 버튼

    [SerializeField] private Button startBtn = null;                  // 악몽 물리치기 버튼
    [SerializeField] private Button storeBtn = null;                  // 마법의 상점 버튼
    [SerializeField] private Button storeCloseBtn = null;             // 상점 닫기 버튼
    [SerializeField] private GameObject storePanel = null;            // 상점 UI 패널

    [SerializeField] private Button classSelectBtn = null;            // 직업선택 버튼
    [SerializeField] private Button classSelectCloseBtn = null;       // 직업선택 패널 닫기 버튼
    [SerializeField] private GameObject classSelectPanel = null;      // 직업선택 UI 패널

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
        // 상점 패널 비활성화
        if (storePanel != null)
        {
            storePanel.SetActive(false);
        }

        // 직업선택 패널 비활성화
        if(classSelectPanel != null) 
        {
            classSelectPanel.SetActive(false);
        }
    }



    /// <summary>
    /// 버튼 클릭 이벤트 등록
    /// </summary>
    private void RegisterButtonEvent()
    {
        // 뒤로가기 버튼 클릭 이벤트 등록
        if (backBtn != null)
        {
            backBtn.onClick.AddListener(OnBackBtnClick);
        }

        // 악몽 물리치기 버튼 클릭 이벤트 등록
        if (startBtn != null)
        {
            startBtn.onClick.AddListener(OnStartBtnClick);
        }

        // 상점 버튼 클릭 이벤트 등록
        if (storeBtn != null)
        {
            storeBtn.onClick.AddListener(OnStoreBtnClick);
        }

        // 상점 패널 닫기 버튼 클릭 이벤트 등록
        if (storeCloseBtn != null)
        {
            storeCloseBtn.onClick.AddListener(OnCloseStoreBtnClick);
        }
        
        // 직업 선택 버튼 클릭 이벤트 등록
        if(classSelectBtn != null)
        {
            classSelectBtn.onClick.AddListener(OnClassSelectBtnClick);
        }

        // 직업 선택 패널 닫기 버튼 클릭 이벤트 등록
        


    }

    /// <summary>
    /// 메인 씬으로 이동
    /// </summary>
    private void OnStartBtnClick()
    {
        SceneManager.LoadScene("InGameScene");
    }

    /// <summary>
    /// 시작 씬으로 이동
    /// </summary>
    private void OnBackBtnClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    /// <summary>
    /// 상점 패널 열기
    /// </summary>
    private void OnStoreBtnClick()
    {
        if (storePanel != null)
        {
            storePanel.SetActive(true);
        }
    }

    /// <summary>
    /// 상점 패널 닫기
    /// </summary>
    private void OnCloseStoreBtnClick()
    {
        if (storePanel != null)
        {
            storePanel.SetActive(false);
        }
    }

    /// <summary>
    /// 직업 선택 패널 열기
    /// </summary>
    private void OnClassSelectBtnClick()
    {
        if(classSelectPanel != null)
        {
            classSelectPanel.SetActive(true);
        }
    }

    /// <summary>
    /// 직업 선택 패널 닫기
    /// </summary>
    private void OnCloseClassSelectBtnClick()
    {
        if(classSelectPanel != null)
        {
            classSelectPanel.SetActive(false);
        }
    }
}
