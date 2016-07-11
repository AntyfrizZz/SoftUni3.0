﻿public class Person
{
    private string name;
    private int age;

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public Person(int age)
    {
        this.age = age;
        this.name = "No name";
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string Name => this.name;

    public int Age => this.age;

}