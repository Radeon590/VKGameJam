using System.Collections.Generic;
using UnityEngine;

public class TaskPoint : MonoBehaviour
{
    [SerializeField] private GameObject OrderActionsPanel;
    [SerializeField] private TaskController taskController;
    [HideInInspector] public ConsumerOnScene ConsumerInPoint;

    public void OrderAction()
    {
        if(ConsumerInPoint != null)
        {
            if (taskController.TaskMeals != null)
            {
                taskController.SubmitTask();
            }
            else
            {
                taskController.AcceptTask();
            }
        }
    }

    public void EnterPointAction()
    {
        Debug.Log("enter action");
        OrderActionsPanel.SetActive(true);
    }

    public void ExitPointAction()
    {
        OrderActionsPanel.SetActive(false);
    }
}
