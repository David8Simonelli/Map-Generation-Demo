using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour {

	public GameObject formBlock;
    
	public int width = 20;
	public int height = 5;
	public int heightMultiplier = 5;
	public int heightAddition = 2;

    public InputField inputField;
    
    public GameObject[] gameObjects;

    public static float smoothness;
    public static bool done;

    void Start() {
        done = false;
	}

	public void GenerateSurfaceChunk() {

        ClearCurrentAnyBlocks();

        smoothness = int.Parse(inputField.text);
        Debug.Log("Input: " + smoothness);

        if(smoothness < 10) {
            Debug.Log("One Chars");
            smoothness = smoothness / 10;
        }else if(smoothness < 100) {
            Debug.Log("Two Chars");
            smoothness = smoothness / 100;
        }else if(smoothness < 1000) {
            Debug.Log("Three Chars");
            smoothness = smoothness / 1000;
        }else if(smoothness < 10000) {
            Debug.Log("Four Chars");
            smoothness = smoothness / 10000;
        }else if(smoothness < 100000) {
            Debug.Log("Five Chars");
            smoothness = smoothness / 100000;
        }

        for (int x = 0; x < width; x++) {
			int h = Mathf.RoundToInt(Mathf.PerlinNoise(x / smoothness, 0) * heightMultiplier) + heightAddition;
			for (int y = 0; y < h; y++) {
				Instantiate(formBlock, new Vector3(x, y), Quaternion.identity);
			}
		}
        done = true;	
	}

    public void ClearCurrentAnyBlocks() {

        gameObjects = GameObject.FindGameObjectsWithTag("Tiles");

        for (var i = 0; i < gameObjects.Length; i++) {
            Destroy(gameObjects[i]);
        }
    }
}
