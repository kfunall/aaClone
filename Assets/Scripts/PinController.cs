using UnityEngine;

public class PinController : MonoBehaviour
{
    [SerializeField] float pinSpeed;
    Rigidbody2D pinRigidbody;
    bool isPinned = false;

    private void Awake()
    {
        pinRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (!isPinned)
            pinRigidbody.MovePosition(pinRigidbody.position + Vector2.up * pinSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rotator"))
        {
            isPinned = true;
            transform.SetParent(other.transform);
        }
        else if (other.CompareTag("Pin"))
            GameManager.Instance.GameOver();
    }
}