using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    private float damage = 5, shootDelay = 0.5f;
    public LineRenderer lineRenderer;


    void Start()
    {
        damage = GetComponent<EnemyController>().damage;
        StartCoroutine(shooting());
    }

    IEnumerator shooting()
    {
        
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);

            if (hit)
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hit.point);
                if(hit.transform.gameObject.name=="Player")
                    hit.transform.GetComponent<PlayerController>().health -= damage;
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            }

            lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.03f);

            lineRenderer.enabled = false;

            yield return new WaitForSeconds(shootDelay);
        }
    }
}
