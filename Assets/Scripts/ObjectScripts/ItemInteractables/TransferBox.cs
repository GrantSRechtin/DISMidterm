using Unity.Mathematics;
using UnityEngine;

public class TransferBox : MonoBehaviour, IItemInteractable
{
    [SerializeField] private GameObject connectedBox;
    [SerializeField] private Vector3 itemOffset = new(0,0,0);
    [SerializeField] private Vector3 itemRotation = new(0,0,30);

    public void Interact(GameObject item)
    {
        Vector3 connectedBoxOffset = connectedBox.GetComponent<TransferBox>().GetItemOffset();

        Vector3 newItemLocation = connectedBox.transform.position + connectedBoxOffset;
        Vector3 newItemScale = item.transform.lossyScale;
        Quaternion newItemRotation = Quaternion.Euler(itemRotation);


        GameObject newItem = Instantiate(item, newItemLocation, newItemRotation);
        newItem.transform.localScale = newItemScale;
        newItem.GetComponent<Collider2D>().enabled = true;

        Destroy(item);
    }

    public Vector3 GetItemOffset()
    {
        return itemOffset;
    }
}
