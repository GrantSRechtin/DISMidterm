using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TransferBox : MonoBehaviour, IItemInteractable
{
    [Header("Other box")]
    [SerializeField] private GameObject connectedBox;
    [Header("Box side. Left=true, Right=false")]
    [SerializeField] private bool room;
    
    private Vector3 itemOffsetToRight = new(0.09f,0.8f,0);
    private Vector3 itemRotationToRight = new(0,0,140);

    private Vector3 itemOffsetToLeft = new(-0.07f,0.8f,0);
    private Vector3 itemRotationToLeft = new(0,0,220);



    public void Interact(GameObject item)
    {
        Vector3 connectedBoxOffset = connectedBox.GetComponent<TransferBox>().GetItemOffset();

        Vector3 newItemLocation = connectedBox.transform.position + connectedBoxOffset;
        Vector3 newItemScale = item.transform.lossyScale;
        Quaternion newItemRotation;
        if (room)
        {
            newItemRotation = Quaternion.Euler(itemRotationToRight);
        }
        else
        {
            newItemRotation = Quaternion.Euler(itemRotationToLeft);
        }
        


        GameObject newItem = Instantiate(item, newItemLocation, newItemRotation);
        newItem.transform.localScale = newItemScale;
        newItem.GetComponent<Collider2D>().enabled = true;
        newItem.GetComponent<SortingGroup>().sortingOrder = -1;

        // // Temporary solution for hammer
        // if (newItem.CompareTag("Hammer"))
        // {
        //     newItem.transform.localScale = newItem.transform.localScale * .8f;
        // }

        Destroy(item);
    }

    public Vector3 GetItemOffset()
    {
        if (!room)
        {
            return itemOffsetToRight;
            
        }
        else
        {
            return itemOffsetToLeft;
            
        }
    }
}
