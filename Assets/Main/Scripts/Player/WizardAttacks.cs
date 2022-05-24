using System.Collections;
using UnityEngine;

public class WizardAttacks : MonoBehaviour
{
        private WizardAnimations _wizardAnimations;
        private GameObject enemy;
        [SerializeField] private GameObject[] projectiles =new GameObject[3];
        [SerializeField] private GameObject spawnPoint;
        private float basicAttackPower, midAttackPower, ultiAttackPower;

        private void Awake()
        {
                _wizardAnimations = FindObjectOfType<WizardAnimations>();
                DatabaseSkeleton data = FindObjectOfType<PlayerPrefsOperations>().GetData();

                switch (data.selectedCharacterIndex)
                {
                        case 0:
                                basicAttackPower = data.character1BasicAttackPower;
                                midAttackPower = data.character1MidAttackPower;
                                ultiAttackPower = data.character1UltiAttackPower;
                                break;
                        case 1:
                                basicAttackPower = data.character2BasicAttackPower;
                                midAttackPower = data.character2MidAttackPower;
                                ultiAttackPower = data.character2UltiAttackPower;
                                break;
                        case 2:
                                basicAttackPower = data.character3BasicAttackPower;
                                midAttackPower = data.character3MidAttackPower;
                                ultiAttackPower = data.character3UltiAttackPower;
                                break;
                        case 3:
                                basicAttackPower = data.character4BasicAttackPower;
                                midAttackPower = data.character4MidAttackPower;
                                ultiAttackPower = data.character4UltiAttackPower;
                                break;
                }
        }

        private void Start()
        {
                enemy = GameObject.FindGameObjectWithTag("Enemy");
        }

        public IEnumerator WizardBasicAttack()
        {
                _wizardAnimations.WizardBasicAttack();
                yield return new WaitForSeconds(.85f);
                StartCoroutine(enemy.GetComponent<EnemyAttacks>().EnemyHealthDeacreasing(int.Parse(basicAttackPower.ToString())));
                Instantiate(projectiles[0], spawnPoint.transform.position, transform.rotation);
                StartCoroutine(EnemyAttackStarter());
        }
        public IEnumerator WizardMidAttack()
        {       
                _wizardAnimations.WizardMidAttack();
                yield return new WaitForSeconds(.85f);
                StartCoroutine(enemy.GetComponent<EnemyAttacks>().EnemyHealthDeacreasing(int.Parse(midAttackPower.ToString())));

                Instantiate(projectiles[1], spawnPoint.transform.position, transform.rotation);
                StartCoroutine(EnemyAttackStarter());
        }
        public IEnumerator WizardUltiAttack()
        {
                _wizardAnimations.WizardUltiAttack(FindObjectOfType<PlayerPrefsOperations>().GetData().selectedCharacterIndex);
                yield return new WaitForSeconds(1.1f);
                StartCoroutine(enemy.GetComponent<EnemyAttacks>().EnemyHealthDeacreasing(int.Parse(ultiAttackPower.ToString())));
                if (FindObjectOfType<PlayerPrefsOperations>().GetData().selectedCharacterIndex==2)
                {
                        Destroy(Instantiate(projectiles[2], spawnPoint.transform.position, transform.rotation),1.5f);
                }
                else
                {
                        Destroy(Instantiate(projectiles[2], spawnPoint.transform.position+Vector3.down*1.25f, transform.rotation),3f);
                }
                StartCoroutine(EnemyAttackStarter());
        }
        
        public IEnumerator EnemyAttackStarter()
        {
                FindObjectOfType<EnemyAnimation>().TakeDamage();
                yield return new WaitForSeconds(2);
                enemy.GetComponent<EnemyAttacks>().EnemyAttack();
                yield return new WaitForSeconds(.75f);
                FindObjectOfType<GamePanel>().attackButtons.SetActive(true);
        }
}
