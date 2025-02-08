using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCursor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image image;

    private Vector2 cursorPosition;

    void Update()
    {
        image.enabled = image.sprite;

        cursorPosition = Input.mousePosition;
        transform.position = cursorPosition;
    }

    public Vector2 GetPosition() => cursorPosition;

    public void SetIcon(Sprite icon)
    {
        image.sprite = icon;
    }

    public void Clear()
    {
        image.sprite = null;
    }
}
