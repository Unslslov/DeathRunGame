using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rect _TouchFieldForJump;
    [SerializeField] private RectTransform rectTransform;

    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;

    public bool isJumping;


    void Start()
    {
        _TouchFieldForJump = GetRectFromRectTransform(rectTransform);
    }

    private Rect GetRectFromRectTransform(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        Vector2 min = new Vector2(corners[0].x, corners[0].y);
        Vector2 max = new Vector2(corners[2].x, corners[2].y);

        return new Rect(min, max - min);
    }

    void Update()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;

        var touchPosition = eventData.position;

        if ((touchPosition.x > _TouchFieldForJump.min.x && touchPosition.y > _TouchFieldForJump.min.y) &&
            (touchPosition.x < _TouchFieldForJump.max.x && touchPosition.y < _TouchFieldForJump.max.y))
        {
            isJumping = true;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        isJumping = false;
    }
}
