using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float m_shakeRange = 0.2f;
    [SerializeField] float m_shakeTime = 0.2f;

    bool m_isShake;
    WaitForFixedUpdate waitFixedUpdate = new WaitForFixedUpdate();

    public void StartShake()
    {
        if (m_isShake) return;

        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        m_isShake = true;

        var startPos = transform.localPosition;
        var shakePos = startPos;

        int range1 = Random.Range(0, 2);
        int range2 = Random.Range(0, 2);

        shakePos.x += m_shakeRange * (1 + (-2 * range1));
        shakePos.y += m_shakeRange * (1 + (-2 * range2));

        transform.localPosition = shakePos;
        var timer = m_shakeTime;

        while (timer > 0)
        {
            yield return waitFixedUpdate;
            timer -= Time.fixedUnscaledDeltaTime;
            transform.localPosition = Vector3.Lerp(startPos, transform.localPosition, Time.fixedUnscaledDeltaTime);
        }
        transform.localPosition = startPos;
        m_isShake = false;
    }
}
