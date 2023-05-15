using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObj : MonoBehaviour
{
    [SerializeField] private ScriptableObject KitchenObjSO;

     public ScriptableObject GetObjOS() {
        return KitchenObjSO;
    }
}
