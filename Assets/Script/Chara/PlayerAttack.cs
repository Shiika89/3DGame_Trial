using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃して相手が範囲内にいたときに呼ばれる
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] CameraShake m_cameraShake;

    private void OnTriggerEnter(Collider other)
    {
        // 当たった相手のダメージinterfaceを呼んでダメージ処理を行う
        if (other.gameObject.tag == "Enemy")
        {
            var attack = other.GetComponent<EnemyStatus>();
            var move = other.GetComponent<EnemyMove>();

            if (attack)
            {
                if (PlayerMove.Instance.AttackNum == 3)
                {
                    move.IsHit = true;
                }

                attack.Damage(PlayerStatus.Instance.Attack);

                // 攻撃が当たったらヒットストップのフラグを変える
                AttackController.Instanca.OnHitStop = true;
                if (AttackController.Instanca.OnHitStop)
                {
                    StartCoroutine(HitStop(0.2f));
                    m_cameraShake.StartShake();
                }
            }
        }

        if (other.gameObject.tag == "Boss")
        {
            var attack = other.GetComponent<BossStatus>();
            if (attack != null)
            {
                attack.Damage(PlayerStatus.Instance.Attack);
            }
        }
    }
    IEnumerator HitStop(float time)
    {
        Time.timeScale = 0.3f;
        float timer = time;
        while (timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        AttackController.Instanca.OnHitStop = false;
    }
}
