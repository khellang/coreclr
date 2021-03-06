using System;
using System.Collections.Generic;
/// <summary>
///Item(System.Int32)
/// </summary>
public class IListItem
{
    public static int Main()
    {
        IListItem IListItem = new IListItem();
        TestLibrary.TestFramework.BeginTestCase("IListItem");
        if (IListItem.RunTests())
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
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        retVal = PosTest4() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negitive]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling Item Property ,T is value type. ");
        try
        {
            IList<int> myList=new List<int>();
            int expectValue = 100;
            myList.Add(expectValue);
            int index=0;
            int actualValue = myList[index];
        
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", "the method of Item property get can not return the correct value.");
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
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest2: Calling Item Property ,T is reference type. ");
        try
        {
            IList<string> myList = new List<string>();
            string expectValue = "Hello";
            myList.Add(expectValue);
            int index = 0;
            string actualValue = myList[index];

            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("002.1", "the method of Item property get can not return the correct value.");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest3()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest3: Calling Item Property ,T is user define type. ");
        try
        {
            IList<MyTestClass> myList = new List<MyTestClass>();
            MyTestClass expectValue = new MyTestClass();
            expectValue.ID = 100;
            myList.Add(expectValue);
            int index = 0;
            MyTestClass actualValue = myList[index];

            if (!actualValue.Equals(expectValue))
            {
                TestLibrary.TestFramework.LogError("003.1", "the method of Item property get can not return the correct value.");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("003.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest4()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest4: Calling Item Property ,set a new value. ");
        try
        {
            IList<MyTestClass> myList = new List<MyTestClass>();
            MyTestClass expectValue = new MyTestClass();
            int value1 = 100;
            int value2 = 200;
            expectValue.ID = value1;
            myList.Add(expectValue);
            int index = 0;
            expectValue.ID = value2;
            myList[index] = expectValue;
            MyTestClass actualValue = myList[index];
            if (actualValue.ID ==value1)
            {
                TestLibrary.TestFramework.LogError("003.1", "the method of Item property get an error value.");
                retVal = false;
            }

            if (actualValue.ID!=200)
            {
                TestLibrary.TestFramework.LogError("003.2", "the method of Item property set  an error value.");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("003.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest1: index is not a valid index in the IList.");
        try
        {
            IList<MyTestClass> myList = new List<MyTestClass>();
            MyTestClass expectValue = new MyTestClass();
            expectValue.ID = 100;
            myList.Add(expectValue);
            int index = 100;
            MyTestClass actualValue = myList[index];
            TestLibrary.TestFramework.LogError("101.1", "ArgumentOutOfRangeException should be caught.");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest2: The IList is read-only.");
        try
        {
            IList<MyTestClass> myList = new MyList<MyTestClass>();
            MyTestClass expectValue = new MyTestClass();
            expectValue.ID = 100;
            myList[0] = expectValue;
            TestLibrary.TestFramework.LogError("102.1", "NotSupportedException should be caught.");
            retVal = false;
        }
        catch (NotSupportedException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("102.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }

}
public class MyTestClass
{
    private int id=0;
    public MyTestClass()
    {

    }
    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public override bool Equals(object obj)
    {
        MyTestClass mytest = obj as MyTestClass;
        return this.ID.Equals(mytest.ID);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
public class MyList<T> : IList<T>
{

    #region IList<T> Members

    public int IndexOf(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotSupportedException();
    }
   
    public T this[int index]
    {
        get
        {
            throw new NotSupportedException();
        }
        set
        {
            throw new NotSupportedException();
        }
    }

    #endregion

    #region ICollection<T> Members
    public void Clear()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public bool Contains(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public int Count
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public bool IsReadOnly
    {
        get { return true; }
    }

    public bool Remove(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region ICollection<T> Members

    public void Add(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}