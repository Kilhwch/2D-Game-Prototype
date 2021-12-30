using System;
using System.Collections.Generic;
using UnityEngine;

public class DmgPopupInstance : MonoBehaviour
{

    [SerializeField] private Transform pfDamagePopup;
    DamagePopup DmgPopup;

    public void CreateDamagePopup(int damage, Transform EnemyPoint)
    {
        if (enemyAlive()) { 
            Transform PopupInstance = Instantiate(pfDamagePopup, EnemyPoint.position, EnemyPoint.rotation);
            DmgPopup = PopupInstance.GetComponent<DamagePopup>();
            DmgPopup.Setup(EnemyPoint, damage);
        }
    }

    public bool enemyAlive()
    {
        DmgPopupInstance enemy = GetComponentInParent<DmgPopupInstance>();
        if (enemy == null) return false;
        else return true;
    }

    public void Clear()
    {
        DmgPopup.Clear();
    }
}