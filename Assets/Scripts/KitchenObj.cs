using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObj : MonoBehaviour
{
    [SerializeField] private KitchenObjOB KitchenObjSO;

     public KitchenObjOB GetObjOS() {
        return KitchenObjSO;
    }
}
