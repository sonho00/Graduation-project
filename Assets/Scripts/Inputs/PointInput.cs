using UnityEngine;
using UnityEngine.EventSystems;

public class PointInput : MonoBehaviour, IPointerMoveHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BrickManager brickManager;
    public GameObject cursor;

    private void OnDisable()
    {
        cursor.SetActive(false);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        cursor.SetActive(true);
        cursor.transform.position = brickManager.GetClosestBrick(eventData.position).transform.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.Fire(eventData.pressPosition, cursor.transform.position);
    }
}
