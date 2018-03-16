using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public GameObject formBlock;

	public int width = 20;
	public int height = 5;
	public int heightMultiplier = 5;
	public int heightAddition = 2;

	public float smoothness;

    public static bool done;

	// Use this for initialization
	void Start() {
        done = false;
		GenerateSurfaceChunk();
	}

	// Update is called once per frame
	public void GenerateSurfaceChunk() {
		
		float randSmooth = Random.value;
		smoothness = smoothness * randSmooth;

		for (int x = 0; x < width; x++) {
			int h = Mathf.RoundToInt(Mathf.PerlinNoise(x / smoothness, 0) * heightMultiplier) + heightAddition;
			for (int y = 0; y < h; y++) {
				Instantiate(formBlock, new Vector3(x, y), Quaternion.identity);
			}
		}
        Debug.Log ("Done");
        done = true;
			
	}
}
