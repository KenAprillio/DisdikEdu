using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float healthpoints;
    public float maxHealthpoints;

    public EnemyHealthbar healthbar;
    Animator animator;
    //QuestionManager questionManager;

    // Start is called before the first frame update
    void Start()
    {
        healthpoints = maxHealthpoints;
        healthbar.SetHealth(healthpoints, maxHealthpoints);

        animator = GetComponent<Animator>();
        
    }

    public void TakeHit(float damage)
    {
        healthpoints -= damage;
        healthbar.SetHealth(healthpoints, maxHealthpoints);
        animator.SetTrigger("isHurt");

        if (healthpoints <= 0)
        {
            animator.SetTrigger("isDead");
            QuestionManager.Instance.questionDatabase.questionList.RemoveAt(QuestionManager.Instance.currentQuestion);

        }
        else
        {
            QuestionManager.Instance.Correct();
        }
    }

    public void EnemyAttack()
    {
        animator.SetTrigger("isAttack");
    }

    public void EnemyAppear()
    {
        QuestionManager.Instance.generateQuestion();
        Debug.Log("Generate Thy Questions!");
    }

    public void EnemyDead()
    {
        //QuestionManager.Instance.animator.SetTrigger("nextEnemy");
        QuestionManager.Instance.EnemySpawn();
        QuestionManager.Instance.backgroundScript.MoveBackground();

        Destroy(gameObject);
        UI_InGameController.Instance.AddDefeatedEnemies();
    }
}
