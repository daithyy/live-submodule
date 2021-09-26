using System;
using System.Collections;
using IMIRT.SaveSystem;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

public class SaveSystemTest
{
    [UnityTest]
    public IEnumerator SaveSystemTestWithEnumeratorPasses()
    {
        GameObject testObject = new GameObject("Test Object");
        testObject.AddComponent<DefaultSaveSystemFactory>();

        SaveSystem saveSystem = testObject.AddComponent<SaveSystem>();

        MockSaveData data = new MockSaveData();
        saveSystem.Save(data);

        MockSaveData loadedData = saveSystem.Load<MockSaveData>();

        Debug.Log(loadedData);
        Debug.Log(data);

        yield return null;

        Assert.AreEqual(data.Name, loadedData.Name);
    }
}

[Serializable]
public class MockSaveData
{
    public string Name => "Mock Data Object";
}