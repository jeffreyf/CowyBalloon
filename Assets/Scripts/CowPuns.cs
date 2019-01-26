using System.Collections.Generic;
using System.Linq;
using System;

public static class CowPuns {
    private static Random Random = new Random();

    public static readonly List<string> Puns = new List<string>() {
        "♫ You've got to mooove it mooove it ♪",
        "Haven’t you milked this enough?",
        "You’re a natural barn leader.",
        "I think we pasture turn off.",
        "Udderly ridiculous.",
        "Very amoosing.",
        "Have you herd? The grass is greener on the other side.",
        "Simply Bovine",
        "Going to the mooovies?",
        "Holy cow!",
        "Grab me a cowfee while you're up there?",
        "You're going to be a legendairy hero!",
        "Look! It's your dairy godmother!",
        "No whey!",
        "We are not amoosed.",
        "Bull's eye.",
        "Get a mooove on!",
    };

    public static string GetRandomPun() {
        return Puns.ElementAt(Random.Next(Puns.Count));
    }
}