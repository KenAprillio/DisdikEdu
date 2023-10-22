using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float healthpoints;
    public float maxHealthpoints;

    public EnemyHealthbar healthbar;
    Animator animator;
    QuestionManager questionManager;

    // Start is called before the first frame update
    void Start()
    {
        healthpoints = maxHealthpoints;
        healthbar.SetHealth(healthpoints, maxHealthpoints);

        animator = GetComponent<Animator>();
        questionManager = GameObject.FindGameObjectWithTag("QuestionManager").GetComponent<QuestionManager>();
    }

    public void TakeHit(float damage)
    {
        healthpoints -= damage;
        healthbar.SetHealth(healthpoints, maxHealthpoints);
        animator.SetTrigger("isHurt");

        if (healthpoints <= 0)
        {
            animator.SetTrigger("isDead");
        }
        else
        {
            questionManager.Correct();
        }
    }

    public void EnemyAppear()
    {
        questionManager.generateQuestion();
    }

    public void EnemyDead()
    {
        questionManager.animator.SetTrigger("nextEnemy");
        Destroy(gameObject);
        UI_InGameController.Instance.ShowWinPanel();
    }
}
