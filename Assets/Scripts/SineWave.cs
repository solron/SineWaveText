using UnityEngine;

public class SineWave : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;

    [SerializeField]
    float frequency = 20.0f;

    [SerializeField]
    float magnitude = 0.5f;

    private Vector3 pos;
    private Vector2 left;
    private Renderer rend;
    private Vector2 spriteHalfSize;

    float elapsedTime = 0;

    void Start()
    {
        pos = transform.position;
        left = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rend = GetComponent<Renderer>();
        spriteHalfSize = rend.bounds.extents;
    }

    void Update()
    {
        // Check if object left the screen on left side, and destroy it if it has
        if (pos.x < (left.x - spriteHalfSize.x))
        {
            Destroy(gameObject);
        }
        pos -= transform.right * Time.deltaTime * moveSpeed;
        elapsedTime += Time.deltaTime;
        transform.position = pos + (transform.up * Mathf.Sin(elapsedTime * frequency) * magnitude); // use time.time instead of elapsedTime
                                                                                                    // to make them move with same y pos
    }
}
