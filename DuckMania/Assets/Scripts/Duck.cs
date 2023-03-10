using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Duck : MonoBehaviour
{
    public Movement movement { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.collider = GetComponent<Collider2D>();
        this.movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.movement.SetDirection(Vector2.up);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.movement.SetDirection(Vector2.right);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.movement.SetDirection(Vector2.down);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.movement.SetDirection(Vector2.left);
            }

            float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
            if (Mathf.Abs(this.movement.direction.y) > Mathf.Abs(this.movement.direction.x))
            {
                // Rotate around the Z-axis if the movement is vertical
                this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
            }
            else
            {
                // Rotate around the Y-axis if the movement is horizontal
                this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.up);
            }
        }
    }


    public void ResetState()
    {
        this.enabled = true;
        this.spriteRenderer.enabled = true;
        this.collider.enabled = true;
        this.movement.ResetState();
        this.gameObject.SetActive(true);
    }
}
