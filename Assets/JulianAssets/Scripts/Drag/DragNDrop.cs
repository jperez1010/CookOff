using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask targetMask;

    private enum DragState
    {
        DEFAULT,
        HOVER1,
        SELECTED,
        HOVER2
    }

    [SerializeField] private DragState state;

    public Transform hoverObject;
    public Transform playerObject;
    public Transform targetObject;


    void Update()
    {
        switch (state)
        {
            case DragState.HOVER1:
                Hover1();
                break;
            case DragState.SELECTED:
                Selected();
                break;
            case DragState.HOVER2:
                Hover2();
                break;
            default:
                Default();
                break;
        }
    }

    private void ActivateObject(Transform obj, int color_id)
    {
        if (color_id == 0)
        {
            obj.GetChild(0).gameObject.SetActive(false);
        }
        else 
        {
            Color[] colors = { Color.black, Color.green, Color.cyan, Color.red };
            obj.GetChild(0).gameObject.SetActive(true);
            obj.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = colors[color_id];
        }
    }

    private void Default()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                         float.PositiveInfinity, playerMask);
        if (hit)
        {
            hoverObject = hit.transform;
            ActivateObject(hoverObject, 1);
            state = DragState.HOVER1;
        }
    }

    private void Hover1() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                         float.PositiveInfinity, playerMask);
        if (!hit)
        {
            ActivateObject(hoverObject, 0);
            hoverObject = null;
            state = DragState.DEFAULT;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            hoverObject = null;
            playerObject = hit.transform;
            ActivateObject(playerObject, 2);
            Debug.Log("click: " + playerObject.gameObject.name);
            state = DragState.SELECTED;
        }
    }

    private void Selected()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                         float.PositiveInfinity, targetMask);

        if (Input.GetMouseButtonUp(0))
        {
            ActivateObject(playerObject, 0);
            playerObject = null;
            state = DragState.DEFAULT;
        }
        else if (hit)
        {
            hoverObject = hit.transform;
            ActivateObject(hoverObject, 2);
            state = DragState.HOVER2;
        }
    }

    private void Hover2()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                         float.PositiveInfinity, targetMask);
        if (!hit)
        {
            ActivateObject(hoverObject, 0);
            hoverObject = null;
            state = DragState.SELECTED;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            hoverObject = null;
            targetObject = hit.transform;
            ActivateObject(playerObject, 3);
            ActivateObject(targetObject, 3);
            Debug.Log("click: " + playerObject.gameObject.name + targetObject.gameObject.name);
            Vector3 pos = targetObject.position;
            pos.z = playerObject.position.z;
            playerObject.position = pos;
            playerObject = null;
            targetObject = null;
            state = DragState.DEFAULT;
        }
    }
}