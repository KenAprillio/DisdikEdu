using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    //QuestionManager questionManager;
    Animator animator;
    public float damage;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackEnemy()
    {
        animator.SetTrigger("isRight");
        EnemyScript enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        enemy.TakeHit(damage);
    }

    public void Hurt()
    {
        animator.SetTrigger("isWrong");
    }

    void Walk()
    {
        animator.SetTrigger("isNext");
    }

    void NextQuestion()
    {
        QuestionManager.Instance.Correct();
    }
}
