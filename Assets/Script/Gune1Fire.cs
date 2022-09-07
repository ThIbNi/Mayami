using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gune1Fire : MonoBehaviour
{
    [SerializeField] private Transform ShotPoint;       // Место выстрела
    [SerializeField] private GameObject Bullet;         // Модель патрона
    [SerializeField] private float TimeBetweenShots;    // Время между выстрелами
    [SerializeField] private float MaxShots;            // Патронов в абойме
    [SerializeField] private float ReloadTimeMax;       // Время перезарядки
    [SerializeField] private float BulletCount;         // Сколько всего доступно патронов
    [SerializeField] private Transform BulletPerent;    // Родитель всех пуль

    private float CurentTimeBetweenShots = 0;
    private float CurentShots = 0;
    private float ReloadTime = 0;

    void Update()
    {
       
        if (CurentShots != MaxShots & ReloadTime <= 0)
            if (CurentTimeBetweenShots <= 0)
                if (Input.GetMouseButton(0) &)
                {
                    GameObject cloneBullet = Instantiate(Bullet, BulletPerent);
                    Bullet CloneBuletScript = cloneBullet.GetComponent<Bullet>();
                    cloneBullet.transform.position = ShotPoint.position;
                    cloneBullet.transform.rotation = transform.rotation;
                    CloneBuletScript.boolCloneBulet = true;


                    CurentTimeBetweenShots = TimeBetweenShots;
                    CurentShots += 1;
                    ReloadTime = 0;
                }
                else { }
            else
                CurentTimeBetweenShots -= Time.deltaTime;
        else
            {
                if (ReloadTime == 0)
                {
                    ReloadTime = ReloadTimeMax;
                    CurentShots = 0;
                }

                ReloadTime -= Time.deltaTime;
            }
    }
}
