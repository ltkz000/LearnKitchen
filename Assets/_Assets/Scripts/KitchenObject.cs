using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjSO kitchenObjSO;
    [SerializeField] private IKitchenObjParent kitchenObjParent;

    public KitchenObjSO GetKitchenObjSO()
    {
        return kitchenObjSO;
    }

    public IKitchenObjParent GetKitchenObjParent()
    {
        return kitchenObjParent;
    }

    public void DestroySelf()
    {
        kitchenObjParent.ClearKitchenObject();

        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject = null;
            return false;
        }
    }

    public void SetKitchenObjectParent(IKitchenObjParent kitchenObjParent)
    {
        if (this.kitchenObjParent != null && !kitchenObjParent.HasKitchenObject())
        {
            this.kitchenObjParent.ClearKitchenObject();
            this.kitchenObjParent = kitchenObjParent;
        }

        if (this.kitchenObjParent == null) this.kitchenObjParent = kitchenObjParent;

        if (kitchenObjParent.HasKitchenObject())
        {
            Debug.LogError("Already has kitchen object");
        }
        else
        {
            kitchenObjParent.SetKitchenObject(this);

            transform.parent = kitchenObjParent.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjSO kitchenObjSO, IKitchenObjParent kitchenObjParent)
    {
        Transform kitchenObjTransform = Instantiate(kitchenObjSO.prefab);

        KitchenObject kitchenObject = kitchenObjTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjParent);

        return kitchenObject;
    }
}
