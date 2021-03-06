using System;
/// <summary>
///Method
/// </summary>

public class AttributeTargetsMethod
{
    public static int Main()
    {
        AttributeTargetsMethod AttributeTargetsMethod = new AttributeTargetsMethod();

        TestLibrary.TestFramework.BeginTestCase("AttributeTargetsMethod");
        if (AttributeTargetsMethod.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
       TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
      
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Verify the AttributeTargets.Method value is 0x0040. ");
        try
        {
            int expectValue = 0x0040;
            if ((int)AttributeTargets.Method != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", " AttributeTargets.Method should return 0x0040.");
                retVal = false;
            }
           
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }
       
        return retVal;
    }
   
}

