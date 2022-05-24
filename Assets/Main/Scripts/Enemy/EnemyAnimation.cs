using UnityEngine;


public class EnemyAnimation : MonoBehaviour
{

    private Animator enemyAnimator;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void EnemyAttack()
    {
        enemyAnimator.Play("Attack");
    }

    public void EnemyIdle()
    {
        enemyAnimator.Play("Idle");
    }

    public void EnemyDie()
    {
        enemyAnimator.Play("Die");
    }

    public void TakeDamage()
    {
        enemyAnimator.Play("TakeDamage");
    }
}