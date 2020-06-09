using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine.SceneManagement;
using System.Collections;
public class SaveSystem : MonoBehaviour
{
    public GameObject loadingScreen;
    private static MoveButton player;
    public static bool loading;
    public GameObject bed;
    private bool bedConsumed;
    private float bedNextFireTime;
    private void Start() {
        loading = false;
        bedConsumed = bed.GetComponent<Cooldown>().consumed;
        bedNextFireTime = bed.GetComponent<Cooldown>().nextFireTime;
    }
    private void Awake() 
    {
        player = GameObject.FindObjectOfType<MoveButton>();
    }
    public void Save ()
    {
        NewGame.gameStart = false;
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.dathp", FileMode.OpenOrCreate);
        FileStream stream1 = new FileStream(Application.persistentDataPath + "/player.dathapp", FileMode.OpenOrCreate);
        FileStream stream2 = new FileStream(Application.persistentDataPath + "/player.datprog", FileMode.OpenOrCreate);
        FileStream stream3 = new FileStream(Application.persistentDataPath + "/player.datLM", FileMode.OpenOrCreate);
        FileStream stream4 = new FileStream(Application.persistentDataPath + "/player.datLS", FileMode.OpenOrCreate);
        FileStream stream5 = new FileStream(Application.persistentDataPath + "/player.datpos", FileMode.OpenOrCreate);
        FileStream stream6 = new FileStream(Application.persistentDataPath + "/player.dattime", FileMode.OpenOrCreate);
        FileStream stream7 = new FileStream(Application.persistentDataPath + "/player.datbedconsumed", FileMode.OpenOrCreate);
        FileStream stream8 = new FileStream(Application.persistentDataPath + "/player.datbedsleepcooldown", FileMode.OpenOrCreate);
        print("Saving");
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Saver.playerHealth);
            formatter.Serialize(stream1, Saver.playerHapp);
            formatter.Serialize(stream2, Saver.playerProg);
            formatter.Serialize(stream3, Saver.lastMove);
            formatter.Serialize(stream4, Saver.lastScene);
            formatter.Serialize(stream5, Saver.position);
            formatter.Serialize(stream6, Saver.startTime);
            formatter.Serialize(stream7, Saver.bedConsumed);
            formatter.Serialize(stream8, Saver.bedSleepCooldown);
        }
        catch (SerializationException e)
        {
            Debug.Log("there was a problem serialising because: " + e.Message);
        }
        finally
        {
            stream.Close();
            stream1.Close();
            stream2.Close();
            stream3.Close();
            stream4.Close();
            stream5.Close();
            stream6.Close();
            stream7.Close();
            stream8.Close();
        }
    }

    public void Load ()
    {
        loading = true;
        StartCoroutine(WaitLoad());
    }
    IEnumerator WaitLoad()
    {
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.dathp", FileMode.Open);
        FileStream stream1 = new FileStream(Application.persistentDataPath + "/player.dathapp", FileMode.Open);
        FileStream stream2 = new FileStream(Application.persistentDataPath + "/player.datprog", FileMode.Open);
        FileStream stream3 = new FileStream(Application.persistentDataPath + "/player.datLM", FileMode.Open);
        FileStream stream4 = new FileStream(Application.persistentDataPath + "/player.datLS", FileMode.Open);
        FileStream stream5 = new FileStream(Application.persistentDataPath + "/player.datpos", FileMode.Open);
        FileStream stream6 = new FileStream(Application.persistentDataPath + "/player.dattime", FileMode.Open);
        FileStream stream7 = new FileStream(Application.persistentDataPath + "/player.datbedconsumed", FileMode.Open);
        FileStream stream8 = new FileStream(Application.persistentDataPath + "/player.datbedsleepcooldown", FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Saver.playerHealth = (float)formatter.Deserialize(stream);
            Saver.playerHapp = (float)formatter.Deserialize(stream1);
            Saver.playerProg = (float)formatter.Deserialize(stream2);
            Saver.lastMove = (Serializablevector2)formatter.Deserialize(stream3);
            Saver.lastScene = (string)formatter.Deserialize(stream4);
            Saver.position = (SerializableVector3)formatter.Deserialize(stream5);
            Saver.startTime = (float)formatter.Deserialize(stream6);
            Saver.bedConsumed = (bool)formatter.Deserialize(stream7);
            Saver.bedSleepCooldown = (float)formatter.Deserialize(stream8);
            LoadNewArea.currentActiveScene = Saver.lastScene;
            NewGame.gameStart = true;
            PauseButton.mainMenu = false;
            Movus.setPosition();
            Time.timeScale = 1f;
            Timer.startTime = Saver.startTime;
            MoveButton.lastMove.x = Saver.lastMove.x;
            MoveButton.lastMove.y = Saver.lastMove.y;
            PlayerHpManager.playerCurrentHealth = Saver.playerHealth;
            PlayerHappManager.playerCurrentHapp = Saver.playerHapp;
            PlayerProgManager.playerCurrentProg = Saver.playerProg;
            bed.GetComponent<Cooldown>().consumed = Saver.bedConsumed;
            bed.GetComponent<Cooldown>().nextFireTime = Time.time*288 + Saver.bedSleepCooldown;
            bed.SetActive(true);
        }
        catch (SerializationException e)
        {
            Debug.Log("Error deserialising file: " + e.Message);
            print("All is well");
        }
        finally
        {
            stream.Close();
            stream1.Close();
            stream2.Close();
            stream3.Close();
            stream4.Close();
            stream5.Close();
            stream6.Close();
            stream7.Close();
            stream8.Close();
        }
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        loadingScreen.SetActive(false);
    }
}
