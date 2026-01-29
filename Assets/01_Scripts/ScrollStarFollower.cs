using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollStarFollower : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler
{
    public ScrollRect scrollRect;
    public RectTransform track; // 별이 움직이는 레일 (Scrollbar Vertical의 RectTransform 추천)
    public float offsetY = 30f;

    RectTransform star;
    float grabOffsetYInTrack;   // track 좌표계 기준, 클릭 지점 - 별 중심 차이

    void Awake()
    {
        star = (RectTransform)transform;
    }

    void LateUpdate()
    {
        if (!scrollRect || !track) return;

        // (선택) 스크롤 불필요 시 별 숨기기
        bool canScroll =
            scrollRect.content.rect.height >
            scrollRect.viewport.rect.height + 0.01f;

        star.gameObject.SetActive(canScroll);
        if (!canScroll) return;

        // 스크롤 위치(1=위, 0=아래) -> 별 위치로 반영
        float t = scrollRect.verticalNormalizedPosition;

        float trackH = track.rect.height;
        float starH = star.rect.height;

        float yTop = trackH * 0.5f - starH * 0.5f + offsetY;
        float yBottom = -trackH * 0.5f + starH * 0.5f - offsetY;

        var p = star.anchoredPosition;
        p.y = Mathf.Lerp(yBottom, yTop, t);
        star.anchoredPosition = p;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 포인터 위치를 track 로컬 좌표로
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            track, eventData.position, eventData.pressEventCamera, out var pointerLocalInTrack);

        // 별 중심의 위치(anchoredPosition)를 track 로컬 기준 y로 취급
        // (별이 track과 같은 부모/좌표계면 정확히 맞음)
        float starCenterYInTrack = star.anchoredPosition.y;

        grabOffsetYInTrack = pointerLocalInTrack.y - starCenterYInTrack;
    }

    public void OnBeginDrag(PointerEventData eventData) => OnDrag(eventData);

    public void OnDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                track, eventData.position, eventData.pressEventCamera, out var pointerLocalInTrack))
            return;

        float trackH = track.rect.height;
        float starH = star.rect.height;

        float yTop = trackH * 0.5f - starH * 0.5f + offsetY;
        float yBottom = -trackH * 0.5f + starH * 0.5f - offsetY;

        // 포인터가 찍은 지점이 별에서 유지되도록 오프셋 보정
        float desiredStarCenterY = pointerLocalInTrack.y - grabOffsetYInTrack;
        desiredStarCenterY = Mathf.Clamp(desiredStarCenterY, yBottom, yTop);

        float t = Mathf.InverseLerp(yBottom, yTop, desiredStarCenterY);
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(t);
    }
}
