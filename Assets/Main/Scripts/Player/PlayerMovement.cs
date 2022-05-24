using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        private FixedJoystick playerJoystick;
        private bool isWizard;
        private float x_pos, z_pos;

        private void Awake()
        {
                playerJoystick = FindObjectOfType<FixedJoystick>();
                isWizard = FindObjectOfType<SwordAnimations>() == null;
        }

        private void Update()
        {
                Vector3 direction = Vector3.back * playerJoystick.Horizontal + Vector3.right * playerJoystick.Vertical;
                transform.position += direction * Time.deltaTime * 5;
                
                x_pos= transform.position.x;
                z_pos = transform.position.z;
                x_pos = Mathf.Clamp(x_pos, -74,-68.5f); 
                z_pos = Mathf.Clamp(z_pos, 64,75);
                transform.position = new Vector3(x_pos, transform.position.y, z_pos);
                
                if (direction != Vector3.zero)
                {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction),
                                Time.deltaTime * 8);
                        if (isWizard)
                        {
                                FindObjectOfType<WizardAnimations>().WizardRun();
                        }
                        else
                        {
                                FindObjectOfType<SwordAnimations>().SwordRun();
                        }

                        return;
                }
                if (isWizard)
                        {
                                FindObjectOfType<WizardAnimations>().WizardIdle();
                        }
                        else
                        {
                                FindObjectOfType<SwordAnimations>().SwordIdle();
                        }
        }
}
