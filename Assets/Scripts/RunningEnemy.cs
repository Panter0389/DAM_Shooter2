using UnityEngine;

public class RunningEnemy : BaseEnemy
{
    Vector2 targetPosition;
    bool init = false;
    public Rigidbody2D body2d;
    public float speedX = 5;
    public SpriteRenderer spriteRenderer;

    public void Init(Vector2 targetPos )
    {
        targetPosition = targetPos;
        init = true;
    }

    public void FixedUpdate()
    {
        if (!init)
            return;

        if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.4f)
        {
            Destroy(gameObject);
        }
        else
        {
            bool targetRight = transform.position.x < targetPosition.x;

            if (targetRight)
                body2d.linearVelocityX = speedX;
            else
                body2d.linearVelocityX = -speedX;

            spriteRenderer.flipX = targetRight;
        }

    }
}
