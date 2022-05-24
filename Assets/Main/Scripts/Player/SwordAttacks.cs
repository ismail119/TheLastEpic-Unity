using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SwordAttacks : MonoBehaviour
{
        private SwordAnimations _swordAnimations;
        private GameObject enemy;
        [SerializeField] private GameObject blood,hit;
        private float basicAttackPower, midAttackPower, ultiAttackPower;

        private void Awake()
        {
                _swordAnimations = GetComponent<SwordAnimations>();
        }

        private void Start()
        {
                DatabaseSkeleton data = FindObjectOfType<PlayerPrefsOperations>().GetData();
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                print(data.selectedCharacterIndex);
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

        
        public IEnumerator SwordBasicAttack()
        {
                if (PlayerPrefsOperations.Instance.GetData().currentEnergy<=0) yield break;
                
                var firstPos = transform.position;
                _swordAnimations.SwordRun();
                print(enemy);
                transform.DOMove(enemy.transform.position + enemy.transform.forward*2f, 1.3f).SetEase(Ease.Linear);;
                yield return new WaitForSeconds(1.3f);
                _swordAnimations.SwordBasicAttack();
                yield return new WaitForSeconds(.7f);
                Destroy(Instantiate(blood, enemy.GetComponent<EnemyAttacks>().spawnPoint.transform.position, Quaternion.identity),3);
                Destroy(Instantiate(hit, enemy.GetComponent<EnemyAttacks>().spawnPoint.transform.position, Quaternion.identity),3);
                enemy.GetComponent<EnemyAnimation>().TakeDamage();
                StartCoroutine(enemy.GetComponent<EnemyAttacks>().EnemyHealthDeacreasing(int.Parse(basicAttackPower.ToString())));
                yield return new WaitForSeconds(.8f);
                _swordAnimations.SwordBackWalk();
                transform.DOMove(firstPos, 2.5f).SetEase(Ease.Linear);
                yield return new WaitForSeconds(2.5f);
                _swordAnimations.SwordIdle();
                StartCoroutine(EnemyAttackStarter());
        }

        public IEnumerator SwordMidAttack()
        {
                if (PlayerPrefsOperations.Instance.GetData().currentEnergy<=0) yield break;
                var firstPos = transform.position;
                _swordAnimations.SwordRun();
                transform.DOMove(enemy.transform.position + enemy.transform.forward*2f, 1.3f).SetEase(Ease.Linear);
                yield return new WaitForSeconds(1.3f);
                _swordAnimations.SwordMidAttack();
                yield return new WaitForSeconds(.85f);
                Destroy(Instantiate(blood, enemy.GetComponent<EnemyAttacks>().spawnPoint.transform.position, Quaternion.identity),3);
                Destroy(Instantiate(hit, enemy.GetComponent<EnemyAttacks>().spawnPoint.transform.position, Quaternion.identity),3);
                enemy.GetComponent<EnemyAnimation>().TakeDamage();
                StartCoroutine(enemy.GetComponent<EnemyAttacks>().EnemyHealthDeacreasing(int.Parse(midAttackPower.ToString())));
                yield return new WaitForSeconds(1.15f);
                _swordAnimations.SwordBackWalk();
                transform.DOMove(firstPos, 2.5f).SetEase(Ease.Linear);
                yield return new WaitForSeconds(2.5f);
                _swordAnimations.SwordIdle();
                StartCoroutine(EnemyAttackStarter());
        }

        public IEnumerator SwordUltiAttack()
        {
                if (PlayerPrefsOperations.Instance.GetData().currentEnergy<=0) yield break;
                var firstPos = transform.position;
                _swordAnimations.SwordRun();
                transform.DOMove(enemy.transform.position + enemy.transform.forward*2f, 1.3f).SetEase(Ease.Linear);;
                yield return new WaitForSeconds(1.3f);
                _swordAnimations.SwordUltiAttack();
                yield return new WaitForSeconds(1.25f);
                Destroy(Instantiate(blood, enemy.GetComponent<EnemyAttacks>().spawnPoint.transform.position, Quaternion.identity),3);
                Destroy(Instantiate(hit, enemy.GetComponent<EnemyAttacks>().spawnPoint.transform.position, Quaternion.identity),3);
                enemy.GetComponent<EnemyAnimation>().TakeDamage();
                StartCoroutine(enemy.GetComponent<EnemyAttacks>().EnemyHealthDeacreasing(int.Parse(ultiAttackPower.ToString())));
                yield return new WaitForSeconds(1.05f);
                _swordAnimations.SwordBackWalk();
                transform.DOMove(firstPos, 2.5f).SetEase(Ease.Linear);
                yield return new WaitForSeconds(2.5f);
                _swordAnimations.SwordIdle();
                StartCoroutine(EnemyAttackStarter());
        }

        public IEnumerator EnemyAttackStarter()
        {
                yield return new WaitForSeconds(1);
                enemy.GetComponent<EnemyAttacks>().EnemyAttack();
                yield return new WaitForSeconds(.75f);
                FindObjectOfType<GamePanel>().attackButtons.SetActive(true);
        }
        
}
