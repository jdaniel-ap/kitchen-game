using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjOB KitchenObj;
    [SerializeField] private Transform TopPoint;

    private KitchenObj kitchenObj;

    public void Interact() {

        if(kitchenObj == null) {
            Transform KitchenObjTransform = Instantiate(KitchenObj.prefab, TopPoint);
            KitchenObjTransform.localPosition = Vector3.zero;

            kitchenObj = KitchenObjTransform.GetComponent<KitchenObj>();
        }
    }
}
