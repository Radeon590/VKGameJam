using System.Collections.Generic;
using UnityEngine;

public class TaskPoint : MonoBehaviour
{
    [SerializeField] private GameObject OrderActionsPanel;
    [SerializeField] private TaskController taskManager;
    public List<Meal> TaskMeals;

    public void AcceptOrder()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            OrderActionsPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            OrderActionsPanel.SetActive(false);
        }
    }
}
