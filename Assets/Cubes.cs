using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();

        // filter children to exclude the parent
        List<Transform> childrenList = new List<Transform>();
        foreach (Transform child in children)
        {
            if (child != transform)
            {
                childrenList.Add(child);
            }
        }

        Debug.Log("Number of children: " + childrenList.Count);

        // get all children coordinates store in a list 
        List<Vector3> childrenCoordinates = new List<Vector3>();
        foreach (Transform child in childrenList)
        {
            childrenCoordinates.Add(child.position);
        }

        foreach (Transform child in childrenList)
        {
            // transform its hight randomly
            child.transform.localScale = new Vector3(child.transform.localScale.x, Random.Range(1, 10), child.transform.localScale.z);

        }

        // get the y coordinates of all children and its index in list
        List<KeyValuePair<int, float>> yCoordinates = new List<KeyValuePair<int, float>>();
        for (int i = 0; i < childrenList.Count; i++)
        {
            yCoordinates.Add(new KeyValuePair<int, float>(i, childrenList[i].transform.localScale.y));
        }

        // sort yCoordinates list by y coordinates
        yCoordinates.Sort((x, y) => x.Value.CompareTo(y.Value));

        // print yCoordinates list
        foreach (KeyValuePair<int, float> pair in yCoordinates)
        {
            Debug.Log("Index: " + pair.Key + " Y: " + pair.Value);
        }

        // modify the position of children based on the sorted yCoordinates list
        for (int i = 0; i < childrenList.Count; i++)
        {
            childrenList[yCoordinates[i].Key].position = new Vector3(childrenList[yCoordinates[i].Key].position.x, childrenList[yCoordinates[i].Key].position.y, childrenCoordinates[i].z);
        }


        // create 1000 placed in a 10x10x10 area at the center of the scene and every cube should have a random color but in transition from red to green
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(i - 5, j - 5, k - 5);
                    cube.GetComponent<Renderer>().material.color = new Color(i/10f, j/10f, k/10f);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
