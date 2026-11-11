using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int MaxHp = 2;
    protected int currentHp = 2;
    public Animator animatore;

    public virtual void Hit()
    {
        currentHp--;

        if(currentHp <= 0)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        animatore.Play("Die");
    }


}
