using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjOB KitchenObj;
    [SerializeField] private Transform TopPoint;
    public void Interact() {
        Transform KitchenObjTransform = Instantiate(KitchenObj.prefab, TopPoint);

        KitchenObjTransform.localPosition = Vector3.zero;
    }
}
