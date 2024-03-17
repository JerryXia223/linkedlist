using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void TestAddFirst()
    {
        LinkedList list = new LinkedList();
        list.AddFirst("Joe Blow");

        Assert.AreEqual(list.Count, 1);
        Assert.AreEqual(list.Head.Value, "Joe Blow");

        list.AddFirst("Joe Schmoe");
        list.AddFirst("@");

        Assert.AreEqual(list.Count, 3);
        Assert.AreEqual(list.Head.Value, "@");
        Assert.AreEqual(list.Head.Next.Value, "Joe Schmoe");
        Assert.AreEqual(list.Head.Next.Next.Value, "Joe Blow");
    }

    [TestMethod]
    public void TestAddLast()
    {
        LinkedList list = new LinkedList();
        list.AddLast("John Smith");

        Assert.AreEqual(list.Count, 1);
        Assert.AreEqual(list.Head.Value, "John Smith");

        list.AddLast("Jane Doe");
        list.AddLast("Bob Bobberson");

        Assert.AreEqual(list.Count, 3);
        Assert.AreEqual(list.Head.Value, "John Smith");
        Assert.AreEqual(list.Head.Next.Value, "Jane Doe");
        Assert.AreEqual(list.Head.Next.Next.Value, "Bob Bobberson");
    }

    [TestMethod]
    public void TestRemoveFirst()
    {
        LinkedList list = new LinkedList();

        // Test removing from an empty list
        list.RemoveFirst();
        Assert.AreEqual(list.Count, 0);
        Assert.AreEqual(list.Head, null);

        // Test removing from a non-empty list
        list.AddFirst("Joe Blow");
        list.AddFirst("Joe Schmoe");
        list.AddFirst("@");

        list.RemoveFirst();

        Assert.AreEqual(list.Count, 2);
        Assert.AreEqual(list.Head.Value, "Joe Schmoe");
        Assert.AreEqual(list.Head.Next.Value, "Joe Blow");
    }

    [TestMethod]
    public void TestRemoveLast()
    {
        LinkedList list = new LinkedList();

        // Test removing from an empty list
        list.RemoveLast();
        Assert.AreEqual(list.Count, 0);
        Assert.AreEqual(list.Head, null);

        // Test removing from a list with one element
        list.AddFirst("Joe Blow");
        list.RemoveLast();
        Assert.AreEqual(list.Count, 0);
        Assert.AreEqual(list.Head, null);

        // Test removing from a list with more than one element
        list.AddFirst("Joe Blow");
        list.AddFirst("Joe Schmoe");
        list.AddFirst("@");
        list.RemoveLast();

        Assert.AreEqual(list.Count, 2);
        Assert.AreEqual(list.Head.Value, "@");
        Assert.AreEqual(list.Head.Next.Value, "Joe Schmoe");
    }

    [TestMethod]
    public void TestGetValue()
    {
        LinkedList list = new LinkedList();
        list.AddFirst("Joe Blow");
        list.AddFirst("Joe Schmoe");
        list.AddFirst("@");
        list.AddLast("Jane Doe");
        list.AddLast("Bob Bobberson");

        Assert.AreEqual(list.GetValue(0), "@");
        Assert.AreEqual(list.GetValue(1), "Joe Schmoe");
        Assert.AreEqual(list.GetValue(2), "Joe Blow");
        Assert.AreEqual(list.GetValue(3), "Jane Doe");
        Assert.AreEqual(list.GetValue(4), "Bob Bobberson");
    }

    [TestMethod]
    public void TestCount()
    {
        LinkedList list = new LinkedList();

        Assert.AreEqual(list.Count, 0);

        list.AddFirst("Joe Blow");
        list.AddFirst("Joe Schmoe");
        list.AddFirst("@");
        list.AddLast("Jane Doe");
        list.AddLast("Bob Bobberson");

        Assert.AreEqual(list.Count, 5);

        list.RemoveFirst();
        list.RemoveLast();

        Assert.AreEqual