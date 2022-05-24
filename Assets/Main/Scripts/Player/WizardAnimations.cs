using UnityEngine;

public class WizardAnimations : MonoBehaviour
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void WizardIdle()
    {
        playerAnimator.Play("Idle");
    }

    public void WizardRun()
    {
        playerAnimator.Play("Run");
    }    
    public void WizardBasicAttack()
    {
        playerAnimator.Play("Attack1");
    }
    
    public void WizardMidAttack()
    {
        playerAnimator.Play("Attack1");
    }

    public void WizardUltiAttack(int index)
    {
        if (index==2)
        {
            playerAnimator.Play("LightCurrentAttack");
        }
        else
        {
            playerAnimator.Play("CrystalAttack");
        }
       
    }

    public void WizardTakeDamage()
    {
        playerAnimator.Play("TakeDamage");
    }
    public void WizardDie()
    {
        playerAnimator.Play("Die");
    }
}
