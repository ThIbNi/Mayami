using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuneUpPlayer : MonoBehaviour
{
    [SerializeField] private GameObject CurentGun;    // Пушка в руке
    [SerializeField] private Transform UpPoint;       // Место установки при подборе
    private GameObject GuneEnterTriger = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gune"))
            GuneEnterTriger = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gune"))
            GuneEnterTriger = null;
    }

    [System.Obsolete]
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) & CurentGun != null)
        {
            CurentGun.transform.SetParent(null, true);

            for (int i = 0; i < CurentGun.transform.GetChildCount(); i++)
            {
                CurentGun.transform.GetChild(i).SetParent(CurentGun.transform, true);
            }

            CurentGun.AddComponent<Rigidbody>();
            CurentGun = null;


        }

        if (Input.GetKeyDown(KeyCode.E) & CurentGun == null & GuneEnterTriger != null)
        {
            CurentGun = GuneEnterTriger;

            CurentGun.RemoveComponent<Rigidbody>();

            CurentGun.transform.SetParent(transform, true);

            CurentGun.transform.rotation = transform.rotation;
            CurentGun.transform.position = UpPoint.position;
            CurentGun.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
