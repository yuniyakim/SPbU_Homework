module NetTests

open NUnit.Framework
open System
open Computer
open Net
open FsUnit

let computers1 =
    [
        new Computer("first", "Windows", false)
        new Computer("second", "Windows", false)
        new Computer("third", "Windows", false)
        new Computer("fourth", "Windows", true)
    ]

let matrix1 =
    [
        [false; false; true; false]
        [false; false; true; true]
        [true; true; false; false]
        [false; true; false; false]
    ]

let computers2 =
    [
        new Computer("first", "MacOS", false)
        new Computer("second", "MacOS", false)
        new Computer("third", "MacOS", false)
        new Computer("fourth", "MacOS", true)
    ]

let matrix2 =
    [
        [false; true; true; true]
        [true; false; true; true]
        [true; true; false; true]
        [true; true; true; false]
    ]

let computers3 =
    [
        new Computer("first", "Windows", false)
        new Computer("second", "MacOS", false)
        new Computer("third", "Linux", false)
        new Computer("fourth", "Windows", false)
        new Computer("fifth", "Linux", true)
    ]

let matrix3 =
    [
        [false; false; true; true; false]
        [false; false; false; false; true]
        [true; false; false; false; false]
        [true; false; false; false; true]
        [false; true; false; true; false]
    ]


