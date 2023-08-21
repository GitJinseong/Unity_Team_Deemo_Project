using UnityEngine;

public class Choi_NoteCollision : MonoBehaviour
{
    public delegate void NoteCollisionHandler(GameObject noteObject);
    public static event NoteCollisionHandler OnNoteCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note") && other.gameObject != gameObject)
        {
            Choi_Note otherNote = other.GetComponent<Choi_Note>();
            Choi_Note myNote = GetComponent<Choi_Note>();
            Choi_CollisionDetection otherCollisionDetection = other.GetComponent<Choi_CollisionDetection>();
            Choi_CollisionDetection myCollisionDetection = GetComponent<Choi_CollisionDetection>();


            if ((otherNote != null && myNote != null) &&
                (otherCollisionDetection.isHide == false && myCollisionDetection.isHide == false)
                ||
                (otherCollisionDetection.isJudgeHide == false && myCollisionDetection.isJudgeHide == false))
            {
                // ��Ȱ��ȭ���� �ʾ����� ��Ʈ�� ��Ȱ��ȭ ó��
                if (other.gameObject.activeSelf)
                {
                    // �� noteId�� �浹�� ��Ʈ�� noteId ��
                    if (otherNote.noteId > myNote.noteId)
                    {
                        // ��Ʈ�� ��Ȱ��ȭ ó��
                        other.gameObject.SetActive(false);

                        Debug.Log($"��Ȱ��ȭ ID: {myNote.noteId}");

                        // �ߺ��Ǵ� �ٸ� ��Ʈ�� ���� �̺�Ʈ ȣ��
                        OnNoteCollision?.Invoke(other.gameObject);
                    }
                }
            }
        }
    }
}
