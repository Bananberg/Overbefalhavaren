using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//kolla att cubes funkar som de ska, åt båda hållen.

public class UnitBuilderController : MonoBehaviour {

    public UnitController unit;
    public List<GameObject> bluePrints = new List<GameObject>();
    public int selection = 0;


    public int blocksPlaced = 1;
    public Vector3[] blocks;

    public LayerMask componentLayer;

    // Use this for initialization
    void Start() {
        //PlaceBlock();
        componentLayer = LayerMask.GetMask("Component");

    }

    public void PlaceBlock(RaycastHit p_hitInfo)
    {

        Vector3 dir = p_hitInfo.normal;
        Vector3 offset = p_hitInfo.point - p_hitInfo.transform.position;
        Vector3 spawnPos = p_hitInfo.transform.position + (Vector3.Scale(p_hitInfo.collider.bounds.extents, dir));// + offset;

        //kolla vilken sida; skulle vara najs med en switch men kommer inte på hur :p OOOOOOOOOOOOOOOOOOOOOOO
        //så det blir stupid solution
        int side = 0;
        int oppositeSide = 5;
        if (dir == Vector3.forward)
        {
            side = 1;
            oppositeSide = 3;
        }
        if (dir == -Vector3.forward)
        {
            side = 3;
            oppositeSide = 1;
        }
        if (dir == -Vector3.up)
        {
            side = 5;
            oppositeSide = 0;
        }
        if (dir == Vector3.right)
        {
            side = 4;
            oppositeSide = 2;
        }

        if (dir == -Vector3.right)
        {
            side = 2;
            oppositeSide = 4;
        }

        GameObject newBlock = Instantiate(bluePrints[selection], spawnPos, Quaternion.LookRotation(dir),
            p_hitInfo.transform.parent.transform.parent.transform);
        GameObject oldBlock = p_hitInfo.collider.gameObject;


        unit.cubeArray.Add(newBlock);
        CompCube block = p_hitInfo.collider.gameObject.GetComponent(typeof(CompCube)) as CompCube;
        CompCube newBlockAsComp = newBlock.GetComponentInChildren(typeof(CompCube)) as CompCube;

        block.cubes[side] = newBlock;
        newBlockAsComp.cubes[oppositeSide] = block;
        Debug.Log("Block was placed on sides" + side + " and " + oppositeSide);
        //Debug.Log("Units nr of blocks: " + unit.cubeArray.Length.ToString());


    }

    public void CycleSelection( ){
        selection++;
        if (selection > bluePrints.Count -1)
            selection = 0;
        Debug.Log("selection = " + selection);
    }

    public void DeleteBlock(RaycastHit p_hitInfo) {
        Destroy(p_hitInfo.transform.gameObject);
    }

    public void SaveModel()
    {

    }

    public void LoadModel()
    {

    }

    // Update is called once per frame
    void Update () {
       
    }
}
