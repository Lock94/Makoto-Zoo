using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalJson
{
    public string Kind { get; set; }
    public int Age { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public float Xiong { get; set; }
    public float Yao { get; set; }
    public float Tun { get; set; }
    public int FaYu { get; set; }
    public int RenShen { get; set; }
    public string Food { get; set; }
    public int Feed { get; set; }

    public AnimalJson(string kind, int age, float height, float weight, float xiong, float yao, float tun, int fayu, int renshen, string food, int feed)
    {
        this.Kind = kind;
        this.Age = age;
        this.Height = height;
        this.Weight = weight;
        this.Xiong = xiong;
        this.Yao = yao;
        this.Tun = tun;
        this.FaYu = fayu;
        this.RenShen = renshen;
        this.Food = food;
        this.Feed = feed;
    }
    public AnimalJson() { }
}

