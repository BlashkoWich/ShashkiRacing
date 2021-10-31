using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] NpcStuckUp;
    [SerializeField] GameObject[] NpcStuckBack;
    [SerializeField] GameObject CoinStuck;
    //LineUp spawn position for NPC drive up
    //LineBack spawn position for NPC drive back
    //Must Add for every line Up and Back array
    [SerializeField] GameObject[] Spawn1LineUp;
    [SerializeField] GameObject[] Spawn1LineBack;
    [SerializeField] GameObject[] Spawn2LineUp;
    [SerializeField] GameObject[] Spawn2LineBack;
    [SerializeField] GameObject[] Spawn3LineUp;
    [SerializeField] GameObject[] Spawn3LineBack;
    [SerializeField] GameObject[] Spawn4LineUp;
    [SerializeField] GameObject[] Spawn4LineBack;
    [SerializeField] GameObject[] Spawn5LineUp;
    [SerializeField] GameObject[] Spawn5LineBack;
    [SerializeField] GameObject[] Spawn6LineUp;
    [SerializeField] GameObject[] Spawn6LineBack;
    [SerializeField] GameObject[] Spawn7LineUp;
    [SerializeField] GameObject[] Spawn7LineBack;
    [SerializeField] GameObject[] Spawn8LineUp;
    [SerializeField] GameObject[] Spawn8LineBack;
    [SerializeField] GameObject[] Spawn9LineUp;
    [SerializeField] GameObject[] Spawn9LineBack;
    [SerializeField] GameObject[] Spawn10LineUp;
    [SerializeField] GameObject[] Spawn10LineBack;
    [SerializeField] GameObject[] Spawn11LineUp;
    [SerializeField] GameObject[] Spawn11LineBack;
    [SerializeField] GameObject[] Spawn12LineUp;
    [SerializeField] GameObject[] Spawn12LineBack;

    private void Start()
    {
        //check availible spawn position
        if (Spawn1LineUp.Length != 0 || Spawn1LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn1LineUp, ref Spawn1LineBack);
        }
        if (Spawn2LineUp.Length != 0 || Spawn2LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn2LineUp, ref Spawn2LineBack);
        }
        if (Spawn3LineUp.Length != 0 || Spawn3LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn3LineUp, ref Spawn3LineBack);
        }
        if (Spawn4LineUp.Length != 0 || Spawn4LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn4LineUp, ref Spawn4LineBack);
        }  
        if (Spawn5LineUp.Length != 0 || Spawn5LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn5LineUp, ref Spawn5LineBack);
        }
        if (Spawn6LineUp.Length != 0 || Spawn6LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn6LineUp, ref Spawn6LineBack);
        }
        if (Spawn7LineUp.Length != 0 || Spawn7LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn7LineUp, ref Spawn7LineBack);
        }
        if (Spawn8LineUp.Length != 0 || Spawn8LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn8LineUp, ref Spawn8LineBack);
        }
        if (Spawn9LineUp.Length != 0 || Spawn9LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn9LineUp, ref Spawn9LineBack);
        }
        if (Spawn10LineUp.Length != 0 || Spawn10LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn10LineUp, ref Spawn10LineBack);
        }
        if (Spawn11LineUp.Length != 0 || Spawn11LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn11LineUp, ref Spawn11LineBack);
        }
        if (Spawn12LineUp.Length != 0 || Spawn12LineBack.Length != 0)
        {
            SpawnStuck(ref Spawn12LineUp, ref Spawn12LineBack);
        }
    }
    private void SpawnStuck(ref GameObject[] spawnLineUp, ref GameObject[] spawnLineBack)
    {
        //all availible spawn position = not uncluded all position for make "window" between cars
        int spawnAmt = spawnLineUp.Length + spawnLineBack.Length - Random.Range(1, (spawnLineUp.Length) / 2) - 1;

        //always have minimum one spawn position
        if (spawnAmt < 1) spawnAmt = 1;

        //Convert array to List for comfortable delete uses spawn position and dont spawn car on the same position twice
        List<GameObject> listLineUp = new List<GameObject>();

        List<GameObject> listLineBack = new List<GameObject>();

        for (int i = 0; i < spawnLineUp.Length; i++)
        {
            if(spawnLineUp.Length != 0) listLineUp.Add(spawnLineUp[i]);
            if(spawnLineBack.Length != 0) listLineBack.Add(spawnLineBack[i]);
        }
        //spawn
        for (int i = 0; i < spawnAmt; i++)
        {
            //random choise on ane line will spawn car
            int instantRandom = Random.Range(0, 2);
            //check for if spawnPosition on the line is empty choose other line

            if (instantRandom == 1 || listLineBack.Count == 0)
            {

                //random choise spawn position for in future comfortable destroy
                int listRemoveUp = Random.Range(0, listLineUp.Count);

                if (listLineUp.Count != 0)
                {
                    //spawnCar
                    Instantiate(NpcStuckUp[Random.Range(0, NpcStuckUp.Length)], listLineUp[listRemoveUp].transform);

                    //spawnCoin
                    Instantiate(CoinStuck, listLineUp[listRemoveUp].transform);

                    //remove selected spawn position for dont spawn on this position again
                    listLineUp.RemoveAt(listRemoveUp);

                }
            }
            else if (instantRandom == 0 || listLineUp.Count == 0)
            {
                int listRemoveBack = Random.Range(0, listLineBack.Count);
                if (listLineBack.Count != 0)
                {
                    Instantiate(NpcStuckBack[Random.Range(0, NpcStuckBack.Length)], listLineBack[listRemoveBack].transform);

                    Instantiate(CoinStuck, new Vector3(listLineBack[listRemoveBack].transform.position.x, listLineBack[listRemoveBack].transform.position.y + 2, listLineBack[listRemoveBack].transform.position.z), Quaternion.identity);

                    listLineBack.RemoveAt(listRemoveBack);

                }
            }
        }

    }
}
