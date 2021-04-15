using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;
    public int enemy_fov = 120;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
            Debug.Log("SEEN");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            // dot product functionality implemented by River Veek

            // new vector (enemy to player)
            Vector3 enemy_to_player = player.position - transform.position + Vector3.up;
            Vector3 enemy_to_player_n = enemy_to_player.normalized;
            Vector3 enemy_forward_n = transform.forward.normalized;

            // dot product
            float dot_product = Vector3.Dot(enemy_to_player_n, enemy_forward_n);
            float angle = Mathf.Rad2Deg * Mathf.Acos(dot_product);

            // check whether player falls into enemy fov
            if (angle < (enemy_fov / 2))
            {
                Debug.Log(angle);
                gameEnding.CaughtPlayer();
            }
            
            // tutorial code
            /*
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
            */
        }

    }
}
