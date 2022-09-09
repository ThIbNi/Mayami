using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gune1Fire : MonoBehaviour
{
    [SerializeField] private Transform ShotPoint;       // Место выстрела
    [SerializeField] private GameObject Bullet;         // Модель патрона
    [SerializeField] private float TimeBetweenShots;    // Время между выстрелами
    [SerializeField] public float MaxShots;            // Патронов в абойме
    [SerializeField] private float ReloadTimeMax;       // Время перезарядки
    [SerializeField] private float BulletCount;         // Сколько всего доступно патронов
    [SerializeField] private Transform BulletPerent;    // Родитель всех пуль

    public float CurentTimeBetweenShots = 0;
    public float CurentShots = 0;
    public float ReloadTime = 0;

    void Update()
    {

        GlobalVariables.Fire = CurentTimeBetweenShots > 0;

        if (BulletCount != 0)
        {

            if (CurentShots != MaxShots & ReloadTime <= 0 & CurentTimeBetweenShots <= 0 & Input.GetMouseButton(0))
            {
                GameObject cloneBullet = Instantiate(Bullet, BulletPerent);
                Bullet CloneBuletScript = cloneBullet.GetComponent<Bullet>();
                cloneBullet.transform.position = ShotPoint.position;
                cloneBullet.transform.rotation = transform.rotation;
                CloneBuletScript.boolCloneBulet = true;

                BulletCount -= 1;
                ReloadTime = 0;
                CurentTimeBetweenShots = TimeBetweenShots;
                CurentShots += 1;
                BulletCount -= 1;

                if (CurentShots == MaxShots)
                    ReloadTime = ReloadTimeMax;

                GlobalVariables.Fire = true;
            }

            if (CurentTimeBetweenShots > 0)
                    CurentTimeBetweenShots -= Time.deltaTime;
            else if(ReloadTime > 0)
            {

                if (GlobalVariables.TimeRun)
                    ReloadTime -= Time.deltaTime;
                else
                    ReloadTime -= Time.deltaTime * GlobalVariables.SlowSpeedСoefficient;

                if (ReloadTime <= 0)
                {
                    CurentShots = 0;
                }
            }
        }
    }

}
