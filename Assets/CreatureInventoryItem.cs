using UnityEngine;

public class CreatureInventoryItem : MonoBehaviour
{
    public bool contained = false;

    private bool canDrag = true;

    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    private Vector3 offset;

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    void OnMouseDown()
    {
        if (!canDrag) return;

        Vector3 mouseWorldPos = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        if (!canDrag) return;

        Vector3 mouseWorldPos = GetMouseWorldPosition();
        transform.position = mouseWorldPos + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(mainCamera.transform.position.z);
        return mainCamera.ScreenToWorldPoint(mouseScreenPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Container"))
        {
            contained = true;
            UpdateColor();
        }
        else if (other.CompareTag("ScreenEdge"))
        {
            LockItem();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Container"))
        {
            contained = false;
            UpdateColor();
        }
    }

    private void LockItem()
    {
        canDrag = false;

        // Optional: hard stop physics movement
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void UpdateColor()
    {
        spriteRenderer.color = contained ? Color.white : Color.red;
    }
}
