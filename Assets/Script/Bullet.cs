using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;               // �������� ����
    [SerializeField] private float LifeTime;            // ����� �� ������������
    [SerializeField] private float Distance;            // ��������� ��������
    [SerializeField] private LayerMask BulletMask;      // ��� ����� �������

    public bool boolCloneBulet = false;
    public GameObject EfectShotWall;

    void Update()
    {

        if (boolCloneBulet & GlobalVariables.TimeRun)
        {
            bool HitInfo = Physics.Raycast(transform.position, transform.right, Distance, BulletMask);
            float moveSpeed = Speed * Time.deltaTime;

            transform.Translate(Vector3.forward * moveSpeed);

            LifeTime -= Time.deltaTime;
            Distance -= moveSpeed;

            if(LifeTime <= 0 ^ Distance <= 0)
                Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Instantiate(EfectShotWall, transform.position, transform.rotation);
            Debug.Log(transform.rotation.y);
            Destroy(this.gameObject);


        }
    }
}
