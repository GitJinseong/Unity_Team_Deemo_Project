using UnityEngine;

public class Choi_NoteCollision : MonoBehaviour
{
    public delegate void NoteCollisionHandler(GameObject noteObject);
    public static event NoteCollisionHandler OnNoteCollision;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note") && other.gameObject != gameObject)
        {
            Choi_Note otherNote = other.GetComponent<Choi_Note>();
            Choi_Note myNote = GetComponent<Choi_Note>();

            if (otherNote != null && myNote != null)
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
