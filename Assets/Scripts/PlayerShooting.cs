using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public float damage, shootDelay = 0.2f;
    public LineRenderer lineRenderer;
   
    private void Start()
    {
        damage = GameSettings.playerDamage;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Shooting());
        if (Input.GetMouseButtonUp(0))
            StopAllCoroutines();
            
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);

            if (hit)
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hit.point);
                if(hit.transform.gameObject.CompareTag("Enemy"))
                     hit.transform.GetComponent<EnemyController>().health -= damage;
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
