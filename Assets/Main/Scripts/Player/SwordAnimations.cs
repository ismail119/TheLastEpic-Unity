using UnityEngine;

public class SwordAnimations : MonoBehaviour
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void SwordIdle()
    {
        playerAnimator.Play("Idle");
    }
    
    public void SwordBasicAttack()
    {
        playerAnimator.Play("Attack1");
    }
    
    public void SwordMidAttack()
    {
        playerAnimator.Play("Attack2");
    }
    
    public void SwordUltiAttack()
    {
        playerAnimator.Play("Attack3");
    }

    public void SwordTakeDamage()
    {
        playerAnimator.Play("TakeDamage");
    }

    public void SwordRun()
    {
        playerAnimator.Play("Run");   
    }
    public void SwordBackWalk()
    {
        playerAnimator.Play("BackWalk");   
    }

    public void SwordDie()
    {
        playerAnimator.Play("Die");
    }
}
    

