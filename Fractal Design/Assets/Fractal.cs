using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

	/**
	 * Use this for initialization
	 */
	void Start () {

		// Choose a random rotation speed from -maxRotationSpeed to maxRotationSpeed.
		rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);

		// We'd want to fill in our materials 2d array if it hasn't already been filled in.
		if (materials == null) {
			InitializeMaterials();
		}

		// Creates a new component and attaches it to the game object. Returns a reference to it.
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0, 2)];

		// If the current depth is less than maxDepth, continue creating children.
		if (depth < maxDepth) {

			// Allows for a "pause" to whatever function that gets passed into StartCoroutine.
			// Essentially, we're creating an iterator. When a function is passed into the
			// StartCoroutine method, it will get stored and return new items whenever it's asked for one.
			StartCoroutine(CreateChildren());

		}
         
	}

	/**
	 * Update is called once per frame
	 */
	void Update () {

		// Applies a rotation to our fractal.
		transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

	}

	/**
	 * Handles our initialization given a parent.
     * childIndex represents which number child this object is,
     * and helps decide its position and orientation.
	 */
	private void Initialize(Fractal parent, int childIndex) {

        /** ===== SECTION: Recursive Attributes =====
         *  Assign the attributes of this fractal such that they maintain the recursive structure.
         */

        mesh = parent.mesh;
		materials = parent.materials;
		childScale = parent.childScale;
        maxDepth = parent.maxDepth;
        maxRotationSpeed = parent.maxRotationSpeed;
		depth = parent.depth + 1;
		transform.parent = parent.transform; 


        /** ===== SECTION: Setting Children Transforms =====
         *  Modify the transforms appropriately so that they meet the specifications.
         */

        transform.localScale = new Vector3(childScale, childScale, childScale);
        transform.localPosition = 0.1f*childDirections[childIndex];
		transform.localRotation = childOrientations[childIndex]; 
	}

	/**
	 * Method that creates children.
	 */
	private IEnumerator CreateChildren () {

		// Simply iterates through all the ways in which we want to grow our children.
		for (int i = 0; i < childDirections.Length; i++) {

			// "yield" creates an enumerator object to help with the Coroutine.
			// This is why this method returns an IEnumerator object.
			yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            /** ===== SECTION: Creating the Children =====
			 *  Create a new empty gameobject, add the Fractal component to it,
             *  and call the new Fractal's Initialize() function.
             */

            // YOUR CODE HERE
            GameObject newChild = new GameObject("newChild");
            newChild.AddComponent<Fractal>().Initialize(this, i);

		}

	}

	/**
	 * Fills in our materials 2d array with various materials of differing colors.
	 * 
	 * We won't be focusing on how this works. However, if you wish to play with different
	 * color schemes for your fractal, feel free to change it here.
	 */
	private void InitializeMaterials () {
		
		materials = new Material[maxDepth + 1, 2];

		for (int i = 0; i <= maxDepth; i++) {
			float t = i / (maxDepth - 1f);
			t *= t;
			materials[i, 0] = new Material(material);
			materials[i, 0].color = Color.Lerp(Color.white, Color.yellow, t);
			materials[i, 1] = new Material(material);
			materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
		}

		materials[maxDepth, 0].color = Color.blue;
		materials[maxDepth, 1].color = Color.red;

	}

	// =============================================== DO NOT CHANGE BELOW THIS LINE ===============================================

	/** 
	 * A mesh is a construct used by the graphics hardware to draw stuff.
	 * 
	 * In this case, this mesh will represent the shape that our fractal takes (a cube).
	 */
	public Mesh mesh;

	/**
	 * Materials defines how an object will look (i.e. color, properties 
	 * when light bounces off, etc.)
	 */
	public Material material;

	/**
	 * Maximum recursive depth (so your computer doesn't run out of memory)
	 * IMPORTANT: THIS SHOULD BE SET TO 5 NORMALLY!!!
	 * For a fun experiment, you should try running your completed program with a maxDepth of 10.
	 */
	public int maxDepth;

	/**
	 * Current depth.
	 */
	private int depth;

	/**
	 * Multiplier to determine the size of child, in relation to its parent
	 */
	public float childScale;

	/**
	 * Array that holds our different materials once we initialize it.
	 */
	private Material[,] materials;

	/**
	 * Maximum speed that our fractal components will rotate.
	 */
	public float maxRotationSpeed;

	/**
	 * Rotation speed.
	 */
	private float rotationSpeed;

	/**
	 * Directions in which the children can grow.
	 */
	private static Vector3[] childDirections = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back
	};

	/**
	 * Orientation of the children.
	 */
	private static Quaternion[] childOrientations = {
		Quaternion.identity,
		Quaternion.Euler(0f, 0f, -90f),
		Quaternion.Euler(0f, 0f, 90f),
		Quaternion.Euler(90f, 0f, 0f),
		Quaternion.Euler(-90f, 0f, 0f)
	};
}
