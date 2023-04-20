using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int spriteIndex;

    private Vector3 direction;

    private float gravity = -9.81f;

    public float strength = 5f;

    private void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AmimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AmimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
