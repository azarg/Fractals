using UnityEngine;

public class Fractal : MonoBehaviour
{
    [SerializeField, Range(1, 8)]
    int depth = 4;
    void Update() {
        transform.Rotate(0f, 22.5f * Time.deltaTime, 0f);
    }

    private void Start() {
        name = "Fractal " + depth;
        if (depth <= 1) {
            return;
        }
        var child1 = CreateChild(Vector3.up, Quaternion.identity);
        var child2 = CreateChild(Vector3.right, Quaternion.Euler(0f, 0f, -90f));
        var child3 = CreateChild(Vector3.left, Quaternion.Euler(0f, 0f, 90f));
        var child4 = CreateChild(Vector3.forward, Quaternion.Euler(90f, 0f, 0f));
        var child5 = CreateChild(Vector3.back, Quaternion.Euler(-90f, 0f, 0f));

        child1.transform.SetParent(transform, false);
        child2.transform.SetParent(transform, false);
        child3.transform.SetParent(transform, false);
        child4.transform.SetParent(transform, false);
        child5.transform.SetParent(transform, false);
    }

    private Fractal CreateChild(Vector3 direction, Quaternion rotation) {
        Fractal child = Instantiate(this);
        child.depth = depth - 1;
        child.transform.localPosition = 0.75f * direction;
        child.transform.localRotation = rotation;
        child.transform.localScale = 0.5f * Vector3.one;
        return child;
    }
}
