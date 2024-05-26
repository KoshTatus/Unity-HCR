using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField, Range(3f, 100f)] private int levelLength = 50;
    [SerializeField, Range(1f, 50f)] private float xMult = 2f;
    [SerializeField, Range(1f, 50f)] private float yMult = 2f;
    [SerializeField, Range(0f, 1f)] private float curve = 0.5f;
    [SerializeField] private float noise = 0.5f;
    [SerializeField] private float bottom = 10f;

    private Vector3 lastpos;
    public void Update()
    {
        
    }
    public void OnValidate()
    {
        spriteShapeController.spline.Clear();

        for (int i = 0; i < levelLength; i++)
        {
            lastpos = transform.position + new Vector3(i * xMult, Mathf.PerlinNoise(0, i * noise) * yMult);
            spriteShapeController.spline.InsertPointAt(i, lastpos);

            if (i != 0 && i != levelLength - 1)
            {
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMult * curve);   
                spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMult * curve);
            }
        }

        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastpos.x, transform.position.y - bottom));
        spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));
    }

}
