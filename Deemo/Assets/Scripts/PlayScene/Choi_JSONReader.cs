using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class Choi_JSONReader : MonoBehaviour
{
    TextAsset jsonAsset;
    //public string jsonFileName = "leviathan.easy";
    public const float DEFAULT_POS_Y = 13f;

    [System.Serializable]
    public class SoundData
    {
        public int w;
        public float d;
        public int p;
        public int v;

        // Get the minimum and maximum pitch values from a list of SoundData
        public static void GetMinMaxPitch(List<SoundData> sounds, out int minPitch, out int maxPitch)
        {
            minPitch = int.MaxValue;
            maxPitch = int.MinValue;

            foreach (var sound in sounds)
            {
                if (sound.p < minPitch)
                    minPitch = sound.p;

                if (sound.p > maxPitch)
                    maxPitch = sound.p;
            }
        }
    }

    [System.Serializable]
    public class NoteData
    {
        public int noteId;
        public int type;
        public List<SoundData> sounds;
        public float pos;
        public float size;
        public float _time;
        public float shift;
        public float time;
    }

    [System.Serializable]
    public class JSONData
    {
        public float speed;
        public List<NoteData> notes;
    }

    public float difficulty_time; // ���̵� ���� Hard = 0.15 / Normal = 0.3 / Easy = 0.4f
    private float previous_PosX;
    private int samePosXCount;
    private int noteLine;

    private void Awake()
    {
        switch (Park_GameManager.instance.difficulty)
        {
            case "Hard":
                difficulty_time = 0.15f;
                break;

            case "Normal":
                difficulty_time = 0.3f;
                break;

            case "Easy":
                difficulty_time = 0.4f;
                break;
        }
    }

    void Start()
    {
        Debug.Log(Park_GameManager.instance.title);
        for (int i = 0; i < Park_GameManager.instance.musicInformation["Title"].Count; i++)
        {
            if (Park_GameManager.instance.musicInformation["Title"][i] == Park_GameManager.instance.title)
            {
                jsonAsset = Resources.Load<TextAsset>(
                    Park_GameManager.instance.path +
                    "Json/" +
                    Park_GameManager.instance.musicInformation["Json" + Park_GameManager.instance.difficulty][i]);

                break;
            }
        }

        string jsonText = "";
        //string jsonFilePath = $"MusicJSONs/{jsonFileName}";

        //TextAsset jsonAsset = Resources.Load<TextAsset>(jsonFilePath);

        if (jsonAsset != null)
        {
            Debug.Log(jsonText);

            jsonText = jsonAsset.text;
            // ���� ó��
        }
        else
        {
            Debug.LogError($"JSON file not found at path");
        }

        JSONData jsonData = JsonUtility.FromJson<JSONData>(jsonText);

        float speed = jsonData.speed;
        List<NoteData> notes = jsonData.notes;

        Debug.Log($"Music Speed: {speed}");

        int skippedNoteCount = 0;

        // Dictionary to keep track of spawned notes based on their times
        Dictionary<float, int> spawnedNotesByTime = new Dictionary<float, int>();

        foreach (NoteData note in notes.OrderBy(n => n._time))
        {
            float noteTime = note._time;
            float notePosX = note.pos;

            // Check if a note has already been spawned at the same time or within 0.2 seconds
            if (spawnedNotesByTime.ContainsKey(noteTime) ||
            spawnedNotesByTime.Any(pair => Mathf.Abs(noteTime - pair.Key) < difficulty_time && Mathf.Abs(notePosX - pair.Key) >= 0.01f))
            {
                Debug.Log($"Note at time {noteTime} is being skipped due to overlapping.");
                skippedNoteCount++;
                continue;
            }

            // If the note is not overlapping, add its time and posX to the dictionary
            int noteId = note.noteId;
            spawnedNotesByTime[noteTime] = noteId;

            Debug.Log($"���̵�� : {noteId}");
            int noteType = note.type;
            List<SoundData> sounds = note.sounds;
            float pos = note.pos;
            float size = note.size;
            float _time = note._time;
            int pitch = default;

            Debug.Log($"Time: {_time}");
            // �߾��� �������� ��Ʈ ����
            Vector3 notePos = new Vector3(pos, DEFAULT_POS_Y);
            float pitchPercentage = CalculatePitchPercentage(sounds);
            Vector3 adjustedPosition = CalculateAdjustedPosition(pitchPercentage);

            // ����� 1.0f�� ����
            StartCoroutine(Choi_NoteManager.instance.SpawnNote(noteId, _time, adjustedPosition, 1.0f, noteLine));

            // �� ��Ʈ�� ���� ������ ó��
            foreach (SoundData sound in sounds)
            {
                float delay = sound.d;
                pitch = sound.p;
                int volume = sound.v;

                // ���� ���� ���
                Debug.Log($"Sound Delay: {delay} Sound Pitch: {pitch} Sound Volume: {volume}");
            }
        }

        Debug.Log($"Skipped Note Count: {skippedNoteCount}");

        //// �߰� ������ ó�� ����

        //// ����Ƽ ������Ʈ ����, �ִϸ��̼� ���� �۾� ����
    }

    Vector3 CalculateAdjustedPosition(float pitchPercentage)
    {
        float adjustedX = 0f;

        if (samePosXCount >= 2)
        {
            Debug.Log("Same");
            pitchPercentage = Random.Range(0.0f, 1.01f);
        }

        // ��ġ�� ���� �����Ǵ� ��Ʈ ������
        if (pitchPercentage >= 0.8f)
        {
            adjustedX = 3.6f;
            noteLine = 4;
        }
        else if (pitchPercentage >= 0.6f)
        {
            adjustedX = 1.8f;
            noteLine = 3;
        }
        else if (pitchPercentage >= 0.4f)
        {
            adjustedX = 0f;
            noteLine = 2;
        }
        else if (pitchPercentage >= 0.2f)
        {
            adjustedX = -1.8f;
            noteLine = 1;
        }
        else
        {
            adjustedX = -3.6f;
            noteLine = 0;
        }

        if (previous_PosX != adjustedX)
        {
            previous_PosX = adjustedX;
            samePosXCount = 0;
        }
        else
        {
            samePosXCount++;
        }

        return new Vector3(adjustedX, DEFAULT_POS_Y);
    }


    float CalculatePitchPercentage(List<SoundData> sounds)
    {
        if (sounds.Count > 0)
        {
            int minPitch, maxPitch;
            SoundData.GetMinMaxPitch(sounds, out minPitch, out maxPitch);

            // Calculate pitch percentage based on the minimum pitch value
            float pitchPercentage = (float)minPitch / 100f;
            return pitchPercentage;
        }
        return 0.5f; // Default pitch percentage if no sounds
    }
}