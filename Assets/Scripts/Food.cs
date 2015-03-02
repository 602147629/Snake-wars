using UnityEngine;

public class Food : MonoBehaviour, FoodInterface
{
    public int points = 10;

    public void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }

    public void Eat()
    {
        Game.points += points;
        Destroy(gameObject);

        GenerateNewFood("Prefabs/Chicken");
    }

    public static void GenerateNewFood(string typeFood)
    {
        GameObject food = (GameObject)Instantiate(Resources.Load(typeFood, typeof(GameObject)));

        while (true)
        {
                food.transform.position = new Vector3(Random.Range(-33, 33), 1, Random.Range(-33, 33));
            Bounds foodBounds = food.collider.bounds;

            bool intersects = false;

            foreach (Collider objectColiider in FindObjectsOfType(typeof(Collider)))
            {
                if (objectColiider != food.collider)
                {
                    if (objectColiider.bounds.Intersects(foodBounds))
                    {
                        intersects = true;
                        break;
                    }
                }
            }

            if (!intersects)
            {
                break;
            }
        }
    }
}