using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;               // Скорость пули
    [SerializeField] private float LifeTime;            // Время до исчезновения
    [SerializeField] private float Distance;            // Дистанция стрельбы
    [SerializeField] private LayerMask BulletMask;      // Что можно пробить

    public bool boolCloneBulet = false;

    void Update()
    {

        if (boolCloneBulet)
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
}
